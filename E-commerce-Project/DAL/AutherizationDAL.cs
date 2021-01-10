using E_commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce_Project.DAL
{
    public class AutherizationDAL
    {
        public bool Admin(User CurrentUser)
        {
            if (CurrentUser ==null||CurrentUser.RoleFK!=(long)Common1.CommonEnum.Role.Admin)
            {
                return false;
            }
            return true;
        }
    }
}