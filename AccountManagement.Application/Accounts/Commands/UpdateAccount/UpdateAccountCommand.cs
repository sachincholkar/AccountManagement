using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string FullName { get; set; }        
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
