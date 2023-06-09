using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        //[Required]
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
