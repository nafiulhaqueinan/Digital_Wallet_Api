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
                //var sndr= UserService.Get(senderId);
                //var rcv= UserService.Get().FirstOrDefault(u => u.Phone == rcvPhn);
                
                //if (sndr == null)
                //    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Sender not found" });
                //if (rcv == null)
                //    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Receiver not found" });
                //var sndrWallet = WalletService.Get().FirstOrDefault(w => w.UserId == sndr.Id);
                //var rcvWallet = WalletService.Get().FirstOrDefault(w => w.UserId == rcv.Id);
                //if (sndrWallet == null || rcvWallet == null)
                //    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Wallet not found for sender or receiver" });
                //if (sndrWallet.Balance < amount)
                //    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "Insufficient balance in sender's wallet" });
                //var deducted = WalletService.DeductMoney(sndrWallet.Id, amount);
                //var added = WalletService.AddMoney(rcvWallet.Id, amount);
                //var txn = new TransactionDTO
                //{
                //    SenderWalletId = sndr.Id,
                //    ReceiverWalletId = rcv.Id,
                //    Type = "SendMoney",
                //    Amount = amount,
                //    Status = "Success",
                //    CreatedAt = DateTime.Now
                //};
                //var txnResult = TransactionService.Create(txn);

                //var SndrMsg = $"You have sent {amount} to {rcv.Name}, New Balance: {deducted.Balance}";
                //var RcvMsg = $"You have received {amount} from {sndr.Name}, New Balance: {added.Balance}";
                //NotificationService.Create(new NotificationDTO
                //{
                //    UserId = sndr.Id,
                //    Message = SndrMsg,
                //    Type= "Transaction",
                //    CreatedAt = DateTime.Now,
                //    IsRead = false
                //});
                //NotificationService.Create(new NotificationDTO
                //{
                //    UserId = rcv.Id,
                //    Message = RcvMsg,
                //    Type = "Transaction",
                //    CreatedAt = DateTime.Now,
                //    IsRead = false
                //});
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
