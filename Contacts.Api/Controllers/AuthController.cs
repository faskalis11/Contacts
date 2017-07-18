using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contacts.Api.Controllers
{
    public class AuthController : ApiController
    {
        public IHttpActionResult GetName()
        {
            return Ok("Saulius");
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/send/{phone:long}/{message}")]
        //public IHttpActionResult Send(long phone, string message)
        //{
        //    var messagingService = new MessagingService("sm.euro@gmail.com", "");
        //    var result = messagingService.SendMessage(new SmsMessage($"+{phone}", message, "EX0235200"));

        //    return Ok(result);
        //}

        [Authorize]
        [Route("api/surname")]
        public IHttpActionResult GetSurname()
        {
            return Ok("Hey hey ");
        }

        [HttpGet]
        [Route("api/nogo")]
        public IHttpActionResult GetNoGo()
        {
            return Ok("Not good. Try again");
        }

        [HttpGet]
        [Route("api/loginGoogle")]
        public HttpResponseMessage LoginGoogle()
        {
            var properties = new AuthenticationProperties() { RedirectUri = "api/contactsapi" };
            Request.GetOwinContext().Authentication.Challenge(properties, "Google");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            return response;
        }

        [HttpGet]
        [Route("api/loginFacebook")]
        public HttpResponseMessage LoginFacebook()
        {
            var properties = new AuthenticationProperties() { RedirectUri = "api/surname" };
            Request.GetOwinContext().Authentication.Challenge(properties, "Facebook");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            var cookies = Request.Headers.GetCookies();
            return response;
        }
    }
}
