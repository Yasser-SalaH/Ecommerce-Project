using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce_Project.DAL;
using E_commerce_Project.ViewModel;

namespace E_commerce_Project.Areas.Admin.Controllers
{
    public class ContactMessageController : Controller
    {
        ContactMessegaDAL dAL = new ContactMessegaDAL();
        // GET: Admin/ContactMessage
        public ActionResult Index()
        {
            return View(dAL.GetALL());
        }
        public PartialViewResult ContactMsg()
        {
            return PartialView(dAL.GetALL());
        }
        public PartialViewResult AddContactMsg()
        {
            ViewBag.FormName = "AddContactMsg";
            return PartialView();
        }
        public PartialViewResult DetailsContactMessage(long id)
        {
            var data = dAL.Getone(id);
            ContactMessageVM obj = new ContactMessageVM()
            {
                ID = data.ID,
                Email = data.Email,
                Name = data.Name,
                Message = data.Message,
                CreatedBy = (Int32)data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = (Int32)data.UpdatedBy,
                UpdatedDate = (DateTime)data.UpdatedDate,
                Answer = data.Answer
            };
            ViewBag.FormName = "DetailsContactMessage";

            return PartialView("AddContactMsg", obj);
        }
        public PartialViewResult IsAnswered(long id)
        {
            var data = dAL.Getone(id);
            ContactMessageVM obj = new ContactMessageVM()
            {
                ID = data.ID,
                Email = data.Email,
                Name = data.Name,
                Message = data.Message,
                CreatedBy = (Int32)data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = (Int32)data.UpdatedBy,
                UpdatedDate = (DateTime)data.UpdatedDate,
                Answer = data.Answer
            };
            ViewBag.FormName = "IsAnswered";
            return PartialView("AddContactMsg", obj);
        }
        [HttpPost]
        public JsonResult IsAnswered(ContactMessageVM contactvm)
        {
            ContactMesaage contact = new ContactMesaage()
            {
                ID = contactvm.ID,
                Answer = contactvm.Answer
            };
            if (dAL.Edit(contact))
            {
                TempData["Edited"] = "Edited Successfully";

                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteContactMessage(long id)
        {
            if (dAL.Delete(id))
            {
                //viewbag Deleted successfully
                TempData["Deleted"] = "Deleted Successsfully";
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
                //TempData["added"] = true;
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
    }   
}