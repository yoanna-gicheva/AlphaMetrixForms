using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class AddPrimaryKeyToAnswerEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TextQuestionAnswers",
                table: "TextQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionQuestionAnswers",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentQuestionAnswers",
                table: "DocumentQuestionAnswers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TextQuestionAnswers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OptionQuestionAnswers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DocumentQuestionAnswers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextQuestionAnswers",
                table: "TextQuestionAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionQuestionAnswers",
                table: "OptionQuestionAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentQuestionAnswers",
                table: "DocumentQuestionAnswers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "5d7fb9b2-d177-462e-96d9-1464e975d64d", new DateTime(2020, 6, 3, 18, 30, 50, 414, DateTimeKind.Utc).AddTicks(6916), "AQAAAAEAACcQAAAAEPo7m6MDc3qkoZSFot7ps5/PvYihdMeHEtavkFINe8NLt++5FTYgODvYADM8QDy5kQ==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 18, 30, 50, 432, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 18, 30, 50, 432, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 18, 30, 50, 432, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 18, 30, 50, 432, DateTimeKind.Utc).AddTicks(5023));

            migrationBuilder.CreateIndex(
                name: "IX_TextQuestionAnswers_TextQuestionId",
                table: "TextQuestionAnswers",
                column: "TextQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionQuestionAnswers_OptionQuestionId",
                table: "OptionQuestionAnswers",
                column: "OptionQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentQuestionAnswers_DocumentQuestionId",
                table: "DocumentQuestionAnswers",
                column: "DocumentQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TextQuestionAnswers",
                table: "TextQuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TextQuestionAnswers_TextQuestionId",
                table: "TextQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionQuestionAnswers",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_OptionQuestionAnswers_OptionQuestionId",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentQuestionAnswers",
                table: "DocumentQuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_DocumentQuestionAnswers_DocumentQuestionId",
                table: "DocumentQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TextQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OptionQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DocumentQuestionAnswers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextQuestionAnswers",
                table: "TextQuestionAnswers",
                columns: new[] { "TextQuestionId", "ResponseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionQuestionAnswers",
                table: "OptionQuestionAnswers",
                columns: new[] { "OptionQuestionId", "ResponseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentQuestionAnswers",
                table: "DocumentQuestionAnswers",
                columns: new[] { "DocumentQuestionId", "ResponseId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "e834635a-69c4-4137-a6cf-f9f62a5e5223", new DateTime(2020, 6, 3, 14, 35, 59, 394, DateTimeKind.Utc).AddTicks(638), "AQAAAAEAACcQAAAAEDmE4LwX41nVN0gqS02Cf4bWVxHr23jeRf/ChR/D5albeXIfvb3IkY16ivoZL+9zgA==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 14, 35, 59, 412, DateTimeKind.Utc).AddTicks(134));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 14, 35, 59, 412, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 14, 35, 59, 412, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 3, 14, 35, 59, 412, DateTimeKind.Utc).AddTicks(651));
        }
    }
}
