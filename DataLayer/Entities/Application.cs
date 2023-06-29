using DataLayer.Entities.Enums;
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
            this.Salary = 0;
        }

        public int JobId { get; set; }
        public Job Job { get; set; }
        public StudiesEnum Studies { get; set; }
        public IndustryEnum Industry { get; set; }
        public ExperienceEnum Experience { get; set; }
        public string MessageForEmployer { get; set; }

        public SalaryEnum Salary { get; set; }
    }


}
