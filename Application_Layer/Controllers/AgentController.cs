using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Application_Layer.Controllers
{
    [RoutePrefix("api/agent")]
    public class AgentController: ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Agents()
        {
            try
            {
                var data = AgentService.Get(); 
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateNotification([FromBody] NotificationDTO N)
        {
            try
            {
                var data = NotificationService.Create(N);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError,new { Msg = ex.Message });
            }
        }

    }
}