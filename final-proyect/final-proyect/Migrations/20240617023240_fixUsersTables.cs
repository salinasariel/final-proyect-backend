using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_proyect.Migrations
{
    public partial class fixUsersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutCompany",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CareerAge",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyAbout",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CoursesFile",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InitDate",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "HighSchoolFile",
                table: "Users",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "CvFile",
                table: "Users",
                newName: "Education");

            migrationBuilder.AlterColumn<string>(
                name: "EnterpriseType",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Users",
                newName: "HighSchoolFile");

            migrationBuilder.RenameColumn(
                name: "Education",
                table: "Users",
                newName: "CvFile");

            migrationBuilder.AlterColumn<int>(
                name: "EnterpriseType",
                table: "Users",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutCompany",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CareerAge",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAbout",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoursesFile",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InitDate",
                table: "Offers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
