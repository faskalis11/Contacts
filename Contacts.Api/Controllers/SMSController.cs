using Contacts.Api.Models;
using Contacts.Data.Models;
using System.Net.Http;
using System.Web.Http;

namespace Contacts.Api.Controllers
{
    public class SMSController : ApiController
    {
        HttpClient client = new HttpClient();

        public void SendMessage(Message message)
        {
            string url = "https://api.esendex.com/v1.0/messagedispatcher";
            string contentType = "application/json";
            string accept = "application/json";
            SMessage smessage = new SMessage() {
                to = "37061587148",
                body = "Labas"             
            };
            EsendexMessage esendexMessage = new EsendexMessage()
            {
                accountReference = "",
                messages = new SMessage[] { smessage }
            };

            client.PostAsJsonAsync(url, esendexMessage);


            /*
            string accountReference = "EX0235222";
            string authorization = "Basic aWduYXNqYW5rYXVza2FzOUBnbWFpbC5jb206cGFwcmFzdGFzMTExMQ==";
            string esendexEmail = "ignasjankauskas9@gmail.com";
            string esendexPassword = "paprastas1111";
            string authorization2 = "Basic " + Base64Encode(esendexEmail + ":" + esendexPassword);
            if (authorization == authorization2)
            {
                 authorization = "37061587148";
            }
            string receiver = "37061587148";
            string messageText = message.MessageText;

            
            string receiver = "37061587148";
            string messageText = "Hello";
            

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", authorization);
            request.AddHeader("accept", accept);
            request.AddHeader("content-type", contentType);
            request.AddParameter("application/json", "{\r\n  \"accountreference\":\"" + accountReference + "\",\r\n  \"messages\":[{\r\n    \"to\":\"" + receiver + "\",\r\n    \"body\":\"" + messageText + "\"\r\n  }]\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            */

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}
