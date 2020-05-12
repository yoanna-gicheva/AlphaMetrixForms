using AlphaMetrixForms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Configurations
{
    public class TextQuestionAnswerConfiguration : IEntityTypeConfiguration<TextQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<TextQuestionAnswer> builder)
        {
            builder.HasKey(a => new { a.TextQuestionId, a.ResponseId });

            builder.Property(a => a.Answer)
                .IsRequired();

            builder.HasOne(a => a.TextQuestion).WithMany(q => q.Answers).HasForeignKey(a => a.TextQuestionId);

            builder.HasOne(a => a.Response).WithMany(r => r.TextQuestionAnswers).HasForeignKey(a => a.ResponseId);
        }
    }
}
