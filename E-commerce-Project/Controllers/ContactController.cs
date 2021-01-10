using E_commerce_Project.DAL;
using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Project.Controllers
{
    public class ContactController : Controller
    {
        ContactMessegaDAL contactMessageDAL =
            new ContactMessegaDAL();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactMessage()
        {
            return PartialView();
        }
        public ActionResult ContactUs()
        {

            return PartialView(new ContactUSDAL().GetOne(17));
        }
        public PartialViewResult Map()
        {
            return PartialView();
        }
        public JsonResult AddContactMessage(string Name, string Email, string Message)
        {
            string message;
            var obj = new ContactMesaage()
            {
                CreatedBy =9,
                CreationDate = DateTime.Now,
                Email = Email,
                Message = Message,
                Name = Name,
                Answer = false
            };
            return Json(
                new
                {
                    done = contactMessageDAL.Add(obj, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }
    }
}