using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        public string link { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
