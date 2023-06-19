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
        public int salary { get; set; }

        private enum TypeEnum
        {
            SEASONAL = 0,
            PRACTICE = 1,
            INTERSHIP = 2,
            PART_TIME = 3,
            FULL_TIME = 4,
        }
        private TypeEnum type { get; set; }
        [Required]
        public string location { get; set; }
        public string industry { get; set; }
        public string requirements { get; set; }

        public Job()
            : base()
        {
            name = string.Empty;
            description = string.Empty;
            salary = 0;
            location = string.Empty;
            industry = string.Empty;
            requirements = string.Empty;
            type = 0;
        }
    }
}
