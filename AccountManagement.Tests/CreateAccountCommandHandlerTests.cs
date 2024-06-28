using AccountManagement.Application.Accounts.Commands.CreateAccount;
using AccountManagement.Domain.Entity;
using AccountManagement.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Tests
{
    public class CreateAccountCommandHandlerTests
    {
        private readonly Mock<IAccountRepository> _accountRepositoryMock;
        private readonly CreateAccountCommandHandler _handler;

        public CreateAccountCommandHandlerTests()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _handler = new CreateAccountCommandHandler(_accountRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsAccountDTO()
        {
            // Arrange
            var request = new CreateAccountCommand
            {
                FullName = "John Doe",
                AccountNumber = "123456",
                AccountType = "Savings",
                Balance = 1000
            };
            var account = new Account
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                AccountNumber = "123456",
                AccountType = "Savings",
                Balance = 1000
            };

            _accountRepositoryMock.Setup(repo => repo.CreateAccountAsync(It.IsAny<Account>()))
                .ReturnsAsync(account);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(account.Id, result.Id);
            Assert.Equal(account.FirstName, result.FullName.Split(" ")[0]);
            Assert.Equal(account.LastName, result.FullName.Split(" ")[1]);
            Assert.Equal(account.AccountNumber, result.AccountNumber);
            Assert.Equal(account.AccountType, result.AccountType);
            Assert.Equal(account.Balance, result.Balance);
        }
    }
}
