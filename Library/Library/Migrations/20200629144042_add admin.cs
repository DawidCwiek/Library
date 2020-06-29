using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "e36d6200-e7d2-43da-8b91-68cde06fb23f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, null, "c8554266-b401-4519-9aeb-a9283053fc58", "admin@admin.com", true, null, null, false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEHKL+T4GjqklYfMvORzKfjKorANj3mQXbWRfQFHV5C7RHON3xf9rcRP+xkhFSBv6fQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", null, false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73");
        }
    }
}
