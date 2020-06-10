using AlphaMetrixForms.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Data.Seeder
{
    public static class ModelBuilderExtension
    {
        public static void Seeder(this ModelBuilder builder)
        {
            //Seeding User
            var hasher = new PasswordHasher<User>();

            User user1 = new User
            {
                Id = Guid.Parse("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "user1@user.com",
                NormalizedEmail = "USER1@USER.COM",
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "DC6E275DD1E24957A7781D42BB68293B"
            };

            user1.PasswordHash = hasher.HashPassword(user1, "123456");

            User user2 = new User
            {
                Id = Guid.Parse("2f3ffe43-1901-4ec5-919b-6787d5cc16f4"),
                UserName = "JohnSmith",
                NormalizedUserName = "JOHNSMITH",
                Email = "johnsmith@supermarket.com",
                NormalizedEmail = "JOHNSMITH@SUPERMARKET.COM",
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "DC6E275DD1E24957A7781D42BB68293C"
            };

            user2.PasswordHash = hasher.HashPassword(user2, "123456");

            User user3 = new User
            {
                Id = Guid.Parse("3ff82bae-c8d2-4102-aaab-a4a0e8b5c086"),
                UserName = "BankManager",
                NormalizedUserName = "BANKMANAGER",
                Email = "bankmanager@bbank.com",
                NormalizedEmail = "BANKMANAGER@BBANK.COM",
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "DC6E275DD1E24957A7781D42BB68293D"
            };

            user3.PasswordHash = hasher.HashPassword(user3, "123456");

            builder.Entity<User>().HasData(user1, user2, user3);

            //Seeding form
            var form1 = new Form
            {
                Id = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Title = "Banking Services",
                Description = "Questionnaire initiated by BBank in order to improve their services.",
                OwnerId = Guid.Parse("3ff82bae-c8d2-4102-aaab-a4a0e8b5c086"),
                CreatedOn = DateTime.UtcNow
            };

            var form2 = new Form
            {
                Id = Guid.Parse("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                Title = "Test Question Test",
                OwnerId = Guid.Parse("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                CreatedOn = DateTime.UtcNow
            };

            var form3 = new Form
            {
                Id = Guid.Parse("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                Title = "Document Question Test",
                OwnerId = Guid.Parse("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                CreatedOn = DateTime.UtcNow
            };

            var form4 = new Form
            {
                Id = Guid.Parse("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                Title = "Option Question Test",
                OwnerId = Guid.Parse("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                CreatedOn = DateTime.UtcNow
            };
            var form5 = new Form
            {
                Id = Guid.Parse("72457b91-0923-4f37-bd50-5f8d36e45b3f"),
                Title = "Customers in supermarkets",
                Description = "Market research on customer behaviour in supermarkets and grocery stores.",
                OwnerId = Guid.Parse("2f3ffe43-1901-4ec5-919b-6787d5cc16f4"),
                CreatedOn = DateTime.UtcNow
            };
            var form6 = new Form
            {
                Id = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Title = "Customer satisfaction",
                Description = "A brief questionnaire on client experience which will help improving the services of Smith's supermarkets.",
                OwnerId = Guid.Parse("2f3ffe43-1901-4ec5-919b-6787d5cc16f4"),
                CreatedOn = DateTime.UtcNow
            };


            builder.Entity<Form>().HasData(form1, form2, form3, form4, form5, form6);

            //Seeding text question
            var textQuestion1 = new TextQuestion
            {
                Id = Guid.Parse("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Please enter your name:",
                OrderNumber = 0,
                IsRequired = true,
                IsLongAnswer = false
            };

            var textQuestion2 = new TextQuestion
            {
                Id = Guid.Parse("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Are you satisfied with the services provided by BBank in overall:",
                OrderNumber = 7,
                IsRequired = true,
                IsLongAnswer = true
            };

            var textQuestion3 = new TextQuestion
            {
                Id = Guid.Parse("082e946c-a3d2-474f-8765-e933d78e9832"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Here you can share feedback for the form:",
                OrderNumber = 8,
                IsRequired = false,
                IsLongAnswer = true
            };

            var textQuestion4 = new TextQuestion
            {
                Id = Guid.Parse("1ea514f3-b6b2-4ada-9a69-1d68cad75349"),
                FormId = Guid.Parse("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                Text = "Q4:",
                OrderNumber = 3,
                IsRequired = false,
                IsLongAnswer = false
            };

            var textQuestion5 = new TextQuestion
            {
                Id = Guid.Parse("00db1b7c-9616-4b03-9435-a3c915f96412"),
                FormId = Guid.Parse("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                Text = "Q2:",
                OrderNumber = 1,
                IsRequired = false,
                IsLongAnswer = true
            };

            var textQuestion6 = new TextQuestion
            {
                Id = Guid.Parse("1a7e99da-687f-4fc3-b9a8-abed0adb5526"),
                FormId = Guid.Parse("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                Text = "Q1:",
                OrderNumber = 0,
                IsRequired = true,
                IsLongAnswer = false
            };

            var textQuestion7 = new TextQuestion
            {
                Id = Guid.Parse("a25cc7e3-2298-4fa6-8dd8-e3147a64464a"),
                FormId = Guid.Parse("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                Text = "Q3:",
                OrderNumber = 2,
                IsRequired = true,
                IsLongAnswer = true
            };

            var textQuestion8 = new TextQuestion
            {
                Id = Guid.Parse("b588fe45-b95f-4a53-ae2b-96d27097f595"),
                FormId = Guid.Parse("72457b91-0923-4f37-bd50-5f8d36e45b3f"),
                Text = "What features do you look for shopping at a supermarket—i.e. price, quality of product, variety of product, branding etc?",
                OrderNumber = 3,
                IsRequired = true,
                IsLongAnswer = true
            };

            var textQuestion9 = new TextQuestion
            {
                Id = Guid.Parse("7c6649e9-467c-4d97-812f-7de4acc79df7"),
                FormId = Guid.Parse("72457b91-0923-4f37-bd50-5f8d36e45b3f"),
                Text = "What would make your shopping experience better?",
                OrderNumber = 4,
                IsRequired = false,
                IsLongAnswer = true
            };

            var textQuestion10 = new TextQuestion
            {
                Id = Guid.Parse("e2f1fe9a-ca1b-4e3d-ba34-68502cd487d6"),
                FormId = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Text = "Please share your name:",
                OrderNumber = 0,
                IsRequired = true,
                IsLongAnswer = false
            };

            var textQuestion11 = new TextQuestion
            {
                Id = Guid.Parse("b4d808d6-6c1a-4753-9f4b-5f185b43de26"),
                FormId = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Text = "Any additional feedback is more than welcome:",
                OrderNumber = 6,
                IsRequired = false,
                IsLongAnswer = true
            };

            builder.Entity<TextQuestion>().HasData(textQuestion1,textQuestion2,textQuestion3,
                textQuestion4, textQuestion5, textQuestion6, textQuestion7,
                textQuestion8,textQuestion9,
                textQuestion10, textQuestion11);

            //Seeding document question
            var documentQuestion1 = new DocumentQuestion
            {
                Id = Guid.Parse("078f9ce9-8a39-4355-a6c5-de5282df4dce"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Please upload your ID:",
                OrderNumber = 1,
                IsRequired = true,
                FileNumberLimit = 2,
                FileSizeLimit = 100
            };

            var documentQuestion2 = new DocumentQuestion
            {
                Id = Guid.Parse("75b93e1d-2219-43da-b2d8-f5b985112e43"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Please upload your Token paper certificate:",
                OrderNumber = 2,
                IsRequired = true,
                FileNumberLimit = 1,
                FileSizeLimit = 100
            };

            var documentQuestion3 = new DocumentQuestion
            {
                Id = Guid.Parse("5065d44a-992d-4328-bcf9-56a3f49581d9"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Additional documents for upload:",
                OrderNumber = 3,
                IsRequired = false,
                FileNumberLimit = 10,
                FileSizeLimit = 1000
            };

            var documentQuestion4 = new DocumentQuestion
            {
                Id = Guid.Parse("a08236d6-1576-4780-98ec-b00b470a5b1e"),
                FormId = Guid.Parse("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                Text = "Q1:",
                OrderNumber = 0,
                IsRequired = true,
                FileNumberLimit = 1,
                FileSizeLimit = 1
            };

            var documentQuestion5 = new DocumentQuestion
            {
                Id = Guid.Parse("ad686787-e762-4b05-aa40-bab8f8deb4c0"),
                FormId = Guid.Parse("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                Text = "Q2:",
                OrderNumber = 1,
                IsRequired = false,
                FileNumberLimit = 10,
                FileSizeLimit = 10
            };

            var documentQuestion6 = new DocumentQuestion
            {
                Id = Guid.Parse("fbc627f0-f7cd-49e2-b329-644b6520ef58"),
                FormId = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Text = "Upload a photo from our supermarkets and win a prize:",
                OrderNumber = 5,
                IsRequired = false,
                FileNumberLimit = 1,
                FileSizeLimit = 10
            };

            builder.Entity<DocumentQuestion>().HasData(documentQuestion1, documentQuestion2, documentQuestion3,
                documentQuestion4, documentQuestion5,
                documentQuestion6);

            //Seeding option question
            var optionQuestion1 = new OptionQuestion
            {
                Id = Guid.Parse("02627001-cae2-4189-a774-5f2b1876f37c"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Please choose for how long have you been a customer of BBank:",
                OrderNumber = 4,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion1option1 = new Option
            {
                Id = Guid.Parse("d5ff0344-94c4-48fe-9211-8c34e43c9a7e"),
                QuestionId = Guid.Parse("02627001-cae2-4189-a774-5f2b1876f37c"),
                Text = "less than 1 year",
                OrderNumber = 0
            };

            var optionQuestion1option2 = new Option
            {
                Id = Guid.Parse("b3ba569b-123e-4f16-9298-3dbe5720207c"),
                QuestionId = Guid.Parse("02627001-cae2-4189-a774-5f2b1876f37c"),
                Text = "1-3 years",
                OrderNumber = 1
            };

            var optionQuestion1option3 = new Option
            {
                Id = Guid.Parse("7a36b91e-9454-43cb-8e58-93d493b849ad"),
                QuestionId = Guid.Parse("02627001-cae2-4189-a774-5f2b1876f37c"),
                Text = "3-5 years",
                OrderNumber = 2
            };

            var optionQuestion1option4 = new Option
            {
                Id = Guid.Parse("d626cd57-2076-4494-9765-be883e0292de"),
                QuestionId = Guid.Parse("02627001-cae2-4189-a774-5f2b1876f37c"),
                Text = "more than 5 years",
                OrderNumber = 3
            };

            var optionQuestion2 = new OptionQuestion
            {
                Id = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Which products of BBank are you using:",
                OrderNumber = 5,
                IsRequired = true,
                IsMultipleAnswerAllowed = true
            };


            var optionQuestion2option1 = new Option
            {
                Id = Guid.Parse("c542a866-9b62-4629-8e69-84c4394104c4"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Debit Card",
                OrderNumber=0
            };

            var optionQuestion2option2 = new Option
            {
                Id = Guid.Parse("1f747c49-83d1-4e12-93a4-d4fb94366d3d"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Credit Card",
                OrderNumber=1
            };

            var optionQuestion2option3 = new Option
            {
                Id = Guid.Parse("b73ca574-f326-4bc6-80dc-038ea561ab33"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Current account",
                OrderNumber=2
            };

            var optionQuestion2option4 = new Option
            {
                Id = Guid.Parse("40b0b5ca-f281-4919-b323-26ab2b84d720"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Overdraft",
                OrderNumber=3
            };

            var optionQuestion2option5 = new Option
            {
                Id = Guid.Parse("0b8a2599-2e62-4d2c-aca8-cc6c2a43bab1"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Short-term Loan",
                OrderNumber=4
            };

            var optionQuestion2option6 = new Option
            {
                Id = Guid.Parse("c47a949d-e300-4354-b22e-a1615bc6f1a3"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Long-term Loan",
                OrderNumber=5
            };

            var optionQuestion2option7 = new Option
            {
                Id = Guid.Parse("85662798-ac15-45c7-96fb-50e77de9d526"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Mortgage",
                OrderNumber=6
            };

            var optionQuestion2option8 = new Option
            {
                Id = Guid.Parse("a7a8b2ac-d48a-4e48-98db-2ac2eacb507a"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Savings account",
                OrderNumber=7
            };

            var optionQuestion2option9 = new Option
            {
                Id = Guid.Parse("bd0ca49f-c7c3-4401-a225-16d025b13f9b"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "E-Banking",
                OrderNumber=8
            };

            var optionQuestion2option10 = new Option
            {
                Id = Guid.Parse("99c6498b-e76f-496a-9e2b-beb3e36eb6b6"),
                QuestionId = Guid.Parse("29413352-774c-4cf4-8093-c0b733a95194"),
                Text = "Other",
                OrderNumber=9
            };

            var optionQuestion3 = new OptionQuestion
            {
                Id = Guid.Parse("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                FormId = Guid.Parse("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                Text = "Are you considering changing BBank as your servicing bank:",
                OrderNumber = 6,
                IsRequired = false,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion3option1 = new Option
            {
                Id = Guid.Parse("cc936706-63b9-4830-95ff-c108a71e13f3"),
                QuestionId = Guid.Parse("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                Text = "Yes",
                OrderNumber=0
            };

            var optionQuestion3option2 = new Option
            {
                Id = Guid.Parse("ca610326-8825-465a-bf9e-634ddbdcaaad"),
                QuestionId = Guid.Parse("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                Text = "No",
                OrderNumber=1
            };

            var optionQuestion3option3 = new Option
            {
                Id = Guid.Parse("80a8e086-9592-4760-bd5b-a1a0ebf6a624"),
                QuestionId = Guid.Parse("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                Text = "TestBank is not my main servicing bank",
                OrderNumber=2
            };

            var optionQuestion4 = new OptionQuestion
            {
                Id = Guid.Parse("786cef88-a6ac-42e3-994c-e7eed39201a5"),
                FormId = Guid.Parse("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                Text = "Q4:",
                OrderNumber = 3,
                IsRequired = true,
                IsMultipleAnswerAllowed = true
            };

            var testOption1 = new Option
            {
                Id = Guid.Parse("1a65e090-bec7-4388-a9dc-521ee062fc25"),
                QuestionId = Guid.Parse("786cef88-a6ac-42e3-994c-e7eed39201a5"),
                Text = "A",
                OrderNumber=0
            };

            var testOption2 = new Option
            {
                Id = Guid.Parse("372d0d01-ca28-4fcd-8395-5ffcfe8c9ce1"),
                QuestionId = Guid.Parse("786cef88-a6ac-42e3-994c-e7eed39201a5"),
                Text = "B",
                OrderNumber=1
            };

            var testOption3 = new Option
            {
                Id = Guid.Parse("56b5054b-565a-4ea5-92b9-a4db8c2e6ba3"),
                QuestionId = Guid.Parse("786cef88-a6ac-42e3-994c-e7eed39201a5"),
                Text = "C",
                OrderNumber=2
            };

            var optionQuestion5 = new OptionQuestion
            {
                Id = Guid.Parse("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"),
                FormId = Guid.Parse("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                Text = "Q3:",
                OrderNumber = 2,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var testOption4 = new Option
            {
                Id = Guid.Parse("a640a29e-89be-4ad1-9b13-b46035d724ef"),
                QuestionId = Guid.Parse("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"),
                Text = "A",
                OrderNumber=0
            };

            var testOption5 = new Option
            {
                Id = Guid.Parse("97f2f831-2c0d-4717-8337-d24d2710ecdd"),
                QuestionId = Guid.Parse("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"),
                Text = "B",
                OrderNumber=1
            };

            var testOption6 = new Option
            {
                Id = Guid.Parse("48c526ef-0970-4e7c-b0fb-0f0ef7770c67"),
                QuestionId = Guid.Parse("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"),
                Text = "C",
                OrderNumber=2
            };

            var optionQuestion6 = new OptionQuestion
            {
                Id = Guid.Parse("1e82d528-4898-4c9e-87fb-16c0fdb9843e"),
                FormId = Guid.Parse("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                Text = "Q2:",
                OrderNumber = 1,
                IsRequired = false,
                IsMultipleAnswerAllowed = true
            };

            var testOption7 = new Option
            {
                Id = Guid.Parse("fc61593b-297f-48f5-b626-8b8c1496b095"),
                QuestionId = Guid.Parse("1e82d528-4898-4c9e-87fb-16c0fdb9843e"),
                Text = "A",
                OrderNumber=0
            };

            var testOption8 = new Option
            {
                Id = Guid.Parse("c3f46f23-0b18-4fe7-a00c-5084afd4b032"),
                QuestionId = Guid.Parse("1e82d528-4898-4c9e-87fb-16c0fdb9843e"),
                Text = "B",
                OrderNumber=1
            };

            var testOption9 = new Option
            {
                Id = Guid.Parse("a0d5d390-f70e-43ae-8744-a4762a6a8a0e"),
                QuestionId = Guid.Parse("1e82d528-4898-4c9e-87fb-16c0fdb9843e"),
                Text = "C",
                OrderNumber=2
            };

            var optionQuestion7 = new OptionQuestion
            {
                Id = Guid.Parse("6902a89e-e11c-4800-99d6-b51f66f8ca54"),
                FormId = Guid.Parse("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                Text = "Q1:",
                OrderNumber = 0,
                IsRequired = false,
                IsMultipleAnswerAllowed = false
            };

            var testOption10 = new Option
            {
                Id = Guid.Parse("10c77e0c-b471-47c6-bea7-556d5c88eed7"),
                QuestionId = Guid.Parse("6902a89e-e11c-4800-99d6-b51f66f8ca54"),
                Text = "A",
                OrderNumber=0
            };

            var testOption11 = new Option
            {
                Id = Guid.Parse("0c223fee-5e8e-42b9-85cc-5eae00291d47"),
                QuestionId = Guid.Parse("6902a89e-e11c-4800-99d6-b51f66f8ca54"),
                Text = "B",
                OrderNumber = 1
            };

            var testOption12 = new Option
            {
                Id = Guid.Parse("5d1ff7f7-2a7d-420c-955e-4fccf5589668"),
                QuestionId = Guid.Parse("6902a89e-e11c-4800-99d6-b51f66f8ca54"),
                Text = "C",
                OrderNumber=2
            };

            var optionQuestion8 = new OptionQuestion
            {
                Id = Guid.Parse("87e8c7fd-2bdd-447f-af01-e999bc5273da"),
                FormId = Guid.Parse("72457b91-0923-4f37-bd50-5f8d36e45b3f"),
                Text = "Do you prefer shopping at a large supermarket than ordinary grocery shop?",
                OrderNumber = 0,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion8option1 = new Option
            {
                Id = Guid.Parse("ac2c31ad-5b29-4522-abc2-494193ba0de3"),
                QuestionId = Guid.Parse("87e8c7fd-2bdd-447f-af01-e999bc5273da"),
                Text = "Yes",
                OrderNumber = 0
            };

            var optionQuestion8option2 = new Option
            {
                Id = Guid.Parse("8cbc654a-6d5b-4946-bfdb-ec302f25bd6d"),
                QuestionId = Guid.Parse("87e8c7fd-2bdd-447f-af01-e999bc5273da"),
                Text = "No",
                OrderNumber = 1
            };

            var optionQuestion9 = new OptionQuestion
            {
                Id = Guid.Parse("190bace0-7401-4b62-9aac-8a4c030fcda6"),
                FormId = Guid.Parse("72457b91-0923-4f37-bd50-5f8d36e45b3f"),
                Text = "How many times in a month do you shop at a supermarket?",
                OrderNumber = 1,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion9option1 = new Option
            {
                Id = Guid.Parse("1ef12bca-6bd8-4510-a1b1-618cb209b0a8"),
                QuestionId = Guid.Parse("190bace0-7401-4b62-9aac-8a4c030fcda6"),
                Text = "1-2",
                OrderNumber = 0
            };

            var optionQuestion9option2 = new Option
            {
                Id = Guid.Parse("052d5173-2663-49e6-b074-7d8f8920521d"),
                QuestionId = Guid.Parse("190bace0-7401-4b62-9aac-8a4c030fcda6"),
                Text = "3-5",
                OrderNumber = 1
            };

            var optionQuestion9option3 = new Option
            {
                Id = Guid.Parse("bea6c14a-2de3-4eb2-b09d-b9a007e427de"),
                QuestionId = Guid.Parse("190bace0-7401-4b62-9aac-8a4c030fcda6"),
                Text = "6-10",
                OrderNumber = 2
            };

            var optionQuestion9option4 = new Option
            {
                Id = Guid.Parse("b8687cd5-5b82-4c32-98e0-1cb4e6098acf"),
                QuestionId = Guid.Parse("190bace0-7401-4b62-9aac-8a4c030fcda6"),
                Text = "10+",
                OrderNumber = 3
            };

            var optionQuestion10 = new OptionQuestion
            {
                Id = Guid.Parse("f9e210b1-0b55-4283-be83-48c853ebe6f9"),
                FormId = Guid.Parse("72457b91-0923-4f37-bd50-5f8d36e45b3f"),
                Text = "How do you rate the customer service received from supermarkets?",
                OrderNumber = 2,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion10option1 = new Option
            {
                Id = Guid.Parse("9c3e2182-9866-414e-a4c1-aa256ce1d6bd"),
                QuestionId = Guid.Parse("f9e210b1-0b55-4283-be83-48c853ebe6f9"),
                Text = "Poor",
                OrderNumber = 0
            };

            var optionQuestion10option2 = new Option
            {
                Id = Guid.Parse("1d7e8aef-c346-4bda-8850-e36ef5fdba87"),
                QuestionId = Guid.Parse("f9e210b1-0b55-4283-be83-48c853ebe6f9"),
                Text = "Fair",
                OrderNumber = 1
            };

            var optionQuestion10option3 = new Option
            {
                Id = Guid.Parse("c1a7e98a-b9cc-4e7b-911a-8feda7a76201"),
                QuestionId = Guid.Parse("f9e210b1-0b55-4283-be83-48c853ebe6f9"),
                Text = "Good",
                OrderNumber = 2
            };

            var optionQuestion10option4 = new Option
            {
                Id = Guid.Parse("133d6004-034c-4e51-80fc-01bc4ffc891e"),
                QuestionId = Guid.Parse("f9e210b1-0b55-4283-be83-48c853ebe6f9"),
                Text = "Excellent",
                OrderNumber = 3
            };

            var optionQuestion11 = new OptionQuestion
            {
                Id = Guid.Parse("32b5c63a-c068-43bd-8a15-21520e33d314"),
                FormId = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Text = "How many times in a month do you visit our supermarket?",
                OrderNumber = 1,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion11option1 = new Option
            {
                Id = Guid.Parse("f17ce540-5ad7-47e6-a8ae-6fd18692092d"),
                QuestionId = Guid.Parse("32b5c63a-c068-43bd-8a15-21520e33d314"),
                Text = "1-2",
                OrderNumber = 0
            };

            var optionQuestion11option2 = new Option
            {
                Id = Guid.Parse("7e9a6651-8f5f-43a7-be05-2808b0b50fdf"),
                QuestionId = Guid.Parse("32b5c63a-c068-43bd-8a15-21520e33d314"),
                Text = "3-5",
                OrderNumber = 1
            };

            var optionQuestion11option3 = new Option
            {
                Id = Guid.Parse("038acddc-e630-4064-8f12-8dc94cb4e8f9"),
                QuestionId = Guid.Parse("32b5c63a-c068-43bd-8a15-21520e33d314"),
                Text = "6-10",
                OrderNumber = 2
            };

            var optionQuestion11option4 = new Option
            {
                Id = Guid.Parse("3c56c096-4706-4dd4-8af9-95f033cb7999"),
                QuestionId = Guid.Parse("32b5c63a-c068-43bd-8a15-21520e33d314"),
                Text = "10+",
                OrderNumber = 3
            };

            var optionQuestion12 = new OptionQuestion
            {
                Id = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                FormId = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Text = "Whay type of products do you buy from us?",
                OrderNumber = 2,
                IsRequired = true,
                IsMultipleAnswerAllowed = true
            };

            var optionQuestion12option1 = new Option
            {
                Id = Guid.Parse("6188e06f-b624-471f-888e-ba2f865ca997"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Fruits and vegetables",
                OrderNumber = 0
            };

            var optionQuestion12option2 = new Option
            {
                Id = Guid.Parse("342097db-2f30-4fcd-a938-4bc086671a59"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Meat and seafood",
                OrderNumber = 1
            };

            var optionQuestion12option3 = new Option
            {
                Id = Guid.Parse("67776354-3d29-4312-ad73-48351f3e0824"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Bread and bakery",
                OrderNumber = 2
            };

            var optionQuestion12option4 = new Option
            {
                Id = Guid.Parse("922dc7c9-d5af-48d6-b687-fe9fb9ffcd49"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Beverages",
                OrderNumber = 3
            };

            var optionQuestion12option5 = new Option
            {
                Id = Guid.Parse("2b05d0f2-3f40-4ec6-b4cf-5204d75d18b1"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Dairy products",
                OrderNumber = 4
            };

            var optionQuestion12option6 = new Option
            {
                Id = Guid.Parse("5bc8aab3-03c5-427e-a33f-a971f49dac13"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Cleaning supplies",
                OrderNumber = 5
            };

            var optionQuestion12option7 = new Option
            {
                Id = Guid.Parse("253f0754-0300-484a-9885-73fc3a287469"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Personal care",
                OrderNumber = 6
            };

            var optionQuestion12option8 = new Option
            {
                Id = Guid.Parse("297bd6b7-2208-4a63-a7aa-8c8ebaea1019"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Alcohol and tobacco",
                OrderNumber = 7
            };

            var optionQuestion12option9 = new Option
            {
                Id = Guid.Parse("797db57f-d079-4d0c-ad98-18f49354d3a1"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Pet food",
                OrderNumber = 8
            };

            var optionQuestion12option10 = new Option
            {
                Id = Guid.Parse("379cd70e-5c9e-406e-8810-6ef89b67d2f7"),
                QuestionId = Guid.Parse("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"),
                Text = "Other",
                OrderNumber = 9
            };

            var optionQuestion13 = new OptionQuestion
            {
                Id = Guid.Parse("39f2c367-eeb8-4111-982f-7174fec31540"),
                FormId = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Text = "How do you rate the customer service received from supermarkets?",
                OrderNumber = 3,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion13option1 = new Option
            {
                Id = Guid.Parse("10a6f9ed-8809-4847-94c2-3b0b980bb8e5"),
                QuestionId = Guid.Parse("39f2c367-eeb8-4111-982f-7174fec31540"),
                Text = "Poor",
                OrderNumber = 0
            };

            var optionQuestion13option2 = new Option
            {
                Id = Guid.Parse("44da9d26-0a3c-4ca6-b45e-5a32daaab580"),
                QuestionId = Guid.Parse("39f2c367-eeb8-4111-982f-7174fec31540"),
                Text = "Fair",
                OrderNumber = 1
            };

            var optionQuestion13option3 = new Option
            {
                Id = Guid.Parse("49f771e0-eb4e-49cb-bfee-ee1b298963a0"),
                QuestionId = Guid.Parse("39f2c367-eeb8-4111-982f-7174fec31540"),
                Text = "Good",
                OrderNumber = 2
            };

            var optionQuestion13option4 = new Option
            {
                Id = Guid.Parse("528da9c0-d33e-4fce-8720-33e756c6e697"),
                QuestionId = Guid.Parse("39f2c367-eeb8-4111-982f-7174fec31540"),
                Text = "Excellent",
                OrderNumber = 3
            };

            var optionQuestion14 = new OptionQuestion
            {
                Id = Guid.Parse("590a9d16-1cbd-436e-809c-2a27a043d225"),
                FormId = Guid.Parse("b75902be-238c-4b5f-9b6f-bea1cf0cc401"),
                Text = "What do you think of our prices?",
                OrderNumber = 4,
                IsRequired = true,
                IsMultipleAnswerAllowed = false
            };

            var optionQuestion14option1 = new Option
            {
                Id = Guid.Parse("c4bc4a9f-00d9-4f78-ab34-3030a3f5bee8"),
                QuestionId = Guid.Parse("590a9d16-1cbd-436e-809c-2a27a043d225"),
                Text = "Overpriced",
                OrderNumber = 0
            };

            var optionQuestion14option2 = new Option
            {
                Id = Guid.Parse("af04e192-2898-458c-86d1-fdb6a0361857"),
                QuestionId = Guid.Parse("590a9d16-1cbd-436e-809c-2a27a043d225"),
                Text = "Reasonable",
                OrderNumber = 1
            };

            var optionQuestion14option3 = new Option
            {
                Id = Guid.Parse("769db045-751e-4c0d-8c59-c862df5be2d8"),
                QuestionId = Guid.Parse("590a9d16-1cbd-436e-809c-2a27a043d225"),
                Text = "Low-priced",
                OrderNumber = 2
            };

            builder.Entity<OptionQuestion>().HasData(optionQuestion1, optionQuestion2, optionQuestion3, 
                optionQuestion4, optionQuestion5, optionQuestion6, optionQuestion7,
                optionQuestion8, optionQuestion9, optionQuestion10,
                optionQuestion11, optionQuestion12, optionQuestion13, optionQuestion14);
            builder.Entity<Option>().HasData(optionQuestion1option1, optionQuestion1option2, optionQuestion1option3, optionQuestion1option4,
                optionQuestion2option1, optionQuestion2option2, optionQuestion2option3, optionQuestion2option4, optionQuestion2option5, optionQuestion2option6, optionQuestion2option7, optionQuestion2option8, optionQuestion2option9, optionQuestion2option10,
                optionQuestion3option1, optionQuestion3option2, optionQuestion3option3,
                testOption1, testOption2, testOption3, testOption4, testOption5, testOption6, testOption7, testOption8, testOption9, testOption10, testOption11, testOption12,
                optionQuestion8option1, optionQuestion8option2, optionQuestion9option1, optionQuestion9option2, optionQuestion9option3, optionQuestion9option4, optionQuestion10option1, optionQuestion10option2, optionQuestion10option3, optionQuestion10option4,
                optionQuestion11option1, optionQuestion11option2, optionQuestion11option3, optionQuestion11option4,
                optionQuestion12option1, optionQuestion12option2, optionQuestion12option3, optionQuestion12option4, optionQuestion12option5, optionQuestion12option6, optionQuestion12option7, optionQuestion12option8, optionQuestion12option9, optionQuestion12option10,
                optionQuestion13option1, optionQuestion13option2, optionQuestion13option3, optionQuestion13option4,
                optionQuestion14option1, optionQuestion14option2, optionQuestion14option3);
        }
        public static void RelationshipSetter(this ModelBuilder model)
        {
            foreach (var relationship in model.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
