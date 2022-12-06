using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotoApp.DAL.Migrations
{
    public partial class AddWinnersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e5493f4f-65f9-4910-942e-809aa8103b24", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5493f4f-65f9-4910-942e-809aa8103b24");

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prize = table.Column<int>(type: "int", nullable: false),
                    Number_1 = table.Column<int>(type: "int", nullable: false),
                    Number_2 = table.Column<int>(type: "int", nullable: false),
                    Number_3 = table.Column<int>(type: "int", nullable: false),
                    Number_4 = table.Column<int>(type: "int", nullable: false),
                    Number_5 = table.Column<int>(type: "int", nullable: false),
                    Number_6 = table.Column<int>(type: "int", nullable: false),
                    Number_7 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "801b4119-3619-42af-a69a-b895f736a2c0", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "801b4119-3619-42af-a69a-b895f736a2c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5493f4f-65f9-4910-942e-809aa8103b24", "b9f85716-1e0a-4064-819c-ddf271ea94f3", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b30am3c1-hg09-bbf0-bd17-007daka4e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7dbe5cee-5336-497c-9c11-00968981c9d6", "AQAAAAEAACcQAAAAEDvl2oTArV5as57nTwmGsCC7nNLWuz/CaeZHpW++sjTm+YvdRZF62K3GoMFo961X6A==" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e5493f4f-65f9-4910-942e-809aa8103b24", "b30am3c1-hg09-bbf0-bd17-007daka4e575" });
        }
    }
}
