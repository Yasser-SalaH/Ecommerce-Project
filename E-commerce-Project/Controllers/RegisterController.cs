using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce_Project.DAL;
using E_commerce_Project.Common1;
using E_commerce_Project.ViewModel;

namespace E_commerce_Project.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        UserDAl UserDAl = new UserDAl();
        public ActionResult Index()
        {
            ViewBag.User = Session["user"];
            return View();
        }
        public PartialViewResult Register()
        {
            ViewBag.Action = "PostUser";
            return PartialView();
        }
        public JsonResult PostUser(UserVM userVM)
        {
            string massage = "";
            var user = new User()
            {
                Name = userVM.Name,
                Email = userVM.Email,
                Phone = userVM.Phone,
                Address = userVM.Address,
                Password = userVM.Password,
                RoleFK = (int)CommonEnum.Role.Custoumer,
                CreationDate=DateTime.Now
            };
            var Ruselt = UserDAl.Add(user, out massage);
            if (Ruselt)
            {
                Session["user"] = user;
            }
            return Json(new { done =Ruselt,
                massage },
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult EmailExsist(string email)
        {
            return Json(!(UserDAl.getByEmail(email)==null),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit()
        {
            var user = (User)Session["user"];
            if (user==null)
            {
                return RedirectToAction("Index", "Home");
            }
            UserVM obj = new UserVM()
            {
                ID = user.ID,
                IsActive = user.IsActive,
                Name = user.Name,
                Password = user.Password,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email,
                UpdatedBy = user.UpdatedBy,
                CreationDate = user.CreationDate
            };
            ViewBag.Action = "PostEdit";
            return PartialView("Register", obj);
        }
        [HttpPost]
        public JsonResult PostEdit(UserVM userVM)
        {
            var message = "";
            var obj = new User()
            {
                IsActive = userVM.IsActive,
                ID = userVM.ID,
                Name = userVM.Name,
                Password = userVM.Password,
                Address = userVM.Address,
                Phone = userVM.Phone,
                Email = userVM.Email,
                UpdatedBy = ((User)Session["User"]).ID,
                UpdatedDate = DateTime.Now,
                CreationDate = userVM.CreationDate
            };
            var result = UserDAl.Edit(obj, out message);
            if ( result)
            {
                Session["User"] = UserDAl.Getone(userVM.ID);
            }
            return Json(new { done = result, message }, JsonRequestBehavior.AllowGet);
        }public PartialViewResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult Login(UserVM vM)
        {
            var user = new User()
            {
                Email=vM.Email,
                Password=vM.Password
            };
            string message = "";
            bool result;
            if (Session["user"]!=null)
            {
                message = "Aready Logined";
                result = false;
            }
            else
            {
                result = UserDAl.Login(ref user, out message);
                if (result)
                {
                    Session["user"] = user;
                }
            }
            return Json(new { done = result, message, name = user.Name }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
          return  RedirectToAction("index", "Home");
        }

    }
}