using System;
using AplikasiPDAMTanjungUban.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikasiPDAMTanjungUban.ViewModel
{
	public class PelangganVM
	{
		public Pelanggan Pelanggan { get; set; }

        public Tarif Tarif { get; set; }
       
        //public List<Pelanggan> ListPelanggan { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListGolongan { get; set; }


    }
}

