using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiPDAMTanjungUban.Migrations
{
    /// <inheritdoc />
    public partial class AddPelangganToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelanggans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPelanggan = table.Column<int>(type: "int", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kontak = table.Column<int>(type: "int", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelanggans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelanggans");
        }
    }
}
