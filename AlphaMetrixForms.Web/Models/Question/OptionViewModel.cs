using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Question
{
    public class OptionViewModel
    {
        public OptionViewModel(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
    }
}
