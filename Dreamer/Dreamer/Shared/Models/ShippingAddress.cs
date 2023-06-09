using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class ShippingAddress
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int CitiesId { get; set; }
        public string AddressName { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
