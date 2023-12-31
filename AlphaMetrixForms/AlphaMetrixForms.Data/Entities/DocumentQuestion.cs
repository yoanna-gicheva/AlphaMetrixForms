﻿using AlphaMetrixForms.Data.Entities.Parent;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities
{
    public class DocumentQuestion
    {
        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public Form Form { get; set; }

        public string Text { get; set; }

        public bool IsRequired { get; set; }
        public int FileNumberLimit { get; set; }
        public int FileSizeLimit { get; set; }

        public int OrderNumber { get; set; }

        public ICollection<DocumentQuestionAnswer> Answers { get; set; }

    }
}
