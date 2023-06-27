using DataLayer;
using DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{

    public class AccountService
    {
        private readonly UnitOfWork unitOfWork;
        public AccountService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Account> GetAccounts()
        {
            var result = unitOfWork.Accounts.GetAccounts();
            return result;
        }

        public Account GetAccountByEmail(string email) { 
        return unitOfWork.Accounts.GetAccountByEmail(email);
        }
    }
}
