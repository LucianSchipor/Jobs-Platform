using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataLayer.Entities
{
    public class BaseEntity
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
    }
}
