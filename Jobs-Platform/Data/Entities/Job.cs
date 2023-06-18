using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Platform.Data.Entities
{
    public class Job
    {
        [Key] public int id { get; set; }
        public string name { get; set; }
        private string description { get; set; }
        private int salary { get; set; }

        private enum TypeEnum
        {
            SEASONAL = 0,
            PRACTICE = 1, 
            INTERSHIP = 2, 
            PART_TIME = 3,
            FULL_TIME = 4,
        }
        private TypeEnum type { get; set; }
        private List<string> location { get; set; }
        private string industry { get; set; }   
        public Requirements requirements { get; set; }

        public Job()
        {
            id = -1;
            name = string.Empty;
            description = string.Empty;
            salary = 0;
            requirements = new Requirements();
            location = new List<string>();
            industry = string.Empty;
            type = 0;
        }
    }
}
