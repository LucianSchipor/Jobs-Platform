using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Job : BaseEntity
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }

        [Required]
        public SalaryEnum salary { get; set; }

        private JobType type { get; set; }
        [Required]
        public string location { get; set; }
        public IndustryEnum industry { get; set; }
        public RequirementsEnum requirements { get; set; }

        public Job()
            : base()
        {
            name = string.Empty;
            description = string.Empty;
            salary = SalaryEnum.NONE;
            location = string.Empty;
            industry = IndustryEnum.NONE;
            requirements = RequirementsEnum.NONE;
            type = JobType.SEASONAL;
        }
    }
}
