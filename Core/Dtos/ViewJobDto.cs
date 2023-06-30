using DataLayer.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jobs_Platform.Dtos
{
    public class ViewJobDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public SalaryEnum Salary { get; set; }
        public JobType type { get; set; }
        public string location { get; set; }
        public IndustryEnum industry { get; set; }
        public ExperienceEnum experience { get; set; }
    }
}
