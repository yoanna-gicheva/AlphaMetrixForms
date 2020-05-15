﻿using AlphaMetrixForms.Data.Entities.Parent;
using System;

namespace AlphaMetrixForms.Data.Entities
{
    public class TextQuestionAnswer : Entity
    {
        public Guid TextQuestionId { get; set; }
        public TextQuestion TextQuestion { get; set; }
        public Guid ResponseId { get; set; }
        public Response Response { get; set; }
        public string Answer { get; set; }
    }
}