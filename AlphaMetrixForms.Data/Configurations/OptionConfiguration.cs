using AlphaMetrixForms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Text)
                .IsRequired();

            builder.HasOne(o => o.Question).WithMany(q => q.Options).HasForeignKey(o => o.QuestionId);
        }
    }
}
