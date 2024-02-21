﻿// <auto-generated />
using System;
using AplikasiPDAMTanjungUban.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AplikasiPDAMTanjungUban.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AplikasiPDAMTanjungUban.Models.Pelanggan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPelanggan")
                        .HasColumnType("int");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kontak")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pelanggans");
                });

            modelBuilder.Entity("AplikasiPDAMTanjungUban.Models.Pembayaran", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Akhir")
                        .HasColumnType("float");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Awal")
                        .HasColumnType("float");

                    b.Property<double>("Biaya010")
                        .HasColumnType("float");

                    b.Property<double>("Biaya1120")
                        .HasColumnType("float");

                    b.Property<double>("Biaya2130")
                        .HasColumnType("float");

                    b.Property<double>("Biaya30")
                        .HasColumnType("float");

                    b.Property<double>("BiayaAdmin")
                        .HasColumnType("float");

                    b.Property<double>("Denda")
                        .HasColumnType("float");

                    b.Property<string>("Golongan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPelanggan")
                        .HasColumnType("int");

                    b.Property<double>("Jumlah")
                        .HasColumnType("float");

                    b.Property<string>("NamaPelanggan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Perawatan")
                        .HasColumnType("float");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pembayarans");
                });

            modelBuilder.Entity("AplikasiPDAMTanjungUban.Models.Pengguna", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Penggunas");

                    b.HasData(
                        new
                        {
                            Username = "dyan",
                            Password = "123456",
                            Role = "Superadmin"
                        },
                        new
                        {
                            Username = "dini",
                            Password = "123456",
                            Role = "Superadmin"
                        },
                        new
                        {
                            Username = "admin",
                            Password = "123456",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("AplikasiPDAMTanjungUban.Models.Tarif", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Biaya010")
                        .HasColumnType("float");

                    b.Property<double>("Biaya1120")
                        .HasColumnType("float");

                    b.Property<double>("Biaya2130")
                        .HasColumnType("float");

                    b.Property<double>("Biaya30")
                        .HasColumnType("float");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tarifs");
                });
#pragma warning restore 612, 618
        }
    }
}
