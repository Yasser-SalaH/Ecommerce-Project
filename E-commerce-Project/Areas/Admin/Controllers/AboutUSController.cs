using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce_Project.DAL;
using E_commerce_Project.Models;
using E_commerce_Project.ViewModel;

namespace E_commerce_Project.Areas.Admin.Controllers
{
    public class AboutUSController : Controller
    {
        // GET: Admin/AboutUS
        // ceartion an object form DAL Class 
        AboutUSDAL USDAL = new AboutUSDAL();
        public ActionResult Index()
        {
            return View(USDAL.GetAll());
        }
        // partialview used to Show Data Of DataBase
        public ActionResult ShowAbout()
        {
            return PartialView(USDAL.GetAll());
        }
        // Partialveiw Used To Add About US 
        public PartialViewResult AddAbout()
        {
            ViewBag.FormName = "postAbout";
            return PartialView();
        }
        [HttpPost]
        // The Add Post
        public JsonResult PostAbout(AboutUSVM VM)
        {
            AboutUs us = new AboutUs()
            {
                Vision = VM.Vision,
                Mission = VM.Mission,
                WhoAreWe = VM.WhoAreWe,
                CreatedBy = 8,
                CreationDate = DateTime.Now
            };
            if (USDAL.Add(us))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        // partialView Used To Edit AboutUS
        public PartialViewResult EditAbout(long id)
        {
            var data = USDAL.GetOne(id);
            AboutUSVM vm = new AboutUSVM()
            {
                Vision = data.Vision,
                Mission = data.Mission,
                WhoAreWe = data.WhoAreWe,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.CreatedBy,
                UpdatedDate =data.UpdatedDate
            };
            ViewBag.FormName = "EditAbout";
            return PartialView("AddAbout", vm);
        }
        [HttpPost]
        // The Post Edit
        public JsonResult EditAbout(AboutUSVM vm)
        {
            AboutUs us = new AboutUs()
            {
                ID=vm.ID,
                Vision=vm.Vision,
                Mission=vm.Mission,
                WhoAreWe=vm.WhoAreWe,
                CreatedBy=vm.CreatedBy,
                CreationDate=vm.CreationDate,
                UpdatedBy=9,
                UpdatedDate=DateTime.Now
            };
            if (USDAL.Edit(us))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        // PartialView Show Detailes About US
        public PartialViewResult Detaile(long id)
        {
            var data = USDAL.GetOne(id);
            AboutUSVM obj = new AboutUSVM()
            {
                Vision=data.Vision,
                Mission=data.Mission,
                WhoAreWe=data.WhoAreWe,
                CreatedBy=data.CreatedBy,
                CreationDate=data.CreationDate
            };
            ViewBag.FormName = "Detaile";
            return PartialView("AddAbout", obj);
        }
        // Action Josn Deleted 
        public JsonResult DeleteAbout(long id)
        {
            if (USDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
    }
}