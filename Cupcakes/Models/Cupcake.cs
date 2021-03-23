using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Cupcakes.Models
{
    public class Cupcake
    {
        [Required(ErrorMessage ="Please select a cupcake type")]
        [Display(Name ="Cupcake Type")]
        public int CupcakeID { get; set; }
        public CupcakeType? CupcakeType { get; set; }

        [Required(ErrorMessage = "Please select a cupcake description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Gluten Free")]
        public bool GlutenFree { get; set; }

        [Range(1,15)]
        [Required(ErrorMessage = "Please select a cupcake price")]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        [NotMapped]
        [Display(Name = "Cupcake Picture")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName{ get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }


        [Required(ErrorMessage = "Please select a Bakery")]
        public int? BakeryID { get; set; }
        public virtual Bakery Bakery { get; set; }
    }
}
