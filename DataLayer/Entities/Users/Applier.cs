using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Users
{
    public class Applier : Account
    {
        [ForeignKey("Accounts")]
        public int Accountd_ID { get; set; }
        public SalaryEnum salary { get; set; }
        private JobType type { get; set; }
        public string location { get; set; }
        public IndustryEnum industry { get; set; }
        public RequirementsEnum requirements { get; set; }
        public ExperienceEnum experience { get; set; }
        public Applier()
            :base()
        {
            salary = SalaryEnum.NONE;
            type = JobType.SEASONAL;
            location = string.Empty;
            requirements = RequirementsEnum.NONE;
            industry = IndustryEnum.NONE;
        }
    }
}
