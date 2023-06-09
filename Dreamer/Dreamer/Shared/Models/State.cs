using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
