using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;
namespace E_commerce_Project.DAL
{
    public class ProductDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        // Function Used to Add Product.
        public bool Add(Product product,out string message)
        {
            try
            {
                if (product!=null)
                {
                    db.Product.Add(product);
                    db.SaveChanges();
                    message = "Added Successfuly"; 
                    return true;
                }
                message = "Product Empty";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Edit(Product product,out string Message)
        {
            Product obj = db.Product.Where(z => z.ID == product.ID).FirstOrDefault();
            try
            {
                if (obj!=null)
                {
                    obj.Name = product.Name;
                    obj.Image = product.Image;
                    obj.Price = product.Price;
                    obj.Decription = product.Decription;
                    obj.SubCatFK = product.SubCatFK;
                    obj.CatFK = product.CatFK;
                    obj.BrandFK = product.BrandFK;
                    obj.CreatedBy = product.CreatedBy;
                    obj.CreationDate = DateTime.Now;
                    obj.UpdatedBy = product.UpdatedBy;
                    obj.UpdatedDate = product.UpdatedDate;
                    db.SaveChanges();
                    Message = "Added SuccessFully";
                    return true;
                }
                Message = "Product Empty";
                return false;
            }
            catch (Exception e)
            {
                Message = e.Message;
                return false;
            }
        }
        public bool Delete(long id)
        {
            Product obj = db.Product.Where(z => z.ID == id).FirstOrDefault();
            try
            {
                if (obj!=null)
                {
                    db.Product.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public Product Getone(long? id)
        {
            if (id == null)
            {
                return null;
            }

            return db.Product.Where(z => z.ID == id).FirstOrDefault();
        }
       // public List<Product> GetAll()
       // {
           // return db.Product.ToList();
       // }
        public List<Product> FilterByBrand(long brandID)
        {
            return GetAll().Where(z => z.BrandFK == brandID).ToList();
        }
        public List<Product> FilterByCategory(long categoryID)
        {
            return GetAll().Where(z => z.CatFK == categoryID).ToList();
        }
        public List<Product> GetAll()
        {
            return db.Product.OrderByDescending(z => z.ID).ToList();
        }
        public List<Product> FilterByPrice(long price)
        {
            return GetAll().Where(z => z.Price == price).ToList();
        }
        public List<Product> FilterByColor(long id)
        {
            var items = new ProductColorDAL().GetAll().
                Where(z => z.ColorFk == id).Select(z => z.ProductFK).ToList();
            List<Product> products = new List<Product>();
            foreach (var item in items)
            {
                products.Add(new ProductDAL().Getone(item));
            }
            return products;
        }
    }
}