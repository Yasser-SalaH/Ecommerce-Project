using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce_Project.Models;
using E_commerce_Project.Common1;

namespace E_commerce_Project.DAL
{
    public class UserDAl
    {
        // Create Object Form Database.
        EcommerceProjectEntities db = new EcommerceProjectEntities();
       // This is Function Used To Add Customer
        public bool Add(User user,out string massage)
        {
            try
            { 
                if (user!=null)
                {
                    if (getByEmail(user.Email)!=null)
                    {
                        massage = "Email  exists";
                        return false;
                    }
                    db.User.Add(user);
                    db.SaveChanges();
                    massage = "Added successfuly";
                    return true;
                }
                massage = "User Empty";
                return false;
            }
            catch (Exception e)
            {
                massage = e.Message;
               return false; 
            }
        }
        // This is Function Used To Edit Date Customer

        public bool Edit(User user, out string message)
        {
            try
            {
                    // check if the object equals null
                if (user==null)
                {
                    message = "User Empty";
                    return false;
                }
                // check if the object's ID exits
                var obj = Getone(user.ID);
                if (obj==null)
                {
                    message = "No User Found";
                    return false;
                }
                // check if the object's Email is not used
                if (getByEmail(user.Email) != null)
                {
                    message = "Email Is Used";
                    return false;
                }
                    obj.Name = user.Name;
                    obj.Password = user.Password;
                    obj.Email = user.Email;
                    obj.Phone = user.Phone;
                    obj.RoleFK = (int)CommonEnum.Role.Custoumer;
                    obj.Address = user.Address;
                    obj.CreationDate = user.CreationDate;
                    obj.CreatedBy = user.CreatedBy;
                    obj.UpdatedBy = user.UpdatedBy;
                    obj.UpdatedDate = user.UpdatedDate;
                    db.SaveChanges();
                    message = "Edit Successfuly";
                    return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        // This is Function Used To Delete Date Customer
        public bool Delete(long id,out string Message)
        {
            try
            {
                User obj = db.User.Where(z => z.ID == id).FirstOrDefault();
                if (obj!=null)
                {
                    db.User.Remove(obj);
                    db.SaveChanges();
                    Message = "Deleted Successfuly";
                    return true;
                }
                Message = "User not found";
                return false;
            }
            catch (Exception e)
            {
                Message = e.Message;
                return false;
            }
        }
        // This is Function Used To Select Date Customer By ID.
        public User Getone(long id)
        {
            return db.User.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<User> GetAll()
        {
            return db.User.ToList();
        }
        // Check By Email
        public User getByEmail(string email)
        {
            return db.User.Where(z => z.Email == email).FirstOrDefault();
        }
        // This is Function Used To Login Customer By Email & Password.
        public bool Login(ref User user, out string message)
        {
            var obj = getByEmail(user.Email);
            if (obj == null)
            {
                message = "Wrong Email";
                return false;
            }
            //else if ((bool)!obj.IsActive)
            //{
            //    message = "Account not active";
            //    return false;
            //}
            //else
            {
                if (user.Password != obj.Password)
                {
                    message = "Wrong Password";
                    return false;
                }
                else
                {
                    message = "Logined Sucessfully";
                    user = obj;
                    return true;
                }
            }
        }
    }
}