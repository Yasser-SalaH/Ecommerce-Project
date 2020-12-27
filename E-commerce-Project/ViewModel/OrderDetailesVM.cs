using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class OrderDetailesVM:OrderDetails
    {
        [Required(ErrorMessage ="*")]
        public long Price { get; set; }
        [Required(ErrorMessage ="*")]
        public long TotalPrice { get; set; }
        [Required(ErrorMessage ="*")]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name ="Order Name")]
        public long OrderFK { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name ="Product Name")]
        public long ProductFK { get; set; }
    }
}