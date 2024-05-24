using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_proyect.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    AplicationState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tittle = table.Column<string>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    InitDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    From = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Sector = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsRequired = table.Column<string>(type: "TEXT", nullable: false),
                    InmediteIncorporation = table.Column<bool>(type: "INTEGER", nullable: false),
                    Intern = table.Column<bool>(type: "INTEGER", nullable: false),
                    CareerMinimumAge = table.Column<int>(type: "INTEGER", nullable: false),
                    CareersInterested = table.Column<int>(type: "INTEGER", nullable: false),
                    InternTime = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    OfferState = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false),
                    UserState = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    WorkArea = table.Column<string>(type: "TEXT", nullable: true),
                    Enterprises_City = table.Column<string>(type: "TEXT", nullable: true),
                    WebPage = table.Column<string>(type: "TEXT", nullable: true),
                    AboutCompany = table.Column<string>(type: "TEXT", nullable: true),
                    LegalAbout = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyAbout = table.Column<string>(type: "TEXT", nullable: true),
                    ContactName = table.Column<string>(type: "TEXT", nullable: true),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: true),
                    EnterpriseType = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeesQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    Cuit = table.Column<long>(type: "INTEGER", nullable: true),
                    FileNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    Dni = table.Column<int>(type: "INTEGER", nullable: true),
                    Cuil = table.Column<long>(type: "INTEGER", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    CivilStatus = table.Column<string>(type: "TEXT", nullable: true),
                    Tittle = table.Column<string>(type: "TEXT", nullable: true),
                    CareerAge = table.Column<int>(type: "INTEGER", nullable: true),
                    EnglishLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    CvFile = table.Column<string>(type: "TEXT", nullable: true),
                    HighSchoolFile = table.Column<string>(type: "TEXT", nullable: true),
                    CoursesFile = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
