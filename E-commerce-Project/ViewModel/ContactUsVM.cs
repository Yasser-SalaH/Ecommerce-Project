using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class ContactUsVM:ContactUs
    {
       [Required(ErrorMessage ="*")]
        public string Email { get; set; }
       [Required(ErrorMessage ="*")]
        public string address { get; set; }
       [Required(ErrorMessage ="*")]
        public string facebook { get; set; }
       [Required(ErrorMessage ="*")]
        public string phone { get; set; }
    }
}