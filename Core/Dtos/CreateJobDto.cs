using DataLayer.Entities.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CreateJobDto
    {
        public string description { get; set; }
        public SalaryEnum salary { get; set; }
        private JobType type { get; set; }
        public string location { get; set; }
        public IndustryEnum industry { get; set; }
        public ExperienceEnum experience { get; set; }

        public CreateJobDto()
        {
            description = string.Empty;
            salary = 0;
            location = string.Empty;
            type = 0;
            industry = 0;
            experience = 0;
        }
    }
}
