using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiPDAMTanjungUban.Models
{
	public class Tarif
	{
		[Key]
		public int Id { get; set; }
        [Required]
        [Display(Name = "Kategori Pelanggan")]
        public string Kategori { get; set; }
        [Required]
        [Display(Name = "Biaya 0-10 M3")]
        [Range(1,10000)]
        public double Biaya010 { get; set; }
        [Required]
        [Display(Name = "Biaya 11-20 M3")]
        [Range(1, 10000)]
        public double Biaya1120 { get; set; }
        [Required]
        [Display(Name = "Biaya 21-30 M3")]
        [Range(1, 10000)]
        public double Biaya2130 { get; set; }
        [Required]
        [Display(Name = "Biaya >30 M3")]
        [Range(1, 10000)]
        public double Biaya30 { get; set; }
    }
}

