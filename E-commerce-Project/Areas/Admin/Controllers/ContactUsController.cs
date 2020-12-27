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
    public class ContactUsController : Controller
    {
        ContactUSDAL USDAL = new ContactUSDAL();
        // GET: Admin/ContactUs
        public ActionResult Index()
        {
            return View(USDAL.GetAll());
        }
        public ActionResult ContactUSData()
        {
            return View(USDAL.GetAll());
        }
        public PartialViewResult AddContactUS()
        {
            ViewBag.FormName = "PostContactUS";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostContactUS(ContactUsVM usVM)
        {
            ContactUs contact = new ContactUs()
            {
                Email=usVM.Email,
                facebook=usVM.facebook,
                phone=usVM.phone,
                address=usVM.address,
                CreatedBy=8,
                CreationDate=DateTime.Now
            };
            if (USDAL.Add(contact))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);

        }
        public PartialViewResult EditUS(long id)
        {
            var data = USDAL.GetOne(id);
            ContactUsVM obj = new ContactUsVM()
            {
                Email = data.Email,
                facebook = data.facebook,
                phone = data.phone,
                address = data.address,
                CreatedBy = 8,
                CreationDate = DateTime.Now
            };
            ViewBag.FormName = "EditUS";
            return PartialView("AddContactUS", obj);
        }
        [HttpPost]
        public JsonResult EditUS(ContactUsVM vM)
        {
            ContactUs contact = new ContactUs()
            {
                ID=vM.ID,
                Email = vM.Email,
                facebook = vM.facebook,
                phone = vM.phone,
                address = vM.address,
                CreatedBy = vM.CreatedBy,
                CreationDate = vM.CreationDate,
                UpdatedBy = 9,
                UpdatedDate =DateTime.Now
            };
            if (USDAL.Edit(contact))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult DetailesUS(long id)
        {
            var data = USDAL.GetOne(id);
            ContactUsVM obj = new ContactUsVM()
            {
                ID=data.ID,
                Email=data.Email,
                facebook = data.facebook,
                phone = data.phone,
                address = data.address,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate =data.UpdatedDate
            };
            ViewBag.FormName = "DetailesUS";
            return PartialView("AddContactUS", obj);
        }
        public JsonResult DeleteUS(long id)
        {
            if (USDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }



    }
}