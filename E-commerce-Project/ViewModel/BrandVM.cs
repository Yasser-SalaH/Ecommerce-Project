using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class BrandVM:Brand
    {
        [Required(ErrorMessage ="*")]   
        [Display(Name ="BrandName")]
        public string Name { set; get; }
        [Required(ErrorMessage = "*")]
        public string Image { get; set; }

    }
}