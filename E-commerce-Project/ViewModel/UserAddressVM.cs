using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class UserAddressVM:UserAddress
    {
        [Required(ErrorMessage ="*")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*")]
        public string phone { get; set; }
    }
}