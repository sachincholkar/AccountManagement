using AccountManagement.Domain.Entity;
using AccountManagement.Infrastructure.Data;
using AccountManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Tests
{
    public class AccountRepositoryTests
    {
        private readonly AccountRepository _repository;
        private readonly FakeDataStore _fakeDataStore;

        public AccountRepositoryTests()
        {
            _fakeDataStore = new FakeDataStore();
            _repository = new AccountRepository(_fakeDataStore);
        }

        [Fact]
        public async Task CreateAccountAsync_ValidAccount_ReturnsAccount()
        {
            // Arrange
            var account = new Account { FirstName = "John", LastName = "Doe", AccountNumber = "123456", AccountType = "Savings", Balance = 1000 };

            // Act
            var result = await _repository.CreateAccountAsync(account);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(account.FirstName, result.FirstName);
            Assert.Equal(account.LastName, result.LastName);
        }
    }
}
