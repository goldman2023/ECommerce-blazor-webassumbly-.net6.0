using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
