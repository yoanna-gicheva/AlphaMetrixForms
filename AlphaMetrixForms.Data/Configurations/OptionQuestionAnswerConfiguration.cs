using AlphaMetrixForms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Configurations
{
    public class OptionQuestionAnswerConfiguration : IEntityTypeConfiguration<OptionQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<OptionQuestionAnswer> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Answer)
                .IsRequired();

            builder.HasOne(a => a.OptionQuestion).WithMany(q => q.Answers).HasForeignKey(a => a.OptionQuestionId);

            builder.HasOne(a => a.Response).WithMany(r => r.OptionQuestionAnswers).HasForeignKey(a => a.ResponseId);
        }
    }
}
