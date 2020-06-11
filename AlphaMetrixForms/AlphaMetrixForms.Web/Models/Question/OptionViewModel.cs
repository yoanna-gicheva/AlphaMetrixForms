using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Question
{
    public class OptionViewModel
    {
        public OptionViewModel()
        {
        }
        public int OrderNumber { get; set; }
        public string Text { get; set; }
    }
}
