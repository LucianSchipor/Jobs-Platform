using DataLayer.Entities.Enums;
using DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Application : BaseEntity
    {

        public Application()
            : base()
        {
            this.Application_id = base.Id;
            this.Studies = 0;
            this.Industry = 0;
            this.Experience = 0;
            MessageForEmployer = string.Empty;
        }

        [NotMapped]
        public int Application_id { get; set; }
        public int JobId { get; set; }
        public StudiesEnum Studies { get; set; }
        public IndustryEnum Industry { get; set; }
        public ExperienceEnum Experience { get; set; }
        public string MessageForEmployer { get; set; }
        public string Email { get; set; }
    }


}
