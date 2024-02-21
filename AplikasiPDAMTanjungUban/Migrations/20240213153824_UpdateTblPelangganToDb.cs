using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiPDAMTanjungUban.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTblPelangganToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Kontak",
                table: "Pelanggans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kontak",
                table: "Pelanggans",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
