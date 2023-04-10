using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StickyNotes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "CreatedDate", "IsActive", "LastModifiedDate", "NoteDescription", "NoteName", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(132), true, new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(133), "Test note description 1", "Test note 1", 1 },
                    { 2, new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(141), true, new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(142), "Test note description 2", "Test note 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "LastModifiedDate", "UserFullName", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(68), new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(104), "Rakib Khan", "rakib.cse.sust@gmail.com" },
                    { 2, new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(122), new DateTime(2023, 4, 10, 18, 20, 30, 677, DateTimeKind.Local).AddTicks(124), "Jahan Khan", "rakib.jahan.khan@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
