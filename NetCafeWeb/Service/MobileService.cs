using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetCafeWeb.Models;

namespace NetCafeWeb.Service
{
    public class MobileService
    {
        UserRepository repo = new UserRepository();
        public string checkUser(string username, string password)
        {
            if(repo.checkUser(username,password))
            {
                return "true";
            }
            return "false";
        }
    }
}