using E_commerce_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Project.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderDAL orderDAL = new OrderDAL();
        // GET: Admin/Order
        public ActionResult Index()
        {
            return View(orderDAL.GetALL());
        }
        public ActionResult OrderData()
        {
            return  PartialView(orderDAL.GetALL());

        }

    }

}