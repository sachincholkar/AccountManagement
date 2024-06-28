using AccountManagement.Domain.Entity;
using AccountManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<AccountDTO>>
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;   
        }
        public async Task<List<AccountDTO>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            List<Account> accounts = await _accountRepository.GetAccountsAsync();
            if(accounts != null)
            {
                List<AccountDTO> accountsList = accounts.Select(x => new AccountDTO 
                { Id = x.Id, AccountNumber = x.AccountNumber, FullName = x.FirstName + " " + x.LastName, AccountType = x.AccountType, Balance = x.Balance }).ToList();
                return accountsList;
            }
            else
            {
                return new List<AccountDTO> { };
            }
        }
    }
}
