﻿using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCafeWeb.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public Boolean Add()
        {
            return true;
        }
        [HttpPost]
        public Boolean editUser()
        {
            return true;
        }
        [HttpPost]
        public Boolean delete()
        {
            return true;
        }
        [HttpPost]
        public User getUser()
        {
            return null;
        }
        [HttpPost]
        public ActionResult edit(int? id)
        {
            return View();
        }
	}
}