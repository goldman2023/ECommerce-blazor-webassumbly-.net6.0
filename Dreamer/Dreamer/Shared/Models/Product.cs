using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dreamer.Shared.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int CitiesId { get; set; }
        public int AreaId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        public string UnitName { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string ShortDetails { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public bool IsNew { get; set; }
        public bool IsSale { get; set; }
        public string ProductType { get; set; }
        [Required]
        public string Image { get; set; }
        public string YoutubeLink { get; set; }
        public bool IsActive { get; set; }
        public bool IsSlider { get; set; }

        //Inventory
        //public string InventoryMethod { get; set; }
        //public int MinimumcartQty { get; set; }
        //public int MaximumcartQty { get; set; }
        //public int AllowQty { get; set; }
        //public bool NotReturnable { get; set; }
        //public string Warehouse { get; set; }
        //public bool IsGiftcard { get; set; }
        //public bool RecurringProduct { get; set; }
        //public string SearchEngine { get; set; }
        //public string MetaTitle { get; set; }
        //public string Metakeywords { get; set; }
        //public string MetaDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [NotMapped]
        public List<ProductView> Variants { get; set; } = new List<ProductView>();
        public List<ProductVariation> Addresses { get; set; } = new List<ProductVariation>();

    }
}
