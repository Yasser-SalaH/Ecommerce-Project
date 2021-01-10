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
        public bool Add(ContactMesaage contactMesaage, out string message)
        {
            try
            {
                if (contactMesaage != null)
                {
                    db.ContactMesaage.Add(contactMesaage);
                    db.SaveChanges();
                    message = "Added Successfully";
                    return true;
                }

                message = "Object is null";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        //Edit
        public bool Edit(ContactMesaage contactmsg, out string message)
        {
            try
            {
                ContactMesaage obj = db.ContactMesaage.Where(z => z.ID == contactmsg.ID).FirstOrDefault();
                if (obj != null)
                {

                    obj.Answer = contactmsg.Answer;
                    db.SaveChanges();
                    message = "Edited Successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        //Delete 
        public bool Delete(long id, out string message)
        {
            ContactMesaage obj = db.ContactMesaage.Where(z => z.ID == id).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    db.ContactMesaage.Remove(obj);
                    db.SaveChanges();
                    message = "Deleted Successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        //Details for one item
        public ContactMesaage GetOne(long id)
        {
            return db.ContactMesaage.Where(z => z.ID == id).FirstOrDefault();
        }
        //Get All Data
        public List<ContactMesaage> GetAll()
        {
            return db.ContactMesaage.OrderBy(z => z.Answer).ToList();
        }
    }
}