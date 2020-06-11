using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class RemoveUnnecessaryProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TextQuestions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TextQuestions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TextQuestions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TextQuestions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TextQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TextQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TextQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TextQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "OptionQuestions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "OptionQuestions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OptionQuestions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "OptionQuestions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DocumentQuestions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "DocumentQuestions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DocumentQuestions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DocumentQuestions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Responses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "4afa4eb4-f1f4-46f1-9759-89f97fbbe720", new DateTime(2020, 6, 1, 21, 36, 25, 909, DateTimeKind.Utc).AddTicks(7840), "AQAAAAEAACcQAAAAEH03yjJUhtNz7J2xdpmpzqEy31Bo1aPA3IApGD7+me2x8MQgbMCeV0UL0g9Sn82euA==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 1, 21, 36, 25, 944, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 1, 21, 36, 25, 944, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 1, 21, 36, 25, 944, DateTimeKind.Utc).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 6, 1, 21, 36, 25, 944, DateTimeKind.Utc).AddTicks(7839));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Responses");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TextQuestions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TextQuestions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TextQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TextQuestions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TextQuestionAnswers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TextQuestionAnswers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TextQuestionAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TextQuestionAnswers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Options",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Options",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "OptionQuestions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "OptionQuestions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OptionQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "OptionQuestions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DocumentQuestions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "DocumentQuestions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DocumentQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DocumentQuestions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "b297eef1-9015-4fb2-9a37-917d2921d592", new DateTime(2020, 5, 28, 14, 50, 57, 225, DateTimeKind.Utc).AddTicks(6599), "AQAAAAEAACcQAAAAEFB8gzMgvtNAe5W3GL18s0Uh81XRyJwoznU5vvabJ2UfgBk6exAV7Rb7UlDUN46YbA==" });

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("078f9ce9-8a39-4355-a6c5-de5282df4dce"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5065d44a-992d-4328-bcf9-56a3f49581d9"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("75b93e1d-2219-43da-b2d8-f5b985112e43"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a08236d6-1576-4780-98ec-b00b470a5b1e"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ad686787-e762-4b05-aa40-bab8f8deb4c0"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8a50ab5f-0eb5-4eaa-916e-dc241a19a3ed"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("aa5a5180-9201-41bf-9241-7a3918f4bf5c"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b41ba95b-e19f-4ed6-b443-6c85cf9b5c3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("eff4ce9b-6a32-47a4-8e5e-d7d89ca18446"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("02627001-cae2-4189-a774-5f2b1876f37c"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("29413352-774c-4cf4-8093-c0b733a95194"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("69b16a6e-75c5-456a-ac2b-bdf94753b112"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 238, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("00db1b7c-9616-4b03-9435-a3c915f96412"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("082e946c-a3d2-474f-8765-e933d78e9832"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1a7e99da-687f-4fc3-b9a8-abed0adb5526"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1ea514f3-b6b2-4ada-9a69-1d68cad75349"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94fc2049-4b7b-4fbc-9991-ad4abb37b03d"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a25cc7e3-2298-4fa6-8dd8-e3147a64464a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ff8f434b-e6c0-4e29-a79d-994dd4e7c21c"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 28, 14, 50, 57, 237, DateTimeKind.Utc).AddTicks(3937));
        }
    }
}
