using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiPDAMTanjungUban.Models
{
	public class Pengguna
	{
        [Key]
		public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}

