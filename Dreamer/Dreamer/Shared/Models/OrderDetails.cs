using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class OrderDetails
    {
        [Key]
        public long OrderDetailsId { get; set; }
        public long OrderMasterId { get; set; }
        public int ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
