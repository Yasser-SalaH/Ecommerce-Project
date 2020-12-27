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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        CategoryDAL CategoryDAL = new CategoryDAL();
        public ActionResult Index()
        {
            return View(CategoryDAL.GetAll());
        }
        public PartialViewResult CategoryData()
        {
            return PartialView(CategoryDAL.GetAll());
        }
        public PartialViewResult AddCategory()
        {
            ViewBag.FormName = "PostCategory";
            return PartialView();
        }
        public JsonResult PostCategory(CategoryVM categoryVM)
        {
            Category category = new Category()
            {
                Name = categoryVM.Name,
                CreationDate=DateTime.Now,
                CreatedBy=9
            };
            if (CategoryDAL.Add(category))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult EditCategory(long id)
        {
            var data = CategoryDAL.Getone(id);
            CategoryVM categoryVM = new CategoryVM()
            {
                ID = data.ID,
                Name = data.Name,
                CreatedBy = data.CreatedBy,
                CreationDate=data.CreationDate,
                UpdatedBy=data.UpdatedBy,
                UpdatedDate=data.UpdatedDate
            };
            ViewBag.FormName = "EditCategory";
            return PartialView("AddCategory", categoryVM);
        }
        [HttpPost]
        public JsonResult EditCategory(CategoryVM categoryVM)
        {
            Category category = new Category()
            {
                ID=categoryVM.ID,
                Name=categoryVM.Name,
                CreatedBy=categoryVM.CreatedBy,
                CreationDate=categoryVM.CreationDate,
                UpdatedDate=DateTime.Now,
                UpdatedBy=9
            };
            if (CategoryDAL.Edit(category))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);

        }
        public PartialViewResult DetailsCategory(long id)
        {
            var data = CategoryDAL.Getone(id);
            CategoryVM categoryvm = new CategoryVM()
            {
                ID=data.ID,
                Name=data.Name,
                CreatedBy=data.CreatedBy,
                CreationDate=data.CreationDate,
                UpdatedBy=data.UpdatedBy,
                UpdatedDate=data.UpdatedDate
            };
            ViewBag.FormName = "DetailsCategory";
            return PartialView("AddCategory", categoryvm);

        }
        public JsonResult DeleteCategory(long id)
        {
            if (CategoryDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
    }
}