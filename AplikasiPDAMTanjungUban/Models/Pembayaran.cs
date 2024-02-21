using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiPDAMTanjungUban.Models
{
	public class Pembayaran
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nama Pelanggan")]
        public string NamaPelanggan { get; set; }
        [Required]
        [Display(Name = "Alamat")]
        public string Alamat { get; set; }
        [Required]
        [Display(Name = "Id Pelanggan")]
        public int IdPelanggan { get; set; }
        [Required]
        public string Golongan { get; set; }
        [Required]
        [Display(Name = "Tanggal Bayar")]
        public DateTime Tanggal { get; set; }

        [Required]
        [Display(Name = "0-10 M3")]
        [Range(1, 10000)]
        public double Biaya010 { get; set; }
        [Required]
        [Display(Name = "11-20 M3")]
        [Range(1, 10000)]
        public double Biaya1120 { get; set; }
        [Required]
        [Display(Name = "21-30 M3")]
        [Range(1, 10000)]
        public double Biaya2130 { get; set; }
        [Required]
        [Display(Name = ">30 M3")]
        [Range(1, 10000)]
        public double Biaya30 { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Awal { get; set; }
        [Required]
        [Range(1, 100000)]
        public double Akhir { get; set; }
        [Required]
        [Range(1, 100000)]
        public double Jumlah { get; set; }

        [Required]
        [Display(Name = "Perawatan")]
        [Range(1, 1000000000)]
        public double Perawatan { get; set; }
        [Required]
        [Display(Name = "Biaya Admin")]
        [Range(1, 1000000000)]
        public double BiayaAdmin { get; set; }
        [Required]
        [Display(Name = "Denda")]
        [Range(1, 1000000000)]
        public double Denda { get; set; }
        [Required]
        [Display(Name = "Total Pembayaran")]
        [Range(1, 1000000000)]
        public double Total { get; set; }
        
    }
}

