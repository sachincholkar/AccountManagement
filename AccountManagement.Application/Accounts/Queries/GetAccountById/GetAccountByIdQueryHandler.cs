using AccountManagement.Application.Accounts.Queries.GetAccounts;
using AccountManagement.Domain.Entity;
using AccountManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountDTO>
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountByIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public async Task<AccountDTO> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            Account account = await _accountRepository.GetAccountByIdAsync(request.Id);
            if (account != null) 
            {
                AccountDTO accountDTO = new AccountDTO { Id = account.Id, AccountNumber = account.AccountNumber, FullName = account.FirstName + " " + account.LastName, AccountType = account.AccountType, Balance = account.Balance };
                return accountDTO;
            }
            else 
            {
                return new AccountDTO { };
            }
        }
    }
}
