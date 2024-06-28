using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQuery : IRequest<List<AccountDTO>>
    {
    }
}
