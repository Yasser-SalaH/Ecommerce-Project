using E_commerce_Project.DAL;
using E_commerce_Project.Models;
using E_commerce_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Project.Controllers
{
    public class UserController : Controller
    {
        UserDAl userDAl = new UserDAl();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult UserData()
        {
            var obj = (User)Session["user"];
            if(obj==null)
            {
                return PartialView();
            }
            return PartialView(userDAl.Getone(obj.ID));
        }
        public PartialViewResult Edit()
        {
            var obj = (User)Session["user"];
            UserVM user = new UserVM()
            {
                ID=obj.ID,
                Name = obj.Name,
                Password=obj.Password,
                Email=obj.Email,
                Address=obj.Address,
                Phone=obj.Phone,
                CreatedBy=obj.CreatedBy,
                CreationDate=obj.CreationDate,
            };
            return PartialView(obj);
        }
        [HttpPost]
        public JsonResult Edit(UserVM vM)
        {
            var message = "";
            var User = new User()
            {
                ID = vM.ID,
                Name = vM.Name,
                Password = vM.Password,
                Email = vM.Email,
                Address = vM.Address,
                Phone = vM.Phone,
                CreatedBy = vM.CreatedBy,
                CreationDate = vM.CreationDate,
                UpdatedDate=DateTime.Now,
                UpdatedBy=vM.UpdatedBy,
            };
            var reuslt = userDAl.Edit(User, out message);
            if (reuslt)
            {
                return Json(new { done = reuslt ,message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = reuslt,message }, JsonRequestBehavior.AllowGet);
        }
    }
}