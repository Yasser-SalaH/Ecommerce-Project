using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;

namespace E_commerce_Project.DAL
{
    public class ColorDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(Color color)
        {
            try
            {
                if (color != null)
                {
                    db.Color.Add(color);
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
        public bool Edit(Color color)
        {
            try
            {
                Color obj = db.Color.Where(z => z.ID == color.ID).FirstOrDefault();
                if (obj!= null)
                {
                    obj.Name = color.Name;
                    obj.Code = color.Code;
                    obj.CreatedBy = color.CreatedBy;
                    obj.CreationDate = DateTime.Now;
                    obj.UpdatedBy = color.UpdatedBy;
                    obj.UpdatedDate = color.UpdatedDate;
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
                Color obj = db.Color.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.Color.Remove(obj);
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
        public Color Getone(long id)
        {
            return db.Color.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<Color> GetAll()
        {
            return db.Color.ToList();
        }
    }
}