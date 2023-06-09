using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamer.Shared.Models
{
    public class ProductVariation
    {
        [Key]
        public int ProductvariationId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Variation { get; set; }
        public decimal Stock { get; set; }
    }
}
