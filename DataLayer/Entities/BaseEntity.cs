using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataLayer.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
