﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Users
{
    public class Admin: Account
    {
        public Admin()         
        :base()
        { 
            this.Role = Enums.Role.Admin;
        }
    }
}
