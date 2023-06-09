using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamer.Shared.Models
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
