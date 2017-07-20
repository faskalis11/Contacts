using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Api.Models.Email
{
    public class MailGrid
    {
        public List<Personalization> personalizations { get; set; }
        public From from { get; set; }
        public List<Content> content { get; set; }
    }
}