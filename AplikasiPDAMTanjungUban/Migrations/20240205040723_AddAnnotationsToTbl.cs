using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiPDAMTanjungUban.Migrations
{
    /// <inheritdoc />
    public partial class AddAnnotationsToTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "Pelanggans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Pelanggans");
        }
    }
}
