using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class ColorVM:Color
    {
        [Required(ErrorMessage ="*")]
        [Display(Name ="Color Name")]
        public string Name { set; get; }
        [Required(ErrorMessage ="*")]
        public string Code { get; set; }

    }
}