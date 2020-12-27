using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;

namespace E_commerce_Project.DAL
{
    public class TestimonialsDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(TestMonials testMonials,out string message)
        {
            try
            {
                if (testMonials!=null)
                {
                    db.TestMonials.Add(testMonials);
                    db.SaveChanges();
                    message = "Added Successfully";
                    return true;
                }
                message = "TestMonials Empty";
                return false;
            }
            catch (Exception e)
            {

                message=e.Message;
                return false;
            }
        }
        public bool Edit(TestMonials testMonials,out string Message)
        {
            try
            {
                var Obj = db.TestMonials.Where(z => z.ID == testMonials.ID).FirstOrDefault();
                if (Obj!=null)
                {
                    Obj.ID = testMonials.ID;
                    Obj.Image = testMonials.Image;
                    Obj.FeedBack = testMonials.FeedBack;
                    Obj.UserFK = testMonials.UserFK;
                    Obj.CreatedBy = testMonials.CreatedBy;
                    Obj.CreationDate = testMonials.CreationDate;
                    Message = "Edit Successfuly";
                    return true;
                }
                Message = "Product Empty";
                return false;
            }
            catch (Exception e)
            {

                Message=e.Message;
                return false;
            }
        }
        public TestMonials GetOne(long id)
        {
            return db.TestMonials.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<TestMonials> GetAll()
        {
            return db.TestMonials.ToList();
        }
    }
}