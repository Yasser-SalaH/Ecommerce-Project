using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class ProductVM:Product
    {
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public long Price { get; set; }
        [Required(ErrorMessage ="*")]
        public string Image { get; set; }
        [Required(ErrorMessage ="*")]
        public string Decription { get; set; }
        [Required(ErrorMessage ="*")]
       [ Display(Name ="Caregory Name")]
        public long CatFK { get; set; }
        [Display(Name = "SubCaregory Name")]
        public string SubCategory { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name = "Brand Name")]
        public long BrandFK { get; set; }
    }
}