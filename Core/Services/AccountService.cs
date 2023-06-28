using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
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

        public bool Register(RegisterDto payload)
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
            Account newAccount = new Account
            {
                FirstName = payload.FirstName,
                Email = payload.Email,
                LastName = payload.LastName,
                PasswordHash = payload.PasswordHash,
                Role = DataLayer.Entities.Enums.Role.User,
            };
            unitOfWork.Accounts.AddAccount(newAccount);
            return true;

    }
}
}
