using E_commerce_Project.DAL;
using E_commerce_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Project.Areas.Admin.Controllers
{
    public class UserAddressController : Controller
    {
        UserAddressDAL obj = new UserAddressDAL();
        // GET: Admin/UserAddress
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult UserAddressData()
        {
            return PartialView(obj.GetAll());
        }
        public PartialViewResult Form()
        {
            return PartialView();
        }
        public PartialViewResult DetailesUserAddress(long id)
        {
            var data = obj.Getone(id);
            UserAdressVM vM = new UserAdressVM() { 
             ID=data.ID,
             Address=data.Address,
             phone=data.phone,
             UserFK=data.UserFK,
             CreatedBy = data.CreatedBy,
             CreationDate = data.CreationDate,
             UpdatedBy = data.UpdatedBy,
             UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "DetailesUserAddress";
            return PartialView("Form", vM);
        }
        public JsonResult Delete(long id)
        {
            if (obj.Delete(id))
            {
                return Json(new {  done=true }, JsonRequestBehavior.AllowGet);
            }
                return Json(new {  done=false }, JsonRequestBehavior.AllowGet);
        }
    }
}