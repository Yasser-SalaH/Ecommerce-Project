using E_commerce_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Project.Controllers
{
    public class ProductDetailesController : Controller
    {
        // GET: ProductDetailes
        ProductDAL productDAL = new ProductDAL();
        // GET: ProductDetails
        public ActionResult Index(long? id)
        {
            return View(productDAL.Getone(id)); 
        }
    }
}