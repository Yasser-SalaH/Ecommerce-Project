using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce_Project.DAL;

namespace E_commerce_Project.Controllers
{

    public class HomeController : Controller
    {
        ProductDAL ProductDAL = new ProductDAL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Banner()
        {
            var list = ProductDAL.GetAll().OrderByDescending(z => z.ID).Take(3).ToList();
            return PartialView(list);
        }
        public ActionResult NewProduct()
        {
            var list = ProductDAL.GetAll().OrderByDescending(z => z.ID).Take(10).ToList();
            return PartialView(list);
        }
        public ActionResult Product()
        {
            var list = ProductDAL.GetAll().OrderByDescending(z => z.OrderDetails.Count()).Take(10).ToList();
            return PartialView(list);
        }
        public PartialViewResult Brand()
        {
            BrandDAL brandDAL = new BrandDAL();
            var list = brandDAL.GetAll();
            return PartialView(list);
        }
      public PartialViewResult CategoryProduct()
        {
            var list = ProductDAL.GetAll();
            return PartialView(list);
        }
    }
}