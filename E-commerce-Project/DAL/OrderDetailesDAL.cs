using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;

namespace E_commerce_Project.DAL
{

    public class OrderDetailesDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public List<OrderDetails> GetAll()
        {
            return db.OrderDetails.ToList();
        }
    }
}