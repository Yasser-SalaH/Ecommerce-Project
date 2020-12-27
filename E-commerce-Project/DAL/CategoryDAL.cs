using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;
namespace E_commerce_Project.DAL
{
    public class CategoryDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(Category category)
        {
            try
            {
                if (category != null)
                {
                    db.Category.Add(category);
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
        public bool Edit(Category category)
        {
            try
            {
                Category obj = db.Category.Where(z => z.ID == category.ID).FirstOrDefault();
                if (obj!=null)
                {
                    obj.Name = category.Name;
                    obj.UpdatedBy = category.UpdatedBy;
                    obj.UpdatedDate = category.UpdatedDate;
                    obj.CreatedBy = category.CreatedBy;
                    obj.CreationDate = category.CreationDate;
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
                Category obj = db.Category.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.Category.Remove(obj);
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
        public Category Getone(long id)
        {
            return db.Category.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<Category> GetAll()
        {
            return db.Category.ToList();
        }
    }
}