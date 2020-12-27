using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class OrderVM:Order
    {
        [Required(ErrorMessage ="*")]
        public long TotalPrice { get; set; }
        [Required(ErrorMessage ="*")]
        public long UserAddressFK { get; set; }
        [Required(ErrorMessage ="*")]
        public long UserFK { get; set; }
        [Required(ErrorMessage ="*")]
        public long OrderNumber { get; set; }
    }
}