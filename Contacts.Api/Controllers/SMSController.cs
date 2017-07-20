using Contacts.Api.API;
using Contacts.Api.Models;
using Contacts.Data.Models;
using Contacts.Data.Repositories.Database;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Contacts.Api.Controllers
{
    public class SmsController : ISmsSender
    {
        
        public async Task<HttpResponseMessage> MessageResponse(Message message)
        {
            string url = "https://api.esendex.com/v1.0/messagedispatcher";
            var contact = GetReceiverContact(message.ReceiverId);
            var accountEmail =  WebConfigurationManager.AppSettings["accountEmail"];
            var accountPassword = WebConfigurationManager.AppSettings["accountPassword"];
            var accountReference = WebConfigurationManager.AppSettings["accountReference"];

            string authorization = "Basic " + Base64Encode(accountEmail + ":" + accountPassword);
            SMessage smessage = new SMessage()
            {
                to = "37061587148", // only to this number
                body = message.MessageText
            };
            EsendexMessage esendexMessage = new EsendexMessage()
            {
                accountReference = accountReference,
                messages = new SMessage[] { smessage }
            };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", authorization);
                StringContent content = new StringContent(JsonConvert.SerializeObject(esendexMessage));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = content;
                var response = await client.SendAsync(request);

                return response;
            }

        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private Contact GetReceiverContact(int contactId)
        {
            ContactRepository contactRepository = new ContactRepository();
            return contactRepository.Get(contactId); ;
        }

    }
}
