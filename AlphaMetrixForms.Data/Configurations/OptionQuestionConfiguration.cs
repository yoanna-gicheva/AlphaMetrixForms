using AlphaMetrixForms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Configurations
{
    public class OptionQuestionConfiguration : IEntityTypeConfiguration<OptionQuestion>
    {
        public void Configure(EntityTypeBuilder<OptionQuestion> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Text)
                .IsRequired();

            builder.HasOne(q => q.Form).WithMany(f => f.OptionQuestions).HasForeignKey(q => q.FormId);
        }
    }
}
