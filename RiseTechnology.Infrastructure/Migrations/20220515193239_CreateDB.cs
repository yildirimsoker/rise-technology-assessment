using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiseTechnology.Infrastructure.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ReportStatusType = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ContactType = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    ContactDescription = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContact_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Company", "Name", "Surname" },
                values: new object[] { 1, "Ys Company", "Yildirim", "Soker" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Company", "Name", "Surname" },
                values: new object[] { 2, "AV Company", "Ali", "Veli" });

            migrationBuilder.InsertData(
                table: "PersonContact",
                columns: new[] { "Id", "ContactDescription", "ContactType", "PersonId" },
                values: new object[,]
                {
                    { 1, "yildirimsoker@gmail.com", "Email", 1 },
                    { 2, "05380867056", "PhoneNumber", 1 },
                    { 3, "27.814786,22.053289", "Location", 1 },
                    { 4, "aliveli@gmail.com", "Email", 2 },
                    { 5, "05422305462", "PhoneNumber", 2 },
                    { 6, "39.482845,60.399189", "Location", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_PersonId",
                table: "PersonContact",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonContact");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
