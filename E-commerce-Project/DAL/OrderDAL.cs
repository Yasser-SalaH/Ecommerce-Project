using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;
namespace E_commerce_Project.DAL
{
    public class OrderDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(Order order)
        {
            try
            {
                if (order!=null)
                {
                    db.Order.Add(order);
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
            Order obj = db.Order.Where(z => z.ID == id).FirstOrDefault();
            try
            {
                if (obj!=null)
                {
                    db.Order.Remove(obj);
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
        public Order Getone(long id)
        {
            return db.Order.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<Order> GetALL()
        {
            return db.Order.ToList();
        }
    }
}