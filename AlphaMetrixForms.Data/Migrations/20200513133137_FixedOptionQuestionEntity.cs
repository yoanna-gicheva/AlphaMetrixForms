using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaMetrixForms.Data.Migrations
{
    public partial class FixedOptionQuestionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "OptionQuestions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "OptionQuestions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OptionQuestions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "OptionQuestions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
