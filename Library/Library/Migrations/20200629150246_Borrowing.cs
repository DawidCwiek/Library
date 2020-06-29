using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Borrowing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borrowing",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    MaxDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing", x => new { x.BookId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_Borrowing_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowing_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "255dbd35-c551-4c62-a6e5-deaa4b6d674b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPVdjNNHNHeC042s6HsXLX33PbCXo8SEbQuE0n6/Jn5G7qKlmz5JFGgEf1HoqzjZAA==");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_ApplicationUserId",
                table: "Borrowing",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrowing");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "e36d6200-e7d2-43da-8b91-68cde06fb23f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHKL+T4GjqklYfMvORzKfjKorANj3mQXbWRfQFHV5C7RHON3xf9rcRP+xkhFSBv6fQ==");
        }
    }
}
