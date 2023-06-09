using System.ComponentModel.DataAnnotations;

namespace Dreamer.Shared.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CitiesId { get; set; }
        [Required]
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Verified { get; set; }
        public string Description { get; set; }
        public byte[] Cover { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public bool Status { get; set; }
        public string Certificate { get; set; }
        public decimal Rating { get; set; }
        public decimal TotalRating { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
