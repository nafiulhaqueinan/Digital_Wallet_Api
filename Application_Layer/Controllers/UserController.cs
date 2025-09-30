using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application_Layer.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage Users()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/users/SignUp")]
        public HttpResponseMessage CreateUsers([FromBody] UserDTO user)
        {
            try
            {
                var data = UserService.Create(user);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }   
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
