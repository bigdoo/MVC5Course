﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Name, DateTime Birthday)
        {
            return Content(Name + " " + Birthday);
        }

        //[HttpPost]
        //public ActionResult Index(FormCollection form)
        //{
        //    return Content(form["Name"] + " " + form["Birthday"]);
        //}

        //[HttpPost]
        //public ActionResult Index(string tmp)
        //{
        //    return Content(Request.Form["Name"] + " " + Request.Form["Birthday"]);
        //}

    }
}