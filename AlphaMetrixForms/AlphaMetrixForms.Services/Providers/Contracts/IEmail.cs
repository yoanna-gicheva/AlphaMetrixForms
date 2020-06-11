using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.Providers.Contracts
{
    public interface IEmail
    {
        public string To { get; set; }
        public string Subject { get; set; }

        public string Greeting { get; set; }

        public string Content { get; set; }

        public string Closing { get; set; }
    }
}
