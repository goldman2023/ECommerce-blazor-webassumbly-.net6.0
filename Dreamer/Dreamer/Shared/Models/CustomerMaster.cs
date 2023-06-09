using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class CustomerMaster
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
