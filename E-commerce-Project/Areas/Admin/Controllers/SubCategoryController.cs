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
    public class SubCategoryController : Controller
    {
        SubCategoryDAL SubCategoryDAL = new SubCategoryDAL();
        // GET: Admin/SubCategory
        public ActionResult Index()
        {
            return View(SubCategoryDAL.GetAll());
        }
        public PartialViewResult SubCategoryData()
        {
            return PartialView(SubCategoryDAL.GetAll());
        }
        public PartialViewResult AddSubCat()
        {
            ViewBag.FormName = "PostSubCat";
            return PartialView();
        }
        public JsonResult PostSubCat(SubCategoryVM VM)
        {
            string message = "";
            SubCategory sub = new SubCategory()
            {
                Name=VM.Name,
                CategoryFK=VM.CategoryFK,
                CreatedBy=9,
                CreationDate=DateTime.Now
               
            };
            if (SubCategoryDAL.Add(sub, out  message))
            {
                return Json(new { done = true,message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false,message }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult EditSubCat(long id)
        {
            var data = SubCategoryDAL.Getone(id);
            SubCategoryVM sub = new SubCategoryVM()
            {
                Name=data.Name,
                CategoryFK=data.CategoryFK,
                CreatedBy=data.CreatedBy,
                CreationDate=data.CreationDate,
                UpdatedBy=data.UpdatedBy,
                UpdatedDate=data.UpdatedDate,
            };
            ViewBag.FormName = "EditSubCat";
            return PartialView("AddSubCat", sub);
        }
        [HttpPost]
        public JsonResult EditSubCat(SubCategoryVM VM)
        {
            SubCategory sub = new SubCategory()
            {
                ID=VM.ID,
                Name=VM.Name,
                CategoryFK=VM.CategoryFK,
                CreatedBy = VM.CreatedBy,
                CreationDate = VM.CreationDate,
                UpdatedBy =8 ,
                UpdatedDate = DateTime.Now
            };
            if (SubCategoryDAL.Edit(sub))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult DetailesSubCat(long id)
        {
            var data = SubCategoryDAL.Getone(id);
            SubCategoryVM sub = new SubCategoryVM 
            { 
            Name=data.Name,
            CategoryFK=data.CategoryFK,
            CreatedBy=data.CreatedBy,
            CreationDate=data.CreationDate,
            UpdatedBy=data.UpdatedBy,
            UpdatedDate=data.UpdatedDate,
            };
            return PartialView("AddSubCat", sub);
        }
        public JsonResult DeleteSubCat(long id)
        {
            if (SubCategoryDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
    }
}