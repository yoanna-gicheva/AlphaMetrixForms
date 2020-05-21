using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.TextQuestion
{
    public class TextQuestionViewModel : IQuestion
    {
        public int OrderNumber { get; set; }
        public string Type { get; set; } = "TextQuestion";

        [Required]
        public string Text { get; set; }
    }
}
