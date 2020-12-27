using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;

namespace E_commerce_Project.DAL
{
    public class ProductColorDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(ProductColor productColor,out string massage)
        {
            try
            {
                if (productColor!=null)
                {
                    db.ProductColor.Add(productColor);
                    db.SaveChanges();
                    massage = "Added successfuly";
                    return true;
                }
                massage = "productColor Empty";
                return false;
            }
            catch (Exception e)
            {
                massage = e.Message;
                return false;
            }
        }
        public bool Edit(ProductColor productColor)
        {
            try
            {
                ProductColor obj = db.ProductColor.Where(z => z.ID == productColor.ID).FirstOrDefault();
                if (obj!=null)
                {
                    obj.Image = productColor.Image;
                    obj.ProductFK = productColor.ProductFK;
                    obj.ColorFk = productColor.ColorFk;
                    obj.CreatedBy = productColor.CreatedBy;
                    obj.CreationDate = productColor.CreationDate;
                    obj.UpdatedBy = productColor.UpdatedBy;
                    obj.UpdatedDate = productColor.UpdatedDate;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                ProductColor obj = db.ProductColor.Where(z => z.ID == id).FirstOrDefault();
                if (obj!=null)
                {
                    db.ProductColor.Remove(obj);
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
        public ProductColor GetOne(long id)
        {
            return db.ProductColor.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<ProductColor> GetAll()
        {
            return db.ProductColor.ToList();
        }
    }
}