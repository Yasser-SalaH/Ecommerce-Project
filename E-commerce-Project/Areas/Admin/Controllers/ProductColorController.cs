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
    public class ProductColorController : Controller
    {
        // GET: Admin/ProductColor
        ProductColorDAL dAL = new ProductColorDAL();
        public ActionResult Index()
        {
            return View(dAL.GetAll());
        }
        public ActionResult ShowProductColor()
        {
            return View(dAL.GetAll());
        }
        public PartialViewResult AddProductColor()
        {
            ViewBag.FormName = "PostProductColor";
            return PartialView();
        }
        public JsonResult PostProductColor(ProductColorVM vm)
        {
            ProductColor obj = new ProductColor()
            {
                Image = vm.Image,
                ProductFK = vm.ProductFK,
                ColorFk = vm.ColorFk,
                CreatedBy = 8,
                CreationDate = DateTime.Now
            };
            string massage="";
            if (dAL.Add(obj,out massage))
            {
                return Json(new { done = true, massage }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false, massage }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult EditProductColor(long id)
        {
            var data = dAL.GetOne(id);
            ProductColorVM vM = new ProductColorVM()
            {
                ID = data.ID,
                Image = data.Image,
                ProductFK = data.ProductFK,
                ColorFk = data.ColorFk,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "EditProductColor";
            return PartialView("AddProductColor", vM);
        }
        [HttpPost]
        public JsonResult EditProductColor(ProductColorVM vM)
        {
            ProductColor obj = new ProductColor()
            {
                 Image = vM.Image,
                ProductFK = vM.ProductFK,
                ColorFk = vM.ColorFk,
                CreatedBy = vM.CreatedBy,
                CreationDate = vM.CreationDate,
                UpdatedBy = 8,
                UpdatedDate = DateTime.Now
            };
            if (dAL.Edit(vM))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProductColor(long id)
        {
            if (dAL.Delete(id))
            {
                return Json(new { done=true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { done = true }, JsonRequestBehavior.AllowGet);
        }
    }
}