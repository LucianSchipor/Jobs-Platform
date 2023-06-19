using Jobs_Platform.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Platform.Data.Entities
{
    public class Job : BaseEntity
    {
        
        public string name { get; set; }
        public string description { get; set; }
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

        public string location { get; set; }
        public string industry { get; set; }   
        public Requirements requirements { get; set; }

        public Job()
            :base()
        {
            name = string.Empty;
            description = string.Empty;
            salary = 0;
            requirements = new Requirements();
            location = string.Empty;
            industry = string.Empty;
            type = 0;
        }
    }
}
