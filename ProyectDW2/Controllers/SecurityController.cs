using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectDW2.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult LogIn()
        {
            Session.Abandon();
            return View();
        }
    }
}