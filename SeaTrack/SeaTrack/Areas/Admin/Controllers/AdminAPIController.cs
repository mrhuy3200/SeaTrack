using SeaTrack.Lib;
using SeaTrack.Lib.DTO.Admin;
using SeaTrack.Lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeaTrack.Areas.Admin.Controllers
{
    public class AdminAPIController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage CreateUser([FromBody]UserInfoDTO user)
        {
            var rs = AdminService.CreateUser(user, user.RoleID);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                STATUSCODE = rs > 0 ? Util.Static.SUCCESS_CODE : Util.Static.ERROR_CODE,
            });
        }
        [HttpGet]
        public HttpResponseMessage ListUser(int id)
        {
            var rs = AdminService.GetListUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                STATUSCODE = rs != null ? Util.Static.SUCCESS_CODE : Util.Static.ERROR_CODE,
                DATA = rs
            });
        }
        [HttpPost]
        public HttpResponseMessage UpdateUser([FromBody]UserInfoDTO user)
        {
            var rs = AdminService.UpdateUser(user);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                STATUSCODE = rs != null ? Util.Static.SUCCESS_CODE : Util.Static.ERROR_CODE,
                DATA = rs
            });
        }


    }
}
