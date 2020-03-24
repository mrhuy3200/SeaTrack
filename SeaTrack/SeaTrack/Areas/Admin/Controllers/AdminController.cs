using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaTrack.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult AgencyManage()
        {
            if (Request.Cookies["userName"] == null && Request.Cookies["pass"] == null && Request.Cookies[])
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}