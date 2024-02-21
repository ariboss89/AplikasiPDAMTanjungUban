using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiPDAMTanjungUban.Models
{
	public class Pelanggan
	{
		[Key]
		public int Id { get; set; }
        [Required]
        [Display(Name = "Id Pelanggan")]
        public int IdPelanggan { get; set; }
        [Required]
        [Display(Name = "Pelanggan")]
        public string Nama { get; set; }
        [Required]
        [Display(Name = "Kontak")]
        public string Kontak { get; set; }
        [Required]
        [Display(Name = "Alamat")]
        public string Alamat { get; set; }
        [Required]
        [Display(Name = "Golongan")]
        public string Kategori { get; set; }
    }
}

