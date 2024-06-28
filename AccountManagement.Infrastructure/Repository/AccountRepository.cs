using AccountManagement.Domain.Entity;
using AccountManagement.Domain.Repository;
using AccountManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FakeDataStore _fakeDataStore;

        public AccountRepository(FakeDataStore fakeDataStore) { 
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            account.Id = _fakeDataStore.GetNextId();
            _fakeDataStore.Accounts.Add(account);
            return account;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return _fakeDataStore.Accounts.ToList();
            
        }
        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return _fakeDataStore.Accounts.SingleOrDefault(x => x.Id == id);
        }
       
        public async Task<int> UpdateAccountAsync(int id, Account account)
        {
            var existingAccount = _fakeDataStore.Accounts.SingleOrDefault(x => x.Id == id);
            if (existingAccount == null)
            {
                return await Task.FromResult(0);
            }

            existingAccount.AccountNumber = account.AccountNumber;
            existingAccount.FirstName = account.FirstName;
            existingAccount.LastName = account.LastName;
            existingAccount.AccountType = account.AccountType;
            existingAccount.Balance = account.Balance;

            return await Task.FromResult(1);
        }
    }
}
