using BLL.DTOs;
using BLL.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application_Layer.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("all")]
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
        [Route("signup")]
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
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteUsers(int id)
        {
            try
            {
                var data = UserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage UpdateInfo(int id, [FromBody] UserDTO user)
        {
            try
            {
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "User payload is required" });

                user.Id = id;

                var success = UserService.Update(user);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true });
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "User not found or update failed" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("SendMoney/{senderId}/{rcvPhn}/{amount}")]
        public HttpResponseMessage sendMoney(int senderId, string rcvPhn, decimal amount)
        {
            try
            {
                var sender = UserService.Get(senderId);
                var sndrWallet = WalletService.Get().FirstOrDefault(w => w.UserId == sender.Id);
                if (sender == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Sender not found" });
                var receiver = UserService.GetbyPhone(rcvPhn);
                if (receiver == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Receiver not found" });
                if (amount <= 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "Amount must be greater than zero" });
                if (sender.Id == receiver.Id)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "Sender and receiver cannot be the same" });
                if (sndrWallet == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Sender's wallet not found" });
                if (sndrWallet.Balance < amount)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "Insufficient balance" });
                var success = UserService.SendMoney(senderId, rcvPhn, amount);
                
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, senderNewBalance = amount, receiverNewBalance = amount });
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = ex.Message });

            }
        }
    }
}
