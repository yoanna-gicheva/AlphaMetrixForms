using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class SeederUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "c0c1392e-6bd8-4241-aea7-61a0b9b62fc4", new DateTime(2020, 6, 8, 8, 23, 55, 932, DateTimeKind.Utc).AddTicks(6330), "AQAAAAEAACcQAAAAEOm+6lfQdTerEmxF1SuNixUaEDdOYFvnCAS/MzFZxkK5/SepYjkbvaRh2ZB3wPsljA==" });

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("078f9ce9-8a39-4355-a6c5-de5282df4dce"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5065d44a-992d-4328-bcf9-56a3f49581d9"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("75b93e1d-2219-43da-b2d8-f5b985112e43"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 23, 55, 948, DateTimeKind.Utc).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 23, 55, 948, DateTimeKind.Utc).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 23, 55, 948, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 8, 8, 23, 55, 948, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("02627001-cae2-4189-a774-5f2b1876f37c"),
                column: "OrderNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("29413352-774c-4cf4-8093-c0b733a95194"),
                column: "OrderNumber",
                value: 5);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                column: "OrderNumber",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("082e946c-a3d2-474f-8765-e933d78e9832"),
                column: "OrderNumber",
                value: 8);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"),
                column: "OrderNumber",
                value: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "5d7fb9b2-d177-462e-96d9-1464e975d64d", new DateTime(2020, 6, 3, 18, 30, 50, 414, DateTimeKind.Utc).AddTicks(6916), "AQAAAAEAACcQAAAAEPo7m6MDc3qkoZSFot7ps5/PvYihdMeHEtavkFINe8NLt++5FTYgODvYADM8QDy5kQ==" });

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("078f9ce9-8a39-4355-a6c5-de5282df4dce"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5065d44a-992d-4328-bcf9-56a3f49581d9"),
                column: "OrderNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("75b93e1d-2219-43da-b2d8-f5b985112e43"),
                column: "OrderNumber",
                value: 3);

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

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("02627001-cae2-4189-a774-5f2b1876f37c"),
                column: "OrderNumber",
                value: 5);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("29413352-774c-4cf4-8093-c0b733a95194"),
                column: "OrderNumber",
                value: 6);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                column: "OrderNumber",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("082e946c-a3d2-474f-8765-e933d78e9832"),
                column: "OrderNumber",
                value: 9);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"),
                column: "OrderNumber",
                value: 8);
        }
    }
}
