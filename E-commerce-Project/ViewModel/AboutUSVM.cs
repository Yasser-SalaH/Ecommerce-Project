using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class AboutUSVM:AboutUs
    {
        [Required(ErrorMessage ="*")]
        public string Vision { get; set; }
        [Required(ErrorMessage ="*")]
        public string Mission { get; set; }
        [Required(ErrorMessage ="*")]
        public string WhoAreWe { get; set; }
    }
}