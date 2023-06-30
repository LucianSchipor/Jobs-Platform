using DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Repositories
{
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(AppDBContext dBContext) 
            :base(dBContext)
        {
            
        }

        public List<Account> GetAccounts()
        {
            var accounts = GetRecords().Select(r => new Account()
            {
                FirstName = r.FirstName,
                LastName = r.LastName,
                Email = r.Email,
                PasswordHash = r.PasswordHash,
                Role = r.Role,
            }
            ).ToList();
            return accounts;
        }
        public Account GetAccountByEmail(string Email)
        {
            var accounts = GetRecords().Where(r => r.Email == Email).FirstOrDefault();
            return accounts;
        }

        public void AddAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public bool DeleteAccount(string email)
        {
            _dbContext.Accounts.Where(a => a.Email == email).ExecuteDelete();
            return true;
        }
    }
}
