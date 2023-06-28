using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public RegisterDto()
        {
            PasswordHash = string.Empty;
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
