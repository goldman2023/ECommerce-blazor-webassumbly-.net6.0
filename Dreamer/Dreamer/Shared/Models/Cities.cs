using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class Cities
    {
        [Key]
        public int CitiesId { get; set; }
        [Required]
        public string CitiyName { get; set; }
        public int StateId { get; set; }
    }
}
