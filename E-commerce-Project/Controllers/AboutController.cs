using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Project.Controllers
{
    public class AboutController : Controller
    {
        // GET: AboutUS
        public ActionResult Index()
        {
            return View(new DAL.AboutUSDAL().GetAll().FirstOrDefault());
        }
    }
}