using SeaTrack.Lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SeaTrack.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult AgencyManage()
        {
            if (Request.Cookies["userName"] == null && Request.Cookies["pass"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        //
        [HttpGet]
        public ActionResult ListUser(int id)
        {
            if (Request.Cookies["userName"] == null && Request.Cookies["pass"] == null)
            {
                return RedirectToAction("Login");
            }
            var data = AdminService.GetListUser(id);
            return Json(new { Result = data }, JsonRequestBehavior.AllowGet);
        }

    }
}