using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Entities.Enums;
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
        private readonly AuthenticationService authenticationService;
        public AccountService(UnitOfWork unitOfWork, AuthenticationService authenticationService)
        {
            this.unitOfWork = unitOfWork;
            this.authenticationService = authenticationService;

        }

        public List<ViewAccountDto> GetAccounts()
        {
            var accounts = unitOfWork.Accounts.GetAccounts();

            var result = accounts.Select(r => new ViewAccountDto
            {
                FristName = r.FirstName,
                Email = r.Email,
                Role = r.Role.ToString(),
            }).ToList();

            return result;
        }

        public Account GetAccountByEmail(string email)
        {
            return unitOfWork.Accounts.GetAccountByEmail(email);
        }


        public bool CreateAdmin(RegisterDto payload)
        {

            payload.PasswordHash = authenticationService.HashPassword(payload.PasswordHash);
            Account admin = new Account
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                PasswordHash = payload.PasswordHash,
                Email = payload.Email,
                Role = Role.Admin,
            };
            unitOfWork.Accounts.AddAccount(admin);
            return true;
        }
        public bool Register(RegisterDto payload, string Role)
        {
            if (payload == null) { return false; }

            if (string.IsNullOrEmpty(payload.FirstName)
                || string.IsNullOrEmpty(payload.Email)
                || string.IsNullOrEmpty(payload.LastName)
                || string.IsNullOrEmpty(payload.PasswordHash))
            {
                return false;
            }

            var foundUserByEmail = unitOfWork.Accounts.GetAccountByEmail(payload.Email);
            if (foundUserByEmail != null)
            {
                return false;
            }

            payload.PasswordHash = authenticationService.HashPassword(payload.PasswordHash);

            Role roleForNewUser = 0;
            if (Role.Equals("Applier"))
            {
                roleForNewUser = DataLayer.Entities.Enums.Role.Applier;
            }
            else
            {
                roleForNewUser = DataLayer.Entities.Enums.Role.Employer;
            }
            Account newAccount = new Account
            {
                FirstName = payload.FirstName,
                Email = payload.Email,
                LastName = payload.LastName,
                PasswordHash = payload.PasswordHash,
                Role = roleForNewUser,
               
        };
            unitOfWork.Accounts.AddAccount(newAccount);
            return true;
        }

        public string ValidateCredentials(LoginDto payload)
        {
            return CredidentialsValidator(payload, Role.Applier);
        }

        public string ValidateAdminCredidentials (LoginDto payload)
        {
            return CredidentialsValidator(payload, Role.Admin);
        }
        public string CredidentialsValidator(LoginDto payload, Role loginRole)
        {
            if (payload == null) { return null; }

            Account accountFromDb = unitOfWork.Accounts.GetAccountByEmail(payload.Email);
            if (accountFromDb == null)
            {
                return null;
            }

            bool passwordIsOk = authenticationService.VerifyHashedPassword(accountFromDb.PasswordHash, payload.Password);
            if (!passwordIsOk)
            {
                return null;
            }

            if (accountFromDb.Role.CompareTo(loginRole) < 0)
            {
                return null;
            }

            string accountRole = accountFromDb.Role.ToString();
            return authenticationService.GetToken(accountFromDb, accountRole);
        }
    }
}
