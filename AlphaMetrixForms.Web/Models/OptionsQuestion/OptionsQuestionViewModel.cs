using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.OptionsQuestion
{
    public class OptionsQuestionViewModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public ICollection<string> Options { get; set; }

    }
}
