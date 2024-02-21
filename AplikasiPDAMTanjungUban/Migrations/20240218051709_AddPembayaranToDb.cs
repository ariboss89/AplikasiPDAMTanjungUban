using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiPDAMTanjungUban.Migrations
{
    /// <inheritdoc />
    public partial class AddPembayaranToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pembayarans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPelanggan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPelanggan = table.Column<int>(type: "int", nullable: false),
                    Golongan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biaya010 = table.Column<double>(type: "float", nullable: false),
                    Biaya1120 = table.Column<double>(type: "float", nullable: false),
                    Biaya2130 = table.Column<double>(type: "float", nullable: false),
                    Biaya30 = table.Column<double>(type: "float", nullable: false),
                    Awal = table.Column<double>(type: "float", nullable: false),
                    Akhir = table.Column<double>(type: "float", nullable: false),
                    Jumlah = table.Column<double>(type: "float", nullable: false),
                    BiayaAdmin = table.Column<double>(type: "float", nullable: false),
                    Denda = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembayarans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pembayarans");
        }
    }
}
