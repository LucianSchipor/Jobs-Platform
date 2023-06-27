using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Users
{
    public class Account : BaseEntity
    {
        int Account_ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }   

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Role Role { get; set; }

        public Account() 
        {
            Username = "New Account";
            PasswordHash = "New Account";
            Email  = "New Account";
            FirstName = "New Account";
            LastName = "New Account";
            Role = Role.None;
        }
    }
}
