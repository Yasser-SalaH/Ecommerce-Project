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
    public class ProductController : Controller
    {
        ProductDAL ProductDAL = new ProductDAL();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ProductData()
        {
            return PartialView(ProductDAL.GetAll());
        }
        public PartialViewResult AddProduct()
        {
            ViewBag.FormName = "PostProduct";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostProduct(ProductVM productVM)
        {
            string message;
            Product product = new Product()
            {
                Name = productVM.Name,
                Image = "",
                Decription = productVM.Decription,
                Price = productVM.Price,
                CatFK=productVM.CatFK,
                SubCatFK=productVM.SubCatFK,
                BrandFK=productVM.BrandFK,
                CreatedBy = 9,
                CreationDate=DateTime.Now,
            };
            ViewBag.FormName = "PostProduct";
            return Json(new { done = ProductDAL.Add(product , out message)
            , message, add = true }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult EditProduct(long id)
        {
            var data = ProductDAL.Getone(id);
            ProductVM obj = new ProductVM() { 
            ID=data.ID,
            Name=data.Name,
            Image=data.Image,
            Price=data.Price,
            Decription=data.Decription,
            CatFK=data.CatFK,
            SubCatFK=data.SubCatFK,
            BrandFK=data.BrandFK,
            CreatedBy=data.CreatedBy,
            CreationDate=data.CreationDate,
            UpdatedBy=data.UpdatedBy,
            UpdatedDate=data.UpdatedDate
            };
            ViewBag.FormName = "PostEditProduct";
            return PartialView("AddProduct", obj);
        }
        [HttpPost]
        public JsonResult PostEditProduct(ProductVM productVM)
        {
            string message;
            Product product = new Product() {
                ID = productVM.ID,
                Name = productVM.Name,
                Image = ProductDAL.Getone(productVM.ID).Image,
                Price = productVM.Price,
                Decription = productVM.Decription,
                CatFK = productVM.CatFK,
                SubCatFK = productVM.SubCatFK,
                BrandFK = productVM.BrandFK,
                CreatedBy = productVM.CreatedBy,
                CreationDate = productVM.CreationDate,
                UpdatedBy = 9,
                UpdatedDate = DateTime.Now
            };
            return Json(new { done = ProductDAL.Edit(product, out message), message ,edit= true},
                JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult DetailesProduct(long id)
        {
            var data = ProductDAL.Getone(id);
            ProductVM obj = new ProductVM()
            {
                ID = data.ID,
                Name = data.Name,
                Decription = data.Decription,
                Price = data.Price,
                CatFK = data.CatFK,
                SubCatFK = data.SubCatFK,
                BrandFK = data.BrandFK,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate,
            };
            ViewBag.FormName = "DetailesProduct";
            return PartialView("AddProduct", obj);
        }
        public JsonResult DeleteProduct(long id)
        {
            if (ProductDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSubCats(long id)
        {
            return Json(
                new SubCategoryDAL().GetAll().Where(z => z.CategoryFK == id).
                Select(z => new
                {
                    z.ID,
                    z.Name
                }).ToList()
                , JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult Uploadimage(long productID)
        {
            ViewBag.productID = productID;
            return PartialView();
        }
        [HttpPost]
        public ActionResult PostUploadimage(HttpPostedFileBase file,long productID)
        {
            string Message;
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/AttachMents/Products"), pic);
                // file is uploaded
                file.SaveAs(path);
                string Filepath = "/AttachMents/Products/"+pic;
                var product = ProductDAL.Getone(productID);
                if (product!=null)
                {
                    product.Image = Filepath;
                    product.UpdatedBy = 8;
                    product.UpdatedDate = DateTime.Now;
                    ProductDAL.Edit(product,out Message);
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