using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Cupcakes.Models
{
    public class Bakery
    {
        [Key]
        public int BakeryId { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string BakeryName { get; set; }
        [Range(0, 4)]
        public int Quantity { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string Address { get; set; }
        public ICollection<Cupcake> Cupcakes { get; set; }
    }
}