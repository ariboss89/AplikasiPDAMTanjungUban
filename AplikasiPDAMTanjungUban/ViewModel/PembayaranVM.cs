using System;
using AplikasiPDAMTanjungUban.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikasiPDAMTanjungUban.ViewModel
{
	public class PembayaranVM
	{
        public Pembayaran Pembayaran { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListPelanggan { get; set; }
    }
}

