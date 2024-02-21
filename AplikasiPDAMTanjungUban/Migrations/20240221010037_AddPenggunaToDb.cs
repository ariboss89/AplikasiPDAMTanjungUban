using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AplikasiPDAMTanjungUban.Migrations
{
    /// <inheritdoc />
    public partial class AddPenggunaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Penggunas",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penggunas", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "Penggunas",
                columns: new[] { "Username", "Password", "Role" },
                values: new object[,]
                {
                    { "admin", "123456", "Admin" },
                    { "dini", "123456", "Superadmin" },
                    { "dyan", "123456", "Superadmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penggunas");
        }
    }
}
