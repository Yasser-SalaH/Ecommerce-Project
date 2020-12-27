using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class CategoryVM:Category
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Category Name")]
        public string Name { set; get; }
    }
}