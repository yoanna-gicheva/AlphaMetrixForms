using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class SeederAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "7a57d818-da90-43d9-8fca-c6124a106176", new DateTime(2020, 5, 27, 13, 33, 7, 753, DateTimeKind.Utc).AddTicks(9887), "AQAAAAEAACcQAAAAEFvA9azzNDb44laUv8ekClPk+iqSnTaDQfEJv09POM3Ye9+XnSlC9/HdzPRf8WaatA==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 27, 13, 33, 7, 767, DateTimeKind.Utc).AddTicks(7628));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "f2cc14ff-3261-48ef-aaa0-17b0aeb66a32", new DateTime(2020, 5, 22, 10, 30, 20, 444, DateTimeKind.Utc).AddTicks(7438), "AQAAAAEAACcQAAAAEDDecINPdA4WDhbLGUsd2Unw1//0FGyisi+QHBrp7o357DRskjCoyUEcBtuaI4khLg==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 22, 10, 30, 20, 463, DateTimeKind.Utc).AddTicks(6277));
        }
    }
}
