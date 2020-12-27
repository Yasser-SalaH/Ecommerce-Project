using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;

namespace E_commerce_Project.DAL
{
    public class AboutUSDAL
    {
        // Creat object  Datebace
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        // This is Function Used to Add object Form Database.
        public bool Add(AboutUs about)
        {
            try
            {
                if (about != null)
                {
                    db.AboutUs.Add(about);
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
        // This is Function Used to Edit object Form Database.
        public bool Edit(AboutUs about)
        {
            try
            {
             var obj=   db.AboutUs.Where(z => z.ID == about.ID).FirstOrDefault();
                if (about!=null)
                {
                    obj.Vision = about.Vision;
                    obj.Mission = about.Mission;
                    obj.WhoAreWe = about.WhoAreWe;
                    obj.CreatedBy = about.CreatedBy;
                    obj.CreationDate = about.CreationDate;
                    obj.UpdatedBy = about.UpdatedBy;
                    obj.UpdatedDate = about.UpdatedDate;
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
        //This is Function Used To Delete object Form Database Vai ID.
        public bool Delete(long id)
        {
            try
            {
                var obj = db.AboutUs.Where(z => z.ID == id).FirstOrDefault();
                if (obj!=null)
                {
                    db.AboutUs.Remove(obj);
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
        //This is Function Used To Show object Form Database Vai ID.
        public AboutUs GetOne(long id)
        {
            return db.AboutUs.Where(z => z.ID == id).FirstOrDefault();
        }
        //This is Function Used To Show ALL object Form Database .
        public List<AboutUs> GetAll()
        {
            return db.AboutUs.ToList();
        }
    }
}