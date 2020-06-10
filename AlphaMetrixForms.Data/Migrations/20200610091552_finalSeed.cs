using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class finalSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "98a24703-3d11-4d13-852f-bb220d01bb7d", new DateTime(2020, 6, 10, 9, 15, 52, 82, DateTimeKind.Utc).AddTicks(2490), "AQAAAAEAACcQAAAAEAhCg3ItUeLdrsmjpJSSUlwAFD8hmzxuA9LYh6OmB8FbP0rYrBZ1wGzevid241t42Q==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2f3ffe43-1901-4ec5-919b-6787d5cc16f4"), 0, "d474c375-7203-4a40-8d9f-c8ca01a366c0", new DateTime(2020, 6, 10, 9, 15, 52, 91, DateTimeKind.Utc).AddTicks(8010), null, "johnsmith@supermarket.com", false, false, false, null, null, "JOHNSMITH@SUPERMARKET.COM", "JOHNSMITH", "AQAAAAEAACcQAAAAECPgdZZMtmitmiKOgRy/ozxFIev1oVRTyN6pZtCQ7dlMxeB2h92fIg8+k93LDIRSKA==", null, false, "DC6E275DD1E24957A7781D42BB68293C", false, "JohnSmith" },
                    { new Guid("3ff82bae-c8d2-4102-aaab-a4a0e8b5c086"), 0, "334c1355-6993-4135-ad45-1e5881480222", new DateTime(2020, 6, 10, 9, 15, 52, 97, DateTimeKind.Utc).AddTicks(682), null, "bankmanager@bbank.com", false, false, false, null, null, "BANKMANAGER@BBANK.COM", "BANKMANAGER", "AQAAAAEAACcQAAAAEH6VxB7t5p4r6IVicVLCTxec1/guD6Ty5uidjpMeGYFoJw3c+Sollv7SVFTvSZKDRQ==", null, false, "DC6E275DD1E24957A7781D42BB68293D", false, "BankManager" }
                });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 10, 9, 15, 52, 103, DateTimeKind.Utc).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 10, 9, 15, 52, 103, DateTimeKind.Utc).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 10, 9, 15, 52, 103, DateTimeKind.Utc).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("02627001-cae2-4189-a774-5f2b1876f37c"),
                column: "Text",
                value: "Please choose for how long have you been a customer of BBank:");

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("29413352-774c-4cf4-8093-c0b733a95194"),
                column: "Text",
                value: "Which products of BBank are you using:");

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                column: "Text",
                value: "Are you considering changing BBank as your servicing bank:");

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"),
                column: "Text",
                value: "Are you satisfied with the services provided by BBank in overall:");

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                columns: new[] { "CreatedOn", "Description", "OwnerId" },
                values: new object[] { new DateTime(2020, 6, 10, 9, 15, 52, 103, DateTimeKind.Utc).AddTicks(5545), "Questionnaire initiated by BBank in order to improve their services.", new Guid("3ff82bae-c8d2-4102-aaab-a4a0e8b5c086") });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "OwnerId", "Title" },
                values: new object[] { new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), new DateTime(2020, 6, 10, 9, 15, 52, 103, DateTimeKind.Utc).AddTicks(5881), null, "A brief questionnaire on client experience which will help improving the services of Smith's supermarkets.", false, null, new Guid("2f3ffe43-1901-4ec5-919b-6787d5cc16f4"), "Customer satisfaction" });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "OwnerId", "Title" },
                values: new object[] { new Guid("72457b91-0923-4f37-bd50-5f8d36e45b3f"), new DateTime(2020, 6, 10, 9, 15, 52, 103, DateTimeKind.Utc).AddTicks(5877), null, "Market research on customer behaviour in supermarkets and grocery stores.", false, null, new Guid("2f3ffe43-1901-4ec5-919b-6787d5cc16f4"), "Customers in supermarkets" });

            migrationBuilder.InsertData(
                table: "DocumentQuestions",
                columns: new[] { "Id", "FileNumberLimit", "FileSizeLimit", "FormId", "IsRequired", "OrderNumber", "Text" },
                values: new object[] { new Guid("fbc627f0-f7cd-49e2-b329-644b6520ef58"), 1, 10, new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), false, 5, "Upload a photo from our supermarkets and win a prize:" });

            migrationBuilder.InsertData(
                table: "OptionQuestions",
                columns: new[] { "Id", "FormId", "IsMultipleAnswerAllowed", "IsRequired", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("87e8c7fd-2bdd-447f-af01-e999bc5273da"), new Guid("72457b91-0923-4f37-bd50-5f8d36e45b3f"), false, true, 0, "Do you prefer shopping at a large supermarket than ordinary grocery shop?" },
                    { new Guid("190bace0-7401-4b62-9aac-8a4c030fcda6"), new Guid("72457b91-0923-4f37-bd50-5f8d36e45b3f"), false, true, 1, "How many times in a month do you shop at a supermarket?" },
                    { new Guid("f9e210b1-0b55-4283-be83-48c853ebe6f9"), new Guid("72457b91-0923-4f37-bd50-5f8d36e45b3f"), false, true, 2, "How do you rate the customer service received from supermarkets?" },
                    { new Guid("32b5c63a-c068-43bd-8a15-21520e33d314"), new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), false, true, 1, "How many times in a month do you visit our supermarket?" },
                    { new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), true, true, 2, "Whay type of products do you buy from us?" },
                    { new Guid("39f2c367-eeb8-4111-982f-7174fec31540"), new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), false, true, 3, "How do you rate the customer service received from supermarkets?" },
                    { new Guid("590a9d16-1cbd-436e-809c-2a27a043d225"), new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), false, true, 4, "What do you think of our prices?" }
                });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "FormId", "IsLongAnswer", "IsRequired", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("b588fe45-b95f-4a53-ae2b-96d27097f595"), new Guid("72457b91-0923-4f37-bd50-5f8d36e45b3f"), true, true, 3, "What features do you look for shopping at a supermarket—i.e. price, quality of product, variety of product, branding etc?" },
                    { new Guid("7c6649e9-467c-4d97-812f-7de4acc79df7"), new Guid("72457b91-0923-4f37-bd50-5f8d36e45b3f"), true, false, 4, "What would make your shopping experience better?" },
                    { new Guid("e2f1fe9a-ca1b-4e3d-ba34-68502cd487d6"), new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), false, true, 0, "Please share your name:" },
                    { new Guid("b4d808d6-6c1a-4753-9f4b-5f185b43de26"), new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"), true, false, 6, "Any additional feedback is more than welcome:" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "OrderNumber", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("ac2c31ad-5b29-4522-abc2-494193ba0de3"), 0, new Guid("87e8c7fd-2bdd-447f-af01-e999bc5273da"), "Yes" },
                    { new Guid("c4bc4a9f-00d9-4f78-ab34-3030a3f5bee8"), 0, new Guid("590a9d16-1cbd-436e-809c-2a27a043d225"), "Overpriced" },
                    { new Guid("528da9c0-d33e-4fce-8720-33e756c6e697"), 3, new Guid("39f2c367-eeb8-4111-982f-7174fec31540"), "Excellent" },
                    { new Guid("49f771e0-eb4e-49cb-bfee-ee1b298963a0"), 2, new Guid("39f2c367-eeb8-4111-982f-7174fec31540"), "Good" },
                    { new Guid("44da9d26-0a3c-4ca6-b45e-5a32daaab580"), 1, new Guid("39f2c367-eeb8-4111-982f-7174fec31540"), "Fair" },
                    { new Guid("10a6f9ed-8809-4847-94c2-3b0b980bb8e5"), 0, new Guid("39f2c367-eeb8-4111-982f-7174fec31540"), "Poor" },
                    { new Guid("379cd70e-5c9e-406e-8810-6ef89b67d2f7"), 9, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Other" },
                    { new Guid("797db57f-d079-4d0c-ad98-18f49354d3a1"), 8, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Pet food" },
                    { new Guid("297bd6b7-2208-4a63-a7aa-8c8ebaea1019"), 7, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Alcohol and tobacco" },
                    { new Guid("253f0754-0300-484a-9885-73fc3a287469"), 6, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Personal care" },
                    { new Guid("5bc8aab3-03c5-427e-a33f-a971f49dac13"), 5, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Cleaning supplies" },
                    { new Guid("2b05d0f2-3f40-4ec6-b4cf-5204d75d18b1"), 4, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Dairy products" },
                    { new Guid("922dc7c9-d5af-48d6-b687-fe9fb9ffcd49"), 3, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Beverages" },
                    { new Guid("67776354-3d29-4312-ad73-48351f3e0824"), 2, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Bread and bakery" },
                    { new Guid("af04e192-2898-458c-86d1-fdb6a0361857"), 1, new Guid("590a9d16-1cbd-436e-809c-2a27a043d225"), "Reasonable" },
                    { new Guid("342097db-2f30-4fcd-a938-4bc086671a59"), 1, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Meat and seafood" },
                    { new Guid("3c56c096-4706-4dd4-8af9-95f033cb7999"), 3, new Guid("32b5c63a-c068-43bd-8a15-21520e33d314"), "10+" },
                    { new Guid("038acddc-e630-4064-8f12-8dc94cb4e8f9"), 2, new Guid("32b5c63a-c068-43bd-8a15-21520e33d314"), "6-10" },
                    { new Guid("7e9a6651-8f5f-43a7-be05-2808b0b50fdf"), 1, new Guid("32b5c63a-c068-43bd-8a15-21520e33d314"), "3-5" },
                    { new Guid("f17ce540-5ad7-47e6-a8ae-6fd18692092d"), 0, new Guid("32b5c63a-c068-43bd-8a15-21520e33d314"), "1-2" },
                    { new Guid("133d6004-034c-4e51-80fc-01bc4ffc891e"), 3, new Guid("f9e210b1-0b55-4283-be83-48c853ebe6f9"), "Excellent" },
                    { new Guid("c1a7e98a-b9cc-4e7b-911a-8feda7a76201"), 2, new Guid("f9e210b1-0b55-4283-be83-48c853ebe6f9"), "Good" },
                    { new Guid("1d7e8aef-c346-4bda-8850-e36ef5fdba87"), 1, new Guid("f9e210b1-0b55-4283-be83-48c853ebe6f9"), "Fair" },
                    { new Guid("9c3e2182-9866-414e-a4c1-aa256ce1d6bd"), 0, new Guid("f9e210b1-0b55-4283-be83-48c853ebe6f9"), "Poor" },
                    { new Guid("b8687cd5-5b82-4c32-98e0-1cb4e6098acf"), 3, new Guid("190bace0-7401-4b62-9aac-8a4c030fcda6"), "10+" },
                    { new Guid("bea6c14a-2de3-4eb2-b09d-b9a007e427de"), 2, new Guid("190bace0-7401-4b62-9aac-8a4c030fcda6"), "6-10" },
                    { new Guid("052d5173-2663-49e6-b074-7d8f8920521d"), 1, new Guid("190bace0-7401-4b62-9aac-8a4c030fcda6"), "3-5" },
                    { new Guid("1ef12bca-6bd8-4510-a1b1-618cb209b0a8"), 0, new Guid("190bace0-7401-4b62-9aac-8a4c030fcda6"), "1-2" },
                    { new Guid("8cbc654a-6d5b-4946-bfdb-ec302f25bd6d"), 1, new Guid("87e8c7fd-2bdd-447f-af01-e999bc5273da"), "No" },
                    { new Guid("6188e06f-b624-471f-888e-ba2f865ca997"), 0, new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"), "Fruits and vegetables" },
                    { new Guid("769db045-751e-4c0d-8c59-c862df5be2d8"), 2, new Guid("590a9d16-1cbd-436e-809c-2a27a043d225"), "Low-priced" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("078f9ce9-8a39-4355-a6c5-de5282df4dce"));

            migrationBuilder.DeleteData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5065d44a-992d-4328-bcf9-56a3f49581d9"));

            migrationBuilder.DeleteData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("75b93e1d-2219-43da-b2d8-f5b985112e43"));

            migrationBuilder.DeleteData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("fbc627f0-f7cd-49e2-b329-644b6520ef58"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("038acddc-e630-4064-8f12-8dc94cb4e8f9"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("052d5173-2663-49e6-b074-7d8f8920521d"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("0b8a2599-2e62-4d2c-aca8-cc6c2a43bab1"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("10a6f9ed-8809-4847-94c2-3b0b980bb8e5"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("133d6004-034c-4e51-80fc-01bc4ffc891e"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1d7e8aef-c346-4bda-8850-e36ef5fdba87"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1ef12bca-6bd8-4510-a1b1-618cb209b0a8"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1f747c49-83d1-4e12-93a4-d4fb94366d3d"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("253f0754-0300-484a-9885-73fc3a287469"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("297bd6b7-2208-4a63-a7aa-8c8ebaea1019"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("2b05d0f2-3f40-4ec6-b4cf-5204d75d18b1"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("342097db-2f30-4fcd-a938-4bc086671a59"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("379cd70e-5c9e-406e-8810-6ef89b67d2f7"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("3c56c096-4706-4dd4-8af9-95f033cb7999"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("40b0b5ca-f281-4919-b323-26ab2b84d720"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("44da9d26-0a3c-4ca6-b45e-5a32daaab580"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("49f771e0-eb4e-49cb-bfee-ee1b298963a0"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("528da9c0-d33e-4fce-8720-33e756c6e697"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("5bc8aab3-03c5-427e-a33f-a971f49dac13"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("6188e06f-b624-471f-888e-ba2f865ca997"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("67776354-3d29-4312-ad73-48351f3e0824"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("769db045-751e-4c0d-8c59-c862df5be2d8"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("797db57f-d079-4d0c-ad98-18f49354d3a1"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("7a36b91e-9454-43cb-8e58-93d493b849ad"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("7e9a6651-8f5f-43a7-be05-2808b0b50fdf"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("80a8e086-9592-4760-bd5b-a1a0ebf6a624"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("85662798-ac15-45c7-96fb-50e77de9d526"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("8cbc654a-6d5b-4946-bfdb-ec302f25bd6d"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("922dc7c9-d5af-48d6-b687-fe9fb9ffcd49"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("99c6498b-e76f-496a-9e2b-beb3e36eb6b6"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("9c3e2182-9866-414e-a4c1-aa256ce1d6bd"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a7a8b2ac-d48a-4e48-98db-2ac2eacb507a"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("ac2c31ad-5b29-4522-abc2-494193ba0de3"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("af04e192-2898-458c-86d1-fdb6a0361857"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("b3ba569b-123e-4f16-9298-3dbe5720207c"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("b73ca574-f326-4bc6-80dc-038ea561ab33"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("b8687cd5-5b82-4c32-98e0-1cb4e6098acf"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("bd0ca49f-c7c3-4401-a225-16d025b13f9b"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("bea6c14a-2de3-4eb2-b09d-b9a007e427de"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c1a7e98a-b9cc-4e7b-911a-8feda7a76201"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c47a949d-e300-4354-b22e-a1615bc6f1a3"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c4bc4a9f-00d9-4f78-ab34-3030a3f5bee8"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c542a866-9b62-4629-8e69-84c4394104c4"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("ca610326-8825-465a-bf9e-634ddbdcaaad"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("cc936706-63b9-4830-95ff-c108a71e13f3"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("d5ff0344-94c4-48fe-9211-8c34e43c9a7e"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("d626cd57-2076-4494-9765-be883e0292de"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("f17ce540-5ad7-47e6-a8ae-6fd18692092d"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("082e946c-a3d2-474f-8765-e933d78e9832"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7c6649e9-467c-4d97-812f-7de4acc79df7"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b4d808d6-6c1a-4753-9f4b-5f185b43de26"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b588fe45-b95f-4a53-ae2b-96d27097f595"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e2f1fe9a-ca1b-4e3d-ba34-68502cd487d6"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("02627001-cae2-4189-a774-5f2b1876f37c"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("190bace0-7401-4b62-9aac-8a4c030fcda6"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("29413352-774c-4cf4-8093-c0b733a95194"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("32b5c63a-c068-43bd-8a15-21520e33d314"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("39f2c367-eeb8-4111-982f-7174fec31540"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3cf381e5-20f4-4297-8c30-1e1e14beeb7e"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("590a9d16-1cbd-436e-809c-2a27a043d225"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("87e8c7fd-2bdd-447f-af01-e999bc5273da"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f9e210b1-0b55-4283-be83-48c853ebe6f9"));

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("72457b91-0923-4f37-bd50-5f8d36e45b3f"));

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"));

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b75902be-238c-4b5f-9b6f-bea1cf0cc401"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2f3ffe43-1901-4ec5-919b-6787d5cc16f4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ff82bae-c8d2-4102-aaab-a4a0e8b5c086"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "bbc19215-301b-48bc-816f-b13e12d64eb5", new DateTime(2020, 6, 10, 7, 50, 30, 89, DateTimeKind.Utc).AddTicks(1124), "AQAAAAEAACcQAAAAENOl11mDRxwOMg+crb8EZc8hik7yiUSxknuvkXjCSao4hnI8cEy9iMHSd8Qic8GtIg==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 10, 7, 50, 30, 100, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 10, 7, 50, 30, 100, DateTimeKind.Utc).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 10, 7, 50, 30, 100, DateTimeKind.Utc).AddTicks(8318));

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "OwnerId", "Title" },
                values: new object[] { new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), new DateTime(2020, 6, 10, 7, 50, 30, 100, DateTimeKind.Utc).AddTicks(7951), null, "Questionnaire initiated by TestBank in order to improve their services.", false, null, new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"), "Banking Services" });

            migrationBuilder.InsertData(
                table: "DocumentQuestions",
                columns: new[] { "Id", "FileNumberLimit", "FileSizeLimit", "FormId", "IsRequired", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("5065d44a-992d-4328-bcf9-56a3f49581d9"), 10, 1000, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, 3, "Additional documents for upload:" },
                    { new Guid("75b93e1d-2219-43da-b2d8-f5b985112e43"), 1, 100, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), true, 2, "Please upload your Token paper certificate:" },
                    { new Guid("078f9ce9-8a39-4355-a6c5-de5282df4dce"), 2, 100, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), true, 1, "Please upload your ID:" }
                });

            migrationBuilder.InsertData(
                table: "OptionQuestions",
                columns: new[] { "Id", "FormId", "IsMultipleAnswerAllowed", "IsRequired", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, false, 6, "Are you considering changing TestBank as your servicing bank:" },
                    { new Guid("29413352-774c-4cf4-8093-c0b733a95194"), new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), true, true, 5, "Which products of TestBank are you using:" },
                    { new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, 4, "Please choose for how long have you been a customer of TestBank:" }
                });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "FormId", "IsLongAnswer", "IsRequired", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("082e946c-a3d2-474f-8765-e933d78e9832"), new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), true, false, 8, "Here you can share feedback for the form:" },
                    { new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"), new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), true, true, 7, "Are you satisfied with the services provided by TestBank in overall:" },
                    { new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"), new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, 0, "Please enter your name:" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "OrderNumber", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("80a8e086-9592-4760-bd5b-a1a0ebf6a624"), 2, new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), "TestBank is not my main servicing bank" },
                    { new Guid("b3ba569b-123e-4f16-9298-3dbe5720207c"), 1, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "1-3 years" },
                    { new Guid("7a36b91e-9454-43cb-8e58-93d493b849ad"), 2, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "3-5 years" },
                    { new Guid("40b0b5ca-f281-4919-b323-26ab2b84d720"), 3, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Overdraft" },
                    { new Guid("0b8a2599-2e62-4d2c-aca8-cc6c2a43bab1"), 4, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Short-term Loan" },
                    { new Guid("c47a949d-e300-4354-b22e-a1615bc6f1a3"), 5, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Long-term Loan" },
                    { new Guid("85662798-ac15-45c7-96fb-50e77de9d526"), 6, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Mortgage" },
                    { new Guid("d5ff0344-94c4-48fe-9211-8c34e43c9a7e"), 0, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "less than 1 year" },
                    { new Guid("a7a8b2ac-d48a-4e48-98db-2ac2eacb507a"), 7, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Savings account" },
                    { new Guid("99c6498b-e76f-496a-9e2b-beb3e36eb6b6"), 9, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Other" },
                    { new Guid("c542a866-9b62-4629-8e69-84c4394104c4"), 0, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Debit Card" },
                    { new Guid("1f747c49-83d1-4e12-93a4-d4fb94366d3d"), 1, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Credit Card" },
                    { new Guid("b73ca574-f326-4bc6-80dc-038ea561ab33"), 2, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Current account" },
                    { new Guid("cc936706-63b9-4830-95ff-c108a71e13f3"), 0, new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), "Yes" },
                    { new Guid("ca610326-8825-465a-bf9e-634ddbdcaaad"), 1, new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), "No" },
                    { new Guid("bd0ca49f-c7c3-4401-a225-16d025b13f9b"), 8, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "E-Banking" },
                    { new Guid("d626cd57-2076-4494-9765-be883e0292de"), 3, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "more than 5 years" }
                });
        }
    }
}
