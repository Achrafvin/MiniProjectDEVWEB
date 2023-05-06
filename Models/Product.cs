using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class Product
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Required]
        [Key]
        public int IdProd { get; set; }

        [Display(Name = "Nom Produit"), Required]
        [StringLength(50)]
        public string Nom { get; set; }
        [Display(Name = "Type Produit"), Required]
        public string TypeProd { get; set; }
        [Display(Name = "Prix"), Required]
        public float Price { get; set; }
        [Display(Name = "Quantité"), Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]

        public int Qstock { get; set; }

        public DateTime dAjoute{ get; set;}


        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required]
        public string Image { get; set; }

       public string ErrorMessage { get; set; }
    }
}