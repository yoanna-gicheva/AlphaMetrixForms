using AlphaMetrixForms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Configurations
{
    public class DocumentQuestionAnswerConfiguration : IEntityTypeConfiguration<DocumentQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<DocumentQuestionAnswer> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Answer)
                .IsRequired();

            builder.HasOne(a => a.DocumentQuestion).WithMany(q => q.Answers).HasForeignKey(a => a.DocumentQuestionId);

            builder.HasOne(a => a.Response).WithMany(r => r.DocumentQuestionAnswers).HasForeignKey(a => a.ResponseId);
        }
    }
}
