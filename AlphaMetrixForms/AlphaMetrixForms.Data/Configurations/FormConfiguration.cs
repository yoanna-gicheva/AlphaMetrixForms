using AlphaMetrixForms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Configurations
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Title)
                .IsRequired();

            builder.Property(f => f.Description);

            builder.HasOne(f => f.Owner).WithMany(u => u.Forms).HasForeignKey(f => f.OwnerId);
        }
    }
}
