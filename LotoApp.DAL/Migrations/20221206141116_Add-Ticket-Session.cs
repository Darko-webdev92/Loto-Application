using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotoApp.DAL.Migrations
{
    public partial class AddTicketSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "801b4119-3619-42af-a69a-b895f736a2c0", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "801b4119-3619-42af-a69a-b895f736a2c0");

            migrationBuilder.AddColumn<int>(
                name: "Session",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c607a532-0b4e-48f6-b542-4231c462c600", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c607a532-0b4e-48f6-b542-4231c462c600");

            migrationBuilder.DropColumn(
                name: "Session",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "801b4119-3619-42af-a69a-b895f736a2c0", "861679a8-d669-4af1-8797-c53e7245496f", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b30am3c1-hg09-bbf0-bd17-007daka4e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ab3e6eb-eae3-490f-9843-a6185e45ac09", "AQAAAAEAACcQAAAAEJrbodCg6nM2roW3nqvMoGQB2VCYxbBpr2kc04SdFTKp/uu5fQBB66EVF+l9+KLiIA==" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "801b4119-3619-42af-a69a-b895f736a2c0", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });
        }
    }
}
