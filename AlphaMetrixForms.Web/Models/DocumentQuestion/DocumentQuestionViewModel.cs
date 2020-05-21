using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.DocumentQuestion
{
    public class DocumentQuestionViewModel
    {
        public int OrderNumber { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
