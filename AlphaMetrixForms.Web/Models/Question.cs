using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models
{
    //[Bind("Type, OrderNumber")]
    public class Question
    {
        bool Edit { get; set; }
        public string Type { get; set; }
        public int OrderNumber { get; set; }
        [Required]
        public string Text { get; set; }


        //OPTION
        public ICollection<string> Options { get; set; }

    }
}
