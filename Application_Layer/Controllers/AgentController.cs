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
        [Route("create")]
        public HttpResponseMessage Create()
        {
            try
            {
                // Placeholder for actual creation logic
                var agent = new { Id = 1, Name = "New Agent" };
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, agent);
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
        public HttpResponseMessage Update(int id)
        {
            try
            {
                // Placeholder for actual update logic
                var updatedAgent = new { Id = id, Name = "Updated Agent" };
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, updatedAgent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}