using AccountManagement.Application.Accounts.Queries.GetAccounts;
using AccountManagement.Domain.Entity;
using AccountManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountDTO>
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountDTO> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new Account() { AccountNumber = request.AccountNumber, FirstName = request.FullName.Split(" ")[0], LastName = request.FullName.Split(" ")[1], AccountType = request.AccountType, Balance = request.Balance };
            var accountCreated = await _accountRepository.CreateAccountAsync(account);

            if(accountCreated != null)
            {
                AccountDTO accountDTO = new AccountDTO()
                {
                    Id = accountCreated.Id,
                    AccountNumber = accountCreated.AccountNumber,
                    FullName = accountCreated.FirstName + " " +
                accountCreated.LastName,
                    AccountType = accountCreated.AccountType,
                    Balance = accountCreated.Balance
                };
                return accountDTO;
            }
            else
            {
                return new AccountDTO() { };
            }
            
        }
    }
}
