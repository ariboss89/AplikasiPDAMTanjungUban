using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiPDAMTanjungUban.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTblTarifToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biaya",
                table: "Tarifs");

            migrationBuilder.AddColumn<double>(
                name: "Biaya010",
                table: "Tarifs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Biaya1120",
                table: "Tarifs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Biaya2130",
                table: "Tarifs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Biaya30",
                table: "Tarifs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biaya010",
                table: "Tarifs");

            migrationBuilder.DropColumn(
                name: "Biaya1120",
                table: "Tarifs");

            migrationBuilder.DropColumn(
                name: "Biaya2130",
                table: "Tarifs");

            migrationBuilder.DropColumn(
                name: "Biaya30",
                table: "Tarifs");

            migrationBuilder.AddColumn<string>(
                name: "Biaya",
                table: "Tarifs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
