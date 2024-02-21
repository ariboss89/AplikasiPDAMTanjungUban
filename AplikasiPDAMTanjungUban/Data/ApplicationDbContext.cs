using System;
using System.Data;
using AplikasiPDAMTanjungUban.Models;
using Microsoft.EntityFrameworkCore;

namespace AplikasiPDAMTanjungUban.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pelanggan> Pelanggans { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<Pembayaran> Pembayarans { get; set; }
        public DbSet<Pengguna> Penggunas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pengguna>().HasData(
            new Pengguna()
            {
                Username = "dyan",
                Password = "123456",
                Role = "Superadmin"
            },

            new Pengguna()
            {
                Username = "dini",
                Password = "123456",
                Role = "Superadmin"
            },

            new Pengguna()
            {
                Username = "admin",
                Password = "123456",
                Role = "Admin"
            });
        }
    }
}

