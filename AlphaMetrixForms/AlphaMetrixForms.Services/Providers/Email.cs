using AlphaMetrixForms.Services.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.Providers
{
    public class Email : IEmail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Greeting { get ; set ; }
        public string Content { get ; set ; }
        public string Closing { get ; set ; }
    }
}
