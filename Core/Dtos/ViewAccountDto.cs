using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class ViewAccountDto
    {
        public string FristName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ViewAccountDto()
        {
            FristName = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
        }
    }
}
