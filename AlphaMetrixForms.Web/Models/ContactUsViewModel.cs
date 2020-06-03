using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models
{
    public class ContactUsViewModel
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string CallBackInfo { get; set; }
    }
}
