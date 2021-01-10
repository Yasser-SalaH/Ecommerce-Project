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
        AutherizationDAL authorization = new AutherizationDAL();
        ContactMessegaDAL contactMessageDAL = new ContactMessegaDAL();

        // GET: Admin/ContactMessage
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        public PartialViewResult Form()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView();
        }
        public PartialViewResult ContactMessageTable()
        {
            //if (!authorization.Admin((User)Session["User"]))
            //{
            //    return PartialView("ErrorView");
            //}
            return PartialView(contactMessageDAL.GetAll());
        }
        public PartialViewResult Details(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            var contactMessage = contactMessageDAL.GetOne(id);
            var obj = new ContactMessageVM()
            {
                ID = contactMessage.ID,
                Email = contactMessage.Email,
                Answer = contactMessage.Answer,
                CreatedBy = contactMessage.CreatedBy,
                CreationDate = contactMessage.CreationDate,
                Message = contactMessage.Message,
                Name = contactMessage.Name
            };
            return PartialView("Form", obj);
        }

        [HttpPost]
        public JsonResult Answered(long id)
        {
            var obj = contactMessageDAL.GetOne(id);
            obj.Answer = true;
            string message;
            return Json(
                new
                {
                    done = contactMessageDAL.Edit(obj, out message),
                    message
                }
                , JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Delete(long id)
        {
            string message;
            return Json(
                new
                {
                    done = contactMessageDAL.Delete(id, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }
    }
}