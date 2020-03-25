using SeaTrack.Lib;
using SeaTrack.Lib.DTO;
using SeaTrack.Lib.DTO.Admin;
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
            if (!CheckRole(1))
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            return View();
        }
        [HttpGet]
        public JsonResult ListUser(int id)
        {
            if (!CheckRole(1))
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            var rs = AdminService.GetListUser(id);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateUser(UserInfoDTO user)
        {
            try
            {
                var rs = AdminService.CreateUser(user, 2);
                return Json("Susscess", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            if (!CheckRole(1))
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (TempData["EditResult"]!=null)
            {
                ViewBag.EditResult = TempData["EditResult"].ToString();
            }
            UserInfoDTO us = new UserInfoDTO();
            us = UsersService.GetUserByID(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditUser(UserInfoDTO user)
        {
            try
            {
                UserInfoDTO us = UsersService.GetUserByID(user.UserID);
                us.Username = user.Username;
                us.Password = user.Password;
                us.Fullname = user.Fullname;
                us.Phone = user.Phone;
                us.Address = user.Address;
                us.Status = user.Status;
                us.UpdateBy = "admin";
                us.LastUpdateDate = DateTime.Now;
                bool res = UsersService.EditUser(us);
                if (res)
                {
                    TempData["EditResult"] = "Cập nhật thành công";
                    return RedirectToAction("EditUser", us);
                }
                else
                {
                    TempData["EditResult"] = "Chưa được cập nhật";
                    return RedirectToAction("EditUser", us);
                }
            }
            catch (Exception)
            {
                TempData["EditResult"] = "Xảy ra lỗi trong quá trình cập nhật";
                return RedirectToAction("EditUser", user);
                throw;
            }
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            bool res = UsersService.DeleteUser(id);
            if (res)
            {
                return Json("Susscess", JsonRequestBehavior.AllowGet);
            }
            return Json("Error", JsonRequestBehavior.AllowGet);

        }


        public bool CheckRole(int role)
        {
            if (Request.Cookies["userName"] != null && Request.Cookies["pass"] != null && Request.Cookies["role"].Value == role.ToString())
            {
                return true;
            }
            return false;
        }
    }
}