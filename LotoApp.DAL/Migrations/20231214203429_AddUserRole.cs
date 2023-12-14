using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotoApp.DAL.Migrations
{
    public partial class AddUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "24b0bc97-e365-4791-842c-c688bfbaae4e", "0efd1cde-a620-443a-99d1-6f2233320886" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24b0bc97-e365-4791-842c-c688bfbaae4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0efd1cde-a620-443a-99d1-6f2233320886");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17b96e40-8fe0-460e-adcc-b42f87414e07", "45ebdc23-f7bf-46af-a2a7-f69a62c147ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df69b2d1-cd4c-47bb-b748-5bc9613f284b", "34f6bfc4-2fa1-4eea-9f6a-75c88200e017", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ba42422-1106-4e39-91cc-7a8ce861be77", 0, "16447e37-c642-4f36-a589-e391884761e0", "ApplicationUser", "admin@example.com", true, "Admin", "Angelovski", false, null, "admin@example.com", "admin@example.com", "AQAAAAEAACcQAAAAEN2lqI1ZpooosnP1dEYbNJrBImpFw00TGJFeuMjtUiwjDaDkrk05fdHHpU0AL/81cA==", null, false, "", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "17b96e40-8fe0-460e-adcc-b42f87414e07", "4ba42422-1106-4e39-91cc-7a8ce861be77" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df69b2d1-cd4c-47bb-b748-5bc9613f284b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "17b96e40-8fe0-460e-adcc-b42f87414e07", "4ba42422-1106-4e39-91cc-7a8ce861be77" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b96e40-8fe0-460e-adcc-b42f87414e07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ba42422-1106-4e39-91cc-7a8ce861be77");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24b0bc97-e365-4791-842c-c688bfbaae4e", "c5a153b2-165a-4469-b74c-4b7fabcf26a4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0efd1cde-a620-443a-99d1-6f2233320886", 0, "0b76eaaf-517e-4492-94c5-d37649d46506", "ApplicationUser", "admin@example.com", true, "Admin", "Angelovski", false, null, "admin@example.com", "admin@example.com", "AQAAAAEAACcQAAAAEMJeuUB49ajkJhD66tg4EkfPowcOZjFteG05aLOZQ8m+RPYt8mYSg8w/eo0WPu9Yaw==", null, false, "", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "24b0bc97-e365-4791-842c-c688bfbaae4e", "0efd1cde-a620-443a-99d1-6f2233320886" });
        }
    }
}
