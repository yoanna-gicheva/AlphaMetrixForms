using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class RemovalOfClosedPropertyInForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Forms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "bbc19215-301b-48bc-816f-b13e12d64eb5", new DateTime(2020, 6, 10, 7, 50, 30, 89, DateTimeKind.Utc).AddTicks(1124), "AQAAAAEAACcQAAAAENOl11mDRxwOMg+crb8EZc8hik7yiUSxknuvkXjCSao4hnI8cEy9iMHSd8Qic8GtIg==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 10, 7, 50, 30, 100, DateTimeKind.Utc).AddTicks(7951));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Forms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "ce1410b9-7677-4c28-963c-e8782136556d", new DateTime(2020, 6, 8, 8, 28, 50, 777, DateTimeKind.Utc).AddTicks(5612), "AQAAAAEAACcQAAAAEKChkow8fFcyTVRJHE/aa/LOaN8+IIkgXXPRKdmZm+spkcMOKYNgjH6TPMc3qY/TjQ==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 28, 50, 793, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 28, 50, 793, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 28, 50, 793, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 28, 50, 793, DateTimeKind.Utc).AddTicks(1594));
        }
    }
}
