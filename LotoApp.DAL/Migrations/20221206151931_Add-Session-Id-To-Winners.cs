using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotoApp.DAL.Migrations
{
    public partial class AddSessionIdToWinners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c607a532-0b4e-48f6-b542-4231c462c600", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c607a532-0b4e-48f6-b542-4231c462c600");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Winners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0de3d798-1737-44a7-b348-d76a1b4c3406", "21a05012-add2-47b1-a566-eccd3af5423c", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b30am3c1-hg09-bbf0-bd17-007daka4e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64880ce9-b01c-4f11-9b21-a71d50eeeb11", "AQAAAAEAACcQAAAAEI5n0Eqq9EGhD6MCJ9v0DYvM6I3kxKD90LUGNyLlRRuG10RgFiAHxpPFtuyaSxHGow==" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0de3d798-1737-44a7-b348-d76a1b4c3406", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0de3d798-1737-44a7-b348-d76a1b4c3406", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0de3d798-1737-44a7-b348-d76a1b4c3406");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Winners");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c607a532-0b4e-48f6-b542-4231c462c600", "65263187-ba8d-40f4-8678-23cf972a7772", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b30am3c1-hg09-bbf0-bd17-007daka4e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd5be84b-1966-4252-a998-83d38e8891e3", "AQAAAAEAACcQAAAAENk5S75EElNShVWSG25PK03yE9RKWBafqkwo8Ln1JWeatxAm+26tiqv39H0GD6NAag==" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c607a532-0b4e-48f6-b542-4231c462c600", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });
        }
    }
}
