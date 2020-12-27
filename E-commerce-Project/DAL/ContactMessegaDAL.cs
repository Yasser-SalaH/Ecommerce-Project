using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;

namespace E_commerce_Project.DAL
{
    public class ContactMessegaDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Edit(ContactMesaage contactMesaage)
        {
            try
            {
                var obj = db.ContactMesaage.Where(z => z.ID == contactMesaage.ID).FirstOrDefault();
                if (obj != null)
                {

                    obj.Answer = contactMesaage.Answer;
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
            try
            {
                var obj = db.ContactMesaage.Where(z => z.ID == id).FirstOrDefault();
                if (obj!=null)
                {
                    db.ContactMesaage.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                return false ;
            }
        }
        public ContactMesaage Getone(long id)
        {
            return db.ContactMesaage.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<ContactMesaage> GetALL()
        {
            return db.ContactMesaage.ToList();
        }
    }
}