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
    public class BrandController : Controller
    {
        BrandDAL brandDAL = new BrandDAL();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View(brandDAL.GetAll());
        }

        public PartialViewResult BrandData()
        {
            return PartialView(brandDAL.GetAll());
        }
        public PartialViewResult AddBrand()
        {
            ViewBag.FormName = "PostBrand";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostBrand(BrandVM brandVM)
        {
            Brand brand = new Brand()
            {
                Name = brandVM.Name,
                Image = "",
                CreatedBy = 9,
                CreationDate = DateTime.Now
            };
            if (brandDAL.Add(brand))
            {
                return Json(new { done = true}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
       
        public PartialViewResult EditBrand(long id)
        {
            var data = brandDAL.Getone(id);
            BrandVM obj = new BrandVM()
            {
                ID = data.ID,
                Name = data.Name,
                Image = data.Image,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate,
            };
            ViewBag.FormName = "EditBrand";
            return PartialView("AddBrand", obj);
        }
        [HttpPost]
        public JsonResult EditBrand(BrandVM brandVM)
        {
            Brand brand = new Brand()
            {
                ID = brandVM.ID,
                Name = brandVM.Name,
                Image = "",
                CreatedBy = brandVM.CreatedBy,
                CreationDate = brandVM.CreationDate,
                UpdatedDate= DateTime.Now,
                UpdatedBy=9,
            };
            if (brandDAL.Edit(brand))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult DetailesBrand(long id)
        {
            var data = brandDAL.Getone(id);
            BrandVM obj = new BrandVM()
            {
                ID = data.ID,
                Name = data.Name,
                Image = data.Image,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate,
            };
            ViewBag.FormName = "DatilesBrand";
            return PartialView("AddBrand", obj);
        }
        public JsonResult DeleteBrand(long id)
        {
            if (brandDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult Uploadimage(long BrandID)
        {
            ViewBag.BrandID = BrandID;
            return PartialView();
        }
        [HttpPost]
        public ActionResult PostUploadimage(HttpPostedFileBase file ,long BrandID)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/AttachMents/Brands"), pic);
                // file is uploaded
                file.SaveAs(path);
                string FilePath = "/AttachMents/Brands/" + pic;
                var brand = brandDAL.Getone(BrandID);
                if (brand!=null)
                {
                    brand.Image = FilePath;
                    brand.UpdatedBy = 9;
                    brand.UpdatedDate = DateTime.Now;
                    brandDAL.Edit(brand);
                }
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB


            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index");
        }
    }
}