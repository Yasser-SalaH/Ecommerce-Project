using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class TestiMonialsVM:TestMonials
    {
        [Required(ErrorMessage = "*")]
        public string Image { get; set; }
        [Required(ErrorMessage = "*")]

        public string FeedBack { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "User Name")]
        public long UserFK { get; set; }
    }
}