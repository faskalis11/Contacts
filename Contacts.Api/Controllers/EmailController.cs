using Contacts.Data.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Contacts.Data.Repositories.Database;
using Contacts.Api.Models.Email;
using System.Collections.Generic;
using System.Web.Configuration;
using Contacts.Api.API;

namespace Contacts.Api.Controllers
{
    public class EmailController : IEmailSender
    {
        public async Task<HttpResponseMessage> SendMail(Message message)
        {
            string url = "https://api.sendgrid.com/v3/mail/send";
            var contact = GetReceiverContact(message.ReceiverId);


            var model = new MailGrid
            {
                personalizations = new List<Personalization>()
                {
                    new Personalization()
                    {
                        to = new List<To>() {
                            new To { email = GetReceiverContact(message.ReceiverId).Email }
                        },
                        subject = "Spam from Contacts App"
                    }
                },
                from = new From()
                {
                    email = GetReceiverContact(message.SenderId).Email
                },
                content = new List<Content>()
                {
                    new Content()
                    {
                        type = "text/plain",
                        value = message.MessageText
                    }
                }
            };

            using (HttpClient client = new HttpClient())
            {
                
                StringContent content = new StringContent(JsonConvert.SerializeObject(model));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var key = WebConfigurationManager.AppSettings["sendGridKey"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
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
