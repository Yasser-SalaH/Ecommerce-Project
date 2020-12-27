using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;
namespace E_commerce_Project.DAL
{
    public class ContactUSDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(ContactUs contact)
        {
            try
            {
                if (contact!=null)
                {
                    db.ContactUs.Add(contact);
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
        public bool Edit(ContactUs contactUs)
        {
            try
            {
                var obj = db.ContactUs.Where(z => z.ID == contactUs.ID).FirstOrDefault();
                if (obj!=null)
                {
                    obj.Email = contactUs.Email;
                    obj.facebook = contactUs.facebook;
                    obj.phone = contactUs.phone;
                    obj.address = contactUs.address;
                    obj.UpdatedBy = contactUs.UpdatedBy;
                    obj.UpdatedDate = contactUs.UpdatedDate;
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
        public bool Delete(long id)
        {
            var obj = db.ContactUs.Where(z => z.ID == id).FirstOrDefault();
            try
            {
                if (obj!=null)
                {
                    db.ContactUs.Remove(obj);
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
        public ContactUs GetOne(long id)
        {
            return db.ContactUs.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<ContactUs> GetAll()
        {
            return db.ContactUs.ToList();
        }
    }
}