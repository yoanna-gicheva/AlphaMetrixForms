﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class DocumentQuestionAnswerDTO
    {
        public Guid DocumentQuestionId { get; set; }

        public string DocumentQuestion { get; set; }
        public Guid ResponseId { get; set; }

        //public string Response { get; set; }

        public string Answer { get; set; }
    }
}