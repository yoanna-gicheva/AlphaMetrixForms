using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class SeederAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestionAnswers_DocumentQuestions_DocumentQuestionId",
                table: "DocumentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestionAnswers_Responses_ResponseId",
                table: "DocumentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestions_Forms_FormId",
                table: "DocumentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_AspNetUsers_OwnerId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionQuestionAnswers_OptionQuestions_OptionQuestionId",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionQuestionAnswers_Responses_ResponseId",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionQuestions_Forms_FormId",
                table: "OptionQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_OptionQuestions_QuestionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_TextQuestionAnswers_Responses_ResponseId",
                table: "TextQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextQuestionAnswers_TextQuestions_TextQuestionId",
                table: "TextQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextQuestions_Forms_FormId",
                table: "TextQuestions");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "TextQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "OptionQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Forms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "DocumentQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "b297eef1-9015-4fb2-9a37-917d2921d592", new DateTime(2020, 5, 28, 14, 50, 57, 225, DateTimeKind.Utc).AddTicks(6599), "TESTUSER", "AQAAAAEAACcQAAAAEFB8gzMgvtNAe5W3GL18s0Uh81XRyJwoznU5vvabJ2UfgBk6exAV7Rb7UlDUN46YbA==", "TestUser" });

            migrationBuilder.InsertData(
                table: "DocumentQuestions",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "FileNumberLimit", "FileSizeLimit", "FormId", "IsDeleted", "IsRequired", "ModifiedOn", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("078f9ce9-8a39-4355-a6c5-de5282df4dce"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6690), null, 2, 100, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, null, 2, "Please upload your ID:" },
                    { new Guid("75b93e1d-2219-43da-b2d8-f5b985112e43"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6759), null, 1, 100, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, null, 3, "Please upload your Token paper certificate:" },
                    { new Guid("5065d44a-992d-4328-bcf9-56a3f49581d9"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6764), null, 10, 1000, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, false, null, 4, "Additional documents for upload:" }
                });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(881), "Questionnaire initiated by TestBank in order to improve their services.", "Banking Services" });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsClosed", "IsDeleted", "ModifiedOn", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(1322), null, null, false, false, null, new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"), "Test Question Test" },
                    { new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(1336), null, null, false, false, null, new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"), "Document Question Test" },
                    { new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(1341), null, null, false, false, null, new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"), "Option Question Test" }
                });

            migrationBuilder.InsertData(
                table: "OptionQuestions",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "FormId", "IsDeleted", "IsMultipleAnswerAllowed", "IsRequired", "ModifiedOn", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(9156), null, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, false, true, null, 5, "Please choose for how long have you been a customer of TestBank:" },
                    { new Guid("29413352-774c-4cf4-8093-c0b733a95194"), new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(627), null, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, true, null, 6, "Which products of TestBank are you using:" },
                    { new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(658), null, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, false, false, null, 7, "Are you considering changing TestBank as your servicing bank:" }
                });

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"),
                columns: new[] { "CreatedOn", "IsLongAnswer", "OrderNumber", "Text" },
                values: new object[] { new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3860), false, 1, "Please enter your name:" });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "FormId", "IsDeleted", "IsLongAnswer", "IsRequired", "ModifiedOn", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3937), null, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, true, null, 8, "Are you satisfied with the services provided by TestBank in overall:" },
                    { new Guid("082e946c-a3d2-474f-8765-e933d78e9832"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3943), null, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, false, null, 9, "Here you can share feedback for the form:" }
                });

            migrationBuilder.InsertData(
                table: "DocumentQuestions",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "FileNumberLimit", "FileSizeLimit", "FormId", "IsDeleted", "IsRequired", "ModifiedOn", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("a08236d6-1576-4780-98ec-b00b470a5b1e"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6768), null, 1, 1, new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"), false, true, null, 1, "Q1:" },
                    { new Guid("ad686787-e762-4b05-aa40-bab8f8deb4c0"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6771), null, 10, 10, new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"), false, false, null, 2, "Q2:" }
                });

            migrationBuilder.InsertData(
                table: "OptionQuestions",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "FormId", "IsDeleted", "IsMultipleAnswerAllowed", "IsRequired", "ModifiedOn", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"), new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(669), null, new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"), false, true, true, null, 4, "Q4:" },
                    { new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"), new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(681), null, new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"), false, false, true, null, 3, "Q3:" },
                    { new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"), new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(692), null, new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"), false, true, false, null, 2, "Q2:" },
                    { new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"), new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(701), null, new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"), false, false, false, null, 1, "Q1:" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("d626cd57-2076-4494-9765-be883e0292de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "more than 5 years" },
                    { new Guid("cc936706-63b9-4830-95ff-c108a71e13f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), "Yes" },
                    { new Guid("99c6498b-e76f-496a-9e2b-beb3e36eb6b6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Other" },
                    { new Guid("bd0ca49f-c7c3-4401-a225-16d025b13f9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "E-Banking" },
                    { new Guid("a7a8b2ac-d48a-4e48-98db-2ac2eacb507a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Savings account" },
                    { new Guid("85662798-ac15-45c7-96fb-50e77de9d526"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Mortgage" },
                    { new Guid("c47a949d-e300-4354-b22e-a1615bc6f1a3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Long-term Loan" },
                    { new Guid("0b8a2599-2e62-4d2c-aca8-cc6c2a43bab1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Short-term Loan" },
                    { new Guid("40b0b5ca-f281-4919-b323-26ab2b84d720"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Overdraft" },
                    { new Guid("b73ca574-f326-4bc6-80dc-038ea561ab33"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Current account" },
                    { new Guid("80a8e086-9592-4760-bd5b-a1a0ebf6a624"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), "TestBank is not my main servicing bank" },
                    { new Guid("c542a866-9b62-4629-8e69-84c4394104c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Debit Card" },
                    { new Guid("ca610326-8825-465a-bf9e-634ddbdcaaad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"), "No" },
                    { new Guid("7a36b91e-9454-43cb-8e58-93d493b849ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "3-5 years" },
                    { new Guid("b3ba569b-123e-4f16-9298-3dbe5720207c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "1-3 years" },
                    { new Guid("d5ff0344-94c4-48fe-9211-8c34e43c9a7e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("02627001-cae2-4189-a774-5f2b1876f37c"), "less than 1 year" },
                    { new Guid("1f747c49-83d1-4e12-93a4-d4fb94366d3d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("29413352-774c-4cf4-8093-c0b733a95194"), "Credit Card" }
                });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "FormId", "IsDeleted", "IsLongAnswer", "IsRequired", "ModifiedOn", "OrderNumber", "Text" },
                values: new object[,]
                {
                    { new Guid("a25cc7e3-2298-4fa6-8dd8-e3147a64464a"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3986), null, new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"), false, true, true, null, 3, "Q3:" },
                    { new Guid("1a7e99da-687f-4fc3-b9a8-abed0adb5526"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3983), null, new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"), false, false, true, null, 1, "Q1:" },
                    { new Guid("00db1b7c-9616-4b03-9435-a3c915f96412"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3979), null, new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"), false, true, false, null, 2, "Q2:" },
                    { new Guid("1ea514f3-b6b2-4ada-9a69-1d68cad75349"), new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3946), null, new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"), false, false, false, null, 4, "Q4:" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("1a65e090-bec7-4388-a9dc-521ee062fc25"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"), "A" },
                    { new Guid("372d0d01-ca28-4fcd-8395-5ffcfe8c9ce1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"), "B" },
                    { new Guid("56b5054b-565a-4ea5-92b9-a4db8c2e6ba3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"), "C" },
                    { new Guid("a640a29e-89be-4ad1-9b13-b46035d724ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"), "A" },
                    { new Guid("97f2f831-2c0d-4717-8337-d24d2710ecdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"), "B" },
                    { new Guid("48c526ef-0970-4e7c-b0fb-0f0ef7770c67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"), "C" },
                    { new Guid("fc61593b-297f-48f5-b626-8b8c1496b095"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"), "A" },
                    { new Guid("c3f46f23-0b18-4fe7-a00c-5084afd4b032"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"), "B" },
                    { new Guid("a0d5d390-f70e-43ae-8744-a4762a6a8a0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"), "C" },
                    { new Guid("10c77e0c-b471-47c6-bea7-556d5c88eed7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"), "A" },
                    { new Guid("0c223fee-5e8e-42b9-85cc-5eae00291d47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"), "B" },
                    { new Guid("5d1ff7f7-2a7d-420c-955e-4fccf5589668"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"), "C" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestionAnswers_DocumentQuestions_DocumentQuestionId",
                table: "DocumentQuestionAnswers",
                column: "DocumentQuestionId",
                principalTable: "DocumentQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestionAnswers_Responses_ResponseId",
                table: "DocumentQuestionAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestions_Forms_FormId",
                table: "DocumentQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_AspNetUsers_OwnerId",
                table: "Forms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionQuestionAnswers_OptionQuestions_OptionQuestionId",
                table: "OptionQuestionAnswers",
                column: "OptionQuestionId",
                principalTable: "OptionQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionQuestionAnswers_Responses_ResponseId",
                table: "OptionQuestionAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionQuestions_Forms_FormId",
                table: "OptionQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_OptionQuestions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "OptionQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextQuestionAnswers_Responses_ResponseId",
                table: "TextQuestionAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextQuestionAnswers_TextQuestions_TextQuestionId",
                table: "TextQuestionAnswers",
                column: "TextQuestionId",
                principalTable: "TextQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextQuestions_Forms_FormId",
                table: "TextQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestionAnswers_DocumentQuestions_DocumentQuestionId",
                table: "DocumentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestionAnswers_Responses_ResponseId",
                table: "DocumentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestions_Forms_FormId",
                table: "DocumentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_AspNetUsers_OwnerId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionQuestionAnswers_OptionQuestions_OptionQuestionId",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionQuestionAnswers_Responses_ResponseId",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionQuestions_Forms_FormId",
                table: "OptionQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_OptionQuestions_QuestionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_TextQuestionAnswers_Responses_ResponseId",
                table: "TextQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextQuestionAnswers_TextQuestions_TextQuestionId",
                table: "TextQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextQuestions_Forms_FormId",
                table: "TextQuestions");

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
                keyValue: new Guid("a08236d6-1576-4780-98ec-b00b470a5b1e"));

            migrationBuilder.DeleteData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ad686787-e762-4b05-aa40-bab8f8deb4c0"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("0b8a2599-2e62-4d2c-aca8-cc6c2a43bab1"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("0c223fee-5e8e-42b9-85cc-5eae00291d47"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("10c77e0c-b471-47c6-bea7-556d5c88eed7"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1a65e090-bec7-4388-a9dc-521ee062fc25"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1f747c49-83d1-4e12-93a4-d4fb94366d3d"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("372d0d01-ca28-4fcd-8395-5ffcfe8c9ce1"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("40b0b5ca-f281-4919-b323-26ab2b84d720"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("48c526ef-0970-4e7c-b0fb-0f0ef7770c67"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("56b5054b-565a-4ea5-92b9-a4db8c2e6ba3"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("5d1ff7f7-2a7d-420c-955e-4fccf5589668"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("7a36b91e-9454-43cb-8e58-93d493b849ad"));

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
                keyValue: new Guid("97f2f831-2c0d-4717-8337-d24d2710ecdd"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("99c6498b-e76f-496a-9e2b-beb3e36eb6b6"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a0d5d390-f70e-43ae-8744-a4762a6a8a0e"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a640a29e-89be-4ad1-9b13-b46035d724ef"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a7a8b2ac-d48a-4e48-98db-2ac2eacb507a"));

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
                keyValue: new Guid("bd0ca49f-c7c3-4401-a225-16d025b13f9b"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c3f46f23-0b18-4fe7-a00c-5084afd4b032"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c47a949d-e300-4354-b22e-a1615bc6f1a3"));

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
                keyValue: new Guid("fc61593b-297f-48f5-b626-8b8c1496b095"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("00db1b7c-9616-4b03-9435-a3c915f96412"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("082e946c-a3d2-474f-8765-e933d78e9832"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1a7e99da-687f-4fc3-b9a8-abed0adb5526"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1ea514f3-b6b2-4ada-9a69-1d68cad75349"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a25cc7e3-2298-4fa6-8dd8-e3147a64464a"));

            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"));

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"));

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("02627001-cae2-4189-a774-5f2b1876f37c"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("29413352-774c-4cf4-8093-c0b733a95194"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"));

            migrationBuilder.DeleteData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"));

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"));

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "TextQuestions");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "OptionQuestions");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "DocumentQuestions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "7a57d818-da90-43d9-8fca-c6124a106176", new DateTime(2020, 5, 27, 13, 33, 7, 753, DateTimeKind.Utc).AddTicks(9887), "USER1@USER.COM", "AQAAAAEAACcQAAAAEFvA9azzNDb44laUv8ekClPk+iqSnTaDQfEJv09POM3Ye9+XnSlC9/HdzPRf8WaatA==", "user1@user.com" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2020, 5, 27, 13, 33, 7, 767, DateTimeKind.Utc).AddTicks(7628), "TestDescription", "TestForm" });

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"),
                columns: new[] { "CreatedOn", "IsLongAnswer", "Text" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "What is your favourite color?" });

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestionAnswers_DocumentQuestions_DocumentQuestionId",
                table: "DocumentQuestionAnswers",
                column: "DocumentQuestionId",
                principalTable: "DocumentQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestionAnswers_Responses_ResponseId",
                table: "DocumentQuestionAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestions_Forms_FormId",
                table: "DocumentQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_AspNetUsers_OwnerId",
                table: "Forms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionQuestionAnswers_OptionQuestions_OptionQuestionId",
                table: "OptionQuestionAnswers",
                column: "OptionQuestionId",
                principalTable: "OptionQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionQuestionAnswers_Responses_ResponseId",
                table: "OptionQuestionAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionQuestions_Forms_FormId",
                table: "OptionQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_OptionQuestions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "OptionQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TextQuestionAnswers_Responses_ResponseId",
                table: "TextQuestionAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TextQuestionAnswers_TextQuestions_TextQuestionId",
                table: "TextQuestionAnswers",
                column: "TextQuestionId",
                principalTable: "TextQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TextQuestions_Forms_FormId",
                table: "TextQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
