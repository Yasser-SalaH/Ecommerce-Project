using E_commerce_Project.DAL;
using E_commerce_Project.Models;
using E_commerce_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Project.Areas.Admin.Controllers
{
    public class TestimonialsController : Controller
    {
        // GET: Admin/Testimon1ials
        TestimonialsDAL dAL = new TestimonialsDAL();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TestMonDetailes()
        {
            return PartialView(dAL.GetAll());
        }
        public PartialViewResult AddTestMonials()
        {
            ViewBag.FormName = "PostAdd";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostAdd(TestiMonialsVM monialsVM)
        {
            var Message = "";
            TestMonials test = new TestMonials
            {
                FeedBack=monialsVM.FeedBack,
                Image = "",
                IsConfirm=false,
                UserFK = 9,
                CreatedBy = 9,
                CreationDate = DateTime.Now,
            };
            ViewBag.FormName = "PostAdd";
            var reuslt = dAL.Add(test, out Message);
            if (reuslt)
            {
                return Json(new { done = reuslt, Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = reuslt, Message }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(long id)
        {
            var Message = "";
            var result = dAL.GetOne(id);
            if (result)
            {
                return Json(new { done = result,Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { done = result,Message }, JsonRequestBehavior.AllowGet);
        }
    }
}