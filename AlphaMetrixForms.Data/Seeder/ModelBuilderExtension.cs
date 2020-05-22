using AlphaMetrixForms.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Seeder
{
    public static class ModelBuilderExtension
    {
        public static void Seeder(this ModelBuilder builder)
        {
            //Seeding User
            var hasher = new PasswordHasher<User>();

            User user = new User
            {
                Id = Guid.Parse("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                UserName = "user1@user.com",
                NormalizedUserName = "USER1@USER.COM",
                Email = "user1@user.com",
                NormalizedEmail = "USER1@USER.COM",
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "DC6E275DD1E24957A7781D42BB68293B"
            };

            user.PasswordHash = hasher.HashPassword(user, "123456");

            builder.Entity<User>().HasData(user);

            //Seeding form
            var form = new Form
            {
                Id = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Title = "TestForm",
                Description = "TestDescription",
                OwnerId = Guid.Parse("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                CreatedOn = DateTime.UtcNow
            };

            builder.Entity<Form>().HasData(form);

            //Seeding text question
            var textQuestion = new TextQuestion
            {
                Id = Guid.Parse("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "What is your favourite color?",
                IsRequired = true,
                IsLongAnswer = true
            };

            builder.Entity<TextQuestion>().HasData(textQuestion);
        }
    }
}
