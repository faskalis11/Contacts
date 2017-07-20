using Contacts.Data.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Contacts.Data.Repositories.Database;

namespace Contacts.Api.Controllers
{
    public class EmailController
    {
        public async Task<HttpResponseMessage> SendMailAsync(Message message)
        {
            string url = "https://api.esendex.com/v1.0/messagedispatcher";
            var contact = GetReceiverContact(message.ReceiverId);

            using (HttpClient client = new HttpClient())
            {
                
                StringContent content = new StringContent(JsonConvert.SerializeObject();
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = content;
                var response = await client.SendAsync(request);

                return response;
            }
        }

        private Contact GetReceiverContact(int contactId)
        {
            ContactRepository contactRepository = new ContactRepository();
            return contactRepository.Get(contactId); ;
        }
    }
}
