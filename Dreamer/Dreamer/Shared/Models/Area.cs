using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        [Required]
        public string AreaName { get; set; }
        public int CitiesId { get; set; }
    }
}
