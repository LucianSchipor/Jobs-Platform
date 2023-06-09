﻿using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public JobType type { get; set; }
        [Required]
        public string location { get; set; }
        public IndustryEnum industry { get; set; }
        
        public ExperienceEnum experience { get; set; }


        public Job()
            : base()
        {
            name = string.Empty;
            description = string.Empty;
            salary = SalaryEnum.NONE;
            location = string.Empty;
            industry = IndustryEnum.NONE;
            type = JobType.SEASONAL;
        }
    }
}
