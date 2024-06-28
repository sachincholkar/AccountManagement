using AccountManagement.Application.Accounts.Queries.GetAccounts;
using AccountManagement.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<AccountDTO>
    {
        public int Id { get; set; }
    }
}
