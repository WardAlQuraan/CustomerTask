using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUSTOMER.BACKEND.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Clients()
        {
            return View();
        }
        public ActionResult Admins()
        {
            return View();
        }
        public ActionResult AddAdmin()
        {
            return View();
        }
    }
}