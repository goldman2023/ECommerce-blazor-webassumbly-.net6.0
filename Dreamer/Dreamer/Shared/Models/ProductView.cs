using System.ComponentModel.DataAnnotations.Schema;

namespace Dreamer.Shared.Models
{
    public class ProductView
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
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
        public int SizeId { get; set; }
         public int BrandId { get; set; }
        public string HaveGram { get; set; }
        public string HaveKg { get; set; }
        public string HaveLeter { get; set; }
        public string HaveMl { get; set; }
        public string HavePcs { get; set; }
        public string ProductType { get; set; }
        public string Image { get; set; }
        public string YoutubeLink { get; set; }
        public bool IsActive { get; set; }
        public bool IsSlider { get; set; }



        public string AreaName { get; set; }
        public string CategoryName { get; set; }
        public string CitiyName { get; set; }
        public string SubcategoryName { get; set; }
        public string BrandName { get; set; }
        [NotMapped]
        public string NameWithRate => this.Name + " (" + this.SalePrice + ")";
    }
}
