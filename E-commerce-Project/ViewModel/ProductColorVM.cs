using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.ViewModel
{
    public class ProductColorVM: ProductColor
    {
        [Required(ErrorMessage ="*")]
        public string Image { get; set; }
        [Required(ErrorMessage ="*")]
        public long ProductFK { get; set; }
        [Required(ErrorMessage = "*")]
        public long ColorFk { get; set; }
    }
}