using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dreamer.Shared.Models
{
    public class OrderMaster
    {
        [Key]
        public long OrderMasterId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        [Required]
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public string PaymentType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal ExtraCharge { get; set; }
        public decimal Tax { get; set; }
        public string CancelReason { get; set; }
        public string IsActive { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        //Shipping
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingEmailId { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }



        [NotMapped]
        public List<OrderDetails> listOrder { get; set; } = new List<OrderDetails>();
    }
}
