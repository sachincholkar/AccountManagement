using AccountManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.Data
{
    public class FakeDataStore
    {
        public List<Account> Accounts;

        public FakeDataStore()
        {
            Accounts = new List<Account> {
                new Account { Id = 1, AccountNumber = "605041", FirstName = "Sachin", LastName = "Cholkar", AccountType = "Savings", Balance = 100 },
                new Account { Id = 2, AccountNumber = "605042", FirstName = "Sheldon", LastName = "Cooper", AccountType = "Current", Balance = 1000 },
                new Account { Id = 3, AccountNumber = "605043", FirstName = "Richard", LastName = "Branson", AccountType = "Savings", Balance = 20000 },
                new Account { Id = 4, AccountNumber = "605044", FirstName = "Johnny", LastName = "Depp", AccountType = "Credit", Balance = 5890 },
            };
        }

        public int GetNextId()
        {
            return Accounts.Any() ? Accounts.Max(a => a.Id) + 1 : 1;
        }
    }
}
