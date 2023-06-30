using DataLayer.Entities.Enums;
using DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Application : BaseEntity
    {

        public Application()
            : base()
        {
            this.Studies = 0;
            this.Industry = 0;
            this.Experience = 0;
            MessageForEmployer = string.Empty;
        }

        public int JobId { get; set; }
        public Job Job { get; set; }
        public StudiesEnum Studies { get; set; }
        public IndustryEnum Industry { get; set; }
        public ExperienceEnum Experience { get; set; }
        public string MessageForEmployer { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
    }


}
