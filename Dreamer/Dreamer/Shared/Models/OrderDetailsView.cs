namespace Dreamer.Shared.Models
{
    public class OrderDetailsView
    {
        public long OrderDetailsId { get; set; }
        public long OrderMasterId { get; set; }
        public int ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public int OrderPending { get; set; }
        public int OrderCancel { get; set; }
        public int OnGoing { get; set; }
        public decimal TotalIncome { get; set; }
    }
}
