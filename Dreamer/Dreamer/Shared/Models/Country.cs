using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
