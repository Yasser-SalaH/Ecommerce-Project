using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_commerce_Project.DAL
{
    public class UserAddressDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Delete(long id)
        {
            try
            {
                var data = db.UserAddress.Where(z => z.ID == id).FirstOrDefault();
                if (data != null)
                {
                    db.UserAddress.Remove(data);
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
        public UserAddress Getone(long id)
        {
            return db.UserAddress.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<UserAddress> GetAll()
        {
            return db.UserAddress.ToList();
        }

    }
}