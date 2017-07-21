using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Api.API
{
    public interface IEmailSender
    {
        Task<HttpResponseMessage> SendMail(Message message);
    }
}
