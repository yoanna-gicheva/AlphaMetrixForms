using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class IndexesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e067376a-2d4d-416f-b3a3-2f37dae1ad8f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "ce1410b9-7677-4c28-963c-e8782136556d", new DateTime(2020, 6, 8, 8, 28, 50, 777, DateTimeKind.Utc).AddTicks(5612), "AQAAAAEAACcQAAAAEKChkow8fFcyTVRJHE/aa/LOaN8+IIkgXXPRKdmZm+spkcMOKYNgjH6TPMc3qY/TjQ==" });

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a08236d6-1576-4780-98ec-b00b470a5b1e"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ad686787-e762-4b05-aa40-bab8f8deb4c0"),
                column: "OrderNumber",
                value: 1);

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

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("0b8a2599-2e62-4d2c-aca8-cc6c2a43bab1"),
                column: "OrderNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("0c223fee-5e8e-42b9-85cc-5eae00291d47"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("10c77e0c-b471-47c6-bea7-556d5c88eed7"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1a65e090-bec7-4388-a9dc-521ee062fc25"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1f747c49-83d1-4e12-93a4-d4fb94366d3d"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("372d0d01-ca28-4fcd-8395-5ffcfe8c9ce1"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("40b0b5ca-f281-4919-b323-26ab2b84d720"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("48c526ef-0970-4e7c-b0fb-0f0ef7770c67"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("56b5054b-565a-4ea5-92b9-a4db8c2e6ba3"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("5d1ff7f7-2a7d-420c-955e-4fccf5589668"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("7a36b91e-9454-43cb-8e58-93d493b849ad"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("80a8e086-9592-4760-bd5b-a1a0ebf6a624"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("85662798-ac15-45c7-96fb-50e77de9d526"),
                column: "OrderNumber",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("97f2f831-2c0d-4717-8337-d24d2710ecdd"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("99c6498b-e76f-496a-9e2b-beb3e36eb6b6"),
                column: "OrderNumber",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a0d5d390-f70e-43ae-8744-a4762a6a8a0e"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a640a29e-89be-4ad1-9b13-b46035d724ef"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a7a8b2ac-d48a-4e48-98db-2ac2eacb507a"),
                column: "OrderNumber",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("b3ba569b-123e-4f16-9298-3dbe5720207c"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("b73ca574-f326-4bc6-80dc-038ea561ab33"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("bd0ca49f-c7c3-4401-a225-16d025b13f9b"),
                column: "OrderNumber",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c3f46f23-0b18-4fe7-a00c-5084afd4b032"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c47a949d-e300-4354-b22e-a1615bc6f1a3"),
                column: "OrderNumber",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c542a866-9b62-4629-8e69-84c4394104c4"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("ca610326-8825-465a-bf9e-634ddbdcaaad"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("cc936706-63b9-4830-95ff-c108a71e13f3"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("d5ff0344-94c4-48fe-9211-8c34e43c9a7e"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("d626cd57-2076-4494-9765-be883e0292de"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("fc61593b-297f-48f5-b626-8b8c1496b095"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("00db1b7c-9616-4b03-9435-a3c915f96412"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1a7e99da-687f-4fc3-b9a8-abed0adb5526"),
                column: "OrderNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1ea514f3-b6b2-4ada-9a69-1d68cad75349"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a25cc7e3-2298-4fa6-8dd8-e3147a64464a"),
                column: "OrderNumber",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("a08236d6-1576-4780-98ec-b00b470a5b1e"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DocumentQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ad686787-e762-4b05-aa40-bab8f8deb4c0"),
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
                keyValue: new Guid("1e82d528-4898-4c9e-87fb-16c0fdb9843e"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6902a89e-e11c-4800-99d6-b51f66f8ca54"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("786cef88-a6ac-42e3-994c-e7eed39201a5"),
                column: "OrderNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "OptionQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f97771a3-f1ad-40ce-b113-2eed16bc4a3d"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("0b8a2599-2e62-4d2c-aca8-cc6c2a43bab1"),
                column: "OrderNumber",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("0c223fee-5e8e-42b9-85cc-5eae00291d47"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("10c77e0c-b471-47c6-bea7-556d5c88eed7"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1a65e090-bec7-4388-a9dc-521ee062fc25"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("1f747c49-83d1-4e12-93a4-d4fb94366d3d"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("372d0d01-ca28-4fcd-8395-5ffcfe8c9ce1"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("40b0b5ca-f281-4919-b323-26ab2b84d720"),
                column: "OrderNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("48c526ef-0970-4e7c-b0fb-0f0ef7770c67"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("56b5054b-565a-4ea5-92b9-a4db8c2e6ba3"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("5d1ff7f7-2a7d-420c-955e-4fccf5589668"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("7a36b91e-9454-43cb-8e58-93d493b849ad"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("80a8e086-9592-4760-bd5b-a1a0ebf6a624"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("85662798-ac15-45c7-96fb-50e77de9d526"),
                column: "OrderNumber",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("97f2f831-2c0d-4717-8337-d24d2710ecdd"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("99c6498b-e76f-496a-9e2b-beb3e36eb6b6"),
                column: "OrderNumber",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a0d5d390-f70e-43ae-8744-a4762a6a8a0e"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a640a29e-89be-4ad1-9b13-b46035d724ef"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("a7a8b2ac-d48a-4e48-98db-2ac2eacb507a"),
                column: "OrderNumber",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("b3ba569b-123e-4f16-9298-3dbe5720207c"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("b73ca574-f326-4bc6-80dc-038ea561ab33"),
                column: "OrderNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("bd0ca49f-c7c3-4401-a225-16d025b13f9b"),
                column: "OrderNumber",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c3f46f23-0b18-4fe7-a00c-5084afd4b032"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c47a949d-e300-4354-b22e-a1615bc6f1a3"),
                column: "OrderNumber",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("c542a866-9b62-4629-8e69-84c4394104c4"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("ca610326-8825-465a-bf9e-634ddbdcaaad"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("cc936706-63b9-4830-95ff-c108a71e13f3"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("d5ff0344-94c4-48fe-9211-8c34e43c9a7e"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("d626cd57-2076-4494-9765-be883e0292de"),
                column: "OrderNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("fc61593b-297f-48f5-b626-8b8c1496b095"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("00db1b7c-9616-4b03-9435-a3c915f96412"),
                column: "OrderNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1a7e99da-687f-4fc3-b9a8-abed0adb5526"),
                column: "OrderNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1ea514f3-b6b2-4ada-9a69-1d68cad75349"),
                column: "OrderNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TextQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a25cc7e3-2298-4fa6-8dd8-e3147a64464a"),
                column: "OrderNumber",
                value: 3);
        }
    }
}
