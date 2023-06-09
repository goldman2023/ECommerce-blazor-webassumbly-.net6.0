namespace Dreamer.Shared
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string EditionName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Photo { get; set; }
        public decimal Quantity { get; set; }
        public int UserId { get; set; }
        public string CartStatus { get; set; }
    }
}
