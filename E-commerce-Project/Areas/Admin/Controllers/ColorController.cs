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
    public class ColorController : Controller
    {
        ColorDAL colorDAL = new ColorDAL();
        // GET: Admin/Color
        public ActionResult Index()
        {
            return View(colorDAL.GetAll());
        }
        public PartialViewResult ColorData()
        {
            return PartialView(colorDAL.GetAll());
        }
        public PartialViewResult AddColor()
        {
            ViewBag.FormName = "PostColor";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostColor(ColorVM colorVM)
        {
            Color color = new Color()
            {
                Name = colorVM.Name,
                Code = colorVM.Code,
                CreatedBy = 9,
                CreationDate = DateTime.Now,
            };
            if (colorDAL.Add(color))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult EditColor(long id)
        {
            var data = colorDAL.Getone(id);
            ColorVM obj = new ColorVM()
            {
                ID = data.ID,
                Name = data.Name,
                Code = data.Code,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
            };
            ViewBag.FormName = "EditColor";
            return PartialView("AddColor", obj);
        }
        [HttpPost]
        public JsonResult EditColor(ColorVM colorVM)
        {
            Color color = new Color()
            {
                ID = colorVM.ID,
                Name = colorVM.Name,
                Code = colorVM.Code,
                CreatedBy = colorVM.CreatedBy,
                CreationDate = colorVM.CreationDate,
                UpdatedBy=9,
                UpdatedDate=DateTime.Now
            };
            if (colorDAL.Edit(color))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteColor(long id)
        {
            if (colorDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult DetailesColor(long id)
        {
            var data = colorDAL.Getone(id);
            ColorVM obj = new ColorVM() {
                ID = data.ID,
                Name = data.Name,
                Code=data.Code,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate,
            };
            ViewBag.FormName = "DetailesColor";
            return PartialView("AddColor", obj);
        }
    }
}