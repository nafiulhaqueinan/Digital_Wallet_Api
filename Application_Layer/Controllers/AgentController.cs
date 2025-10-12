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
        public HttpResponseMessage CreateNotification([FromBody] AgentDTO N)
        {
            try
            {
                var data = AgentService.Create(N);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError,new { Msg = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AgentService.Get(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update([FromBody] AgentDTO N)
        {
            try
            {
                var data = AgentService.Update(N);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AgentService.Delete(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("test")]
        public HttpResponseMessage Test(AgentDTO N)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Test Successful");
        }
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(AgentDTO agent)
        {
            try
            {
                var agents = AgentService.Get();
                var data = agents.FirstOrDefault(a => a.Email == agent.Email && a.Password == agent.Password);
                if (data != null)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, new { Msg = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}