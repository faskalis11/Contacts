using Microsoft.Owin.Security;
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
            var properties = new AuthenticationProperties() {
                RedirectUri = "http://localhost:50712/"
            };
            Request.GetOwinContext().Authentication.Challenge(properties, "Google");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            return response;
        }

        [HttpGet]
        [Route("api/loginFacebook")]
        public HttpResponseMessage LoginFacebook()
        {
            var properties = new AuthenticationProperties() { RedirectUri = "http://localhost:50712/" };
            Request.GetOwinContext().Authentication.Challenge(properties, "Facebook");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            var cookies = Request.Headers.GetCookies();
            return response;
        }
    }
}
