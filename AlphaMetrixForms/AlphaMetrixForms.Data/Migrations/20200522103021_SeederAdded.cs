using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class SeederAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"), 0, "f2cc14ff-3261-48ef-aaa0-17b0aeb66a32", new DateTime(2020, 5, 22, 10, 30, 20, 444, DateTimeKind.Utc).AddTicks(7438), null, "user1@user.com", false, false, false, null, null, "USER1@USER.COM", "USER1@USER.COM", "AQAAAAEAACcQAAAAEDDecINPdA4WDhbLGUsd2Unw1//0FGyisi+QHBrp7o357DRskjCoyUEcBtuaI4khLg==", null, false, "DC6E275DD1E24957A7781D42BB68293B", false, "user1@user.com" });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "OwnerId", "Title" },
                values: new object[] { new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), new DateTime(2020, 5, 22, 10, 30, 20, 463, DateTimeKind.Utc).AddTicks(6277), null, "TestDescription", false, null, new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"), "TestForm" });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "FormId", "IsDeleted", "IsLongAnswer", "IsRequired", "ModifiedOn", "Text" },
                values: new object[] { new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"), false, true, true, null, "What is your favourite color?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"));

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"));
        }
    }
}
