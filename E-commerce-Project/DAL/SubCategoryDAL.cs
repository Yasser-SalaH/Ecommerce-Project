using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;
namespace E_commerce_Project.DAL
{
    public class SubCategoryDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(SubCategory subCategory,out string message)
        {
            try
            {
                if (subCategory != null)
                {
                    if (GetByName(subCategory.Name)!=null)
                    {
                        message = "SubCategory Exist";
                        return false;
                    }
                    db.SubCategory.Add(subCategory);
                    db.SaveChanges();
                    message = "Added Successfuly";
                    return true;
                }
                message = "SubCategory Empty";
                return false;

            }
            catch(Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Edit(SubCategory subCategory)
        {
            try
            {
                SubCategory obj = db.SubCategory.Where(z => z.ID == subCategory.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = subCategory.Name;
                    obj.CategoryFK = subCategory.CategoryFK;
                    obj.UpdatedBy = subCategory.UpdatedBy;
                    obj.UpdatedDate = subCategory.UpdatedDate;
                    obj.CreatedBy = subCategory.CreatedBy;
                    obj.CreationDate = subCategory.CreationDate;
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
                SubCategory obj = db.SubCategory.Where(z => z.ID == id).FirstOrDefault();
                if (obj!=null)
                {
                    db.SubCategory.Remove(obj);
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
        public SubCategory Getone(long id)
        {
            return db.SubCategory.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<SubCategory> GetAll()
        {
            return db.SubCategory.ToList();
        }
        public SubCategory GetByName(string name)
        {
            return db.SubCategory.Where(z => z.Name == name).FirstOrDefault();
        }
    }
}