using System.ComponentModel.DataAnnotations;

namespace Jobs_Platform.Dtos
{
    public class JobAddDto
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public int salary { get; set; }

    }
}
