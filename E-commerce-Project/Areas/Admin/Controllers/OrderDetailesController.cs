using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_commerce_Project.DAL;

namespace E_commerce_Project.Areas.Admin.Controllers
{
    public class OrderDetailesController : Controller
    {
        OrderDetailesDAL obj = new OrderDetailesDAL();
        // GET: Admin/OrderDetailes
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Data = obj.GetAll().Where(z => z.OrderFK == id).ToList();
            return View(Data);
        }

    }
}
