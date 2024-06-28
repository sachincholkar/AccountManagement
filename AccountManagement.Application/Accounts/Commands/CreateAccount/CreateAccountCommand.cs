using AccountManagement.Application.Accounts.Queries.GetAccounts;
using AccountManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<AccountDTO>
    {
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public Decimal Balance { get; set; }
    }
}
