using System.ComponentModel.DataAnnotations;

namespace Jobs_Platform.DataLayer.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
