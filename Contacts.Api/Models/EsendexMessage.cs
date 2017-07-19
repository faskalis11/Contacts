using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Api.Models
{
    public class EsendexMessage
    {
        public string accountReference;
        public SMessage[] messages;
    }
}