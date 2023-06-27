using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Users
{
    public class Applier
    {
        public int salary { get; set; }
        private JobType type { get; set; }
        public string location { get; set; }
        public string industry { get; set; }
        public RequirementsEnum requirements { get; set; }
        public ExperienceEnum experience { get; set; }
        public Applier()
        {
            salary = 0;
            type = JobType.SEASONAL;
            location = string.Empty;
            requirements = RequirementsEnum.NONE;
            industry = string.Empty;
        }
    }
}
