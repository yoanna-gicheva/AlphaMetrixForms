﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMetrixForms.Data.Configurations;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Data.Seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlphaMetrixForms.Data.Context
{
    public class FormsContext : IdentityDbContext<User, Role, Guid>
    {
        public FormsContext(DbContextOptions<FormsContext> options)
            : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<TextQuestion> TextQuestions { get; set; }
        public DbSet<TextQuestionAnswer> TextQuestionAnswers { get; set; }
        public DbSet<OptionQuestion> OptionQuestions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionQuestionAnswer> OptionQuestionAnswers { get; set; }
        public DbSet<DocumentQuestion> DocumentQuestions { get; set; }
        public DbSet<DocumentQuestionAnswer> DocumentQuestionAnswers { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FormConfiguration());
            builder.ApplyConfiguration(new TextQuestionConfiguration());
            builder.ApplyConfiguration(new TextQuestionAnswerConfiguration());
            builder.ApplyConfiguration(new OptionQuestionConfiguration());
            builder.ApplyConfiguration(new OptionQuestionAnswerConfiguration());
            builder.ApplyConfiguration(new OptionConfiguration());
            builder.ApplyConfiguration(new DocumentQuestionConfiguration());
            builder.ApplyConfiguration(new DocumentQuestionAnswerConfiguration());
            builder.ApplyConfiguration(new ResponseConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Seeder();
            //builder.RelationshipSetter();


            base.OnModelCreating(builder);
        }
    }
}
