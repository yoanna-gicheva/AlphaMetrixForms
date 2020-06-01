using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils
{
    public class ListEmails
    {
        public ICollection<string> Emails { get; set; }
        public Guid FormId { get; set; }
    }
}
