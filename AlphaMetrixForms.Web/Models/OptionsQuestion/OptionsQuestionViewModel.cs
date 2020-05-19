using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.OptionsQuestion
{
    public class OptionsQuestionViewModel
    {
        [Required]
        public string Text { get; set; }
        public ICollection<string> Options { get; set; }

    }
}
