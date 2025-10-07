using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Application_Layer.Controllers
{
    [RoutePrefix("api/notification")]
    public class NotificationController: ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Notifications()
        {
            try
            {
                // Placeholder for actual service call
                var data = new List<string> { "Notification1", "Notification2" };
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create()
        {
            try
            {
                // Placeholder for actual creation logic
                var notification = new { Id = 1, Message = "New Notification" };
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, notification);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                // Placeholder for actual deletion logic
                var success = true;
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, success);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update()
        {
            try
            {
                // Placeholder for actual update logic
                var notification = new { Id = 1, Message = "Updated Notification" };
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, notification);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}