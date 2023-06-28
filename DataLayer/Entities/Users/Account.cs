using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Entities.Users
{
    public class Account : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public JobType JobType { get; set; }
        public RequirementsEnum Requirements { get; set; }
        public IndustryEnum Industry { get; set; }
        public ExperienceEnum Experience { get; set; }


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
