﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Api.Models.Email
{
    public class Personalization
    {
        public List<To> to { get; set; }
        public string subject { get; set; }
    }
}