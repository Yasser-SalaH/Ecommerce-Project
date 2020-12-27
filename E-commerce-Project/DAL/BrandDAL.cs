using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;

namespace E_commerce_Project.DAL
{
    public class BrandDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(Brand brand)
        {
            try
            {
                if (brand != null)
                {
                    db.Brand.Add(brand);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Edit(Brand brand)
        {
            try
            {
                Brand obj = db.Brand.Where(z => z.ID == brand.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = brand.Name;
                    obj.Image = brand.Image;
                    obj.CreatedBy = brand.CreatedBy;
                    obj.CreationDate = DateTime.Now;
                    obj.UpdatedBy = brand.UpdatedBy;
                    obj.UpdatedDate =brand.UpdatedDate ;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
             catch(Exception e)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                Brand obj = db.Brand.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.Brand.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public Brand Getone(long id)
        {
            return db.Brand.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<Brand> GetAll()
        {
            return db.Brand.ToList();
        }
    }
}