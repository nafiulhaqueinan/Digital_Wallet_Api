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
    [RoutePrefix("api/wallet")]
    public class WalletController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Wallets()
        {
            try
            {
                var data =WalletService.Get();
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
                var wallet = new WalletDTO
                {
                    UserId = 0,
                    Balance = 0,
                    Currency = "BDT",
                    LastUpdate = DateTime.Now
                };
                var data = WalletService.Create(wallet);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
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
                var data = WalletService.Delete(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Put(int id)
        {
            try
            {
                var wallet = new WalletDTO
                {
                    Id = id,
                    UserId = 0,
                    Balance = 0,
                    Currency = "BDT",
                    LastUpdate = DateTime.Now
                };
                var data = WalletService.Update(wallet);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = WalletService.Get(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("add/{id}/{amount}")]
        public HttpResponseMessage AddMoney(int id, decimal amount)
        {
            try
            {
                var data = WalletService.AddMoney(id, amount);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("add/number/{number}/{amount}")]
        public HttpResponseMessage AddMoneybyNumber(string number, decimal anoumt)
        {
            try
            {
                var user = UserService.GetbyPhone(number);
                if (user == null) return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, new { Msg = "User not found" });
                var wallets = WalletService.Get().FirstOrDefault(w => w.UserId==user.Id);
                if (wallets ==  null) return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, new { Msg = "Wallet not found" });
                var data = WalletService.AddMoney(wallets.Id, anoumt);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("deduct/{id}/{amount}")]
        public HttpResponseMessage DeductMoney(int id, decimal amount)
        {
            try
            {
                var data = WalletService.DeductMoney(id, amount);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        
    }
}