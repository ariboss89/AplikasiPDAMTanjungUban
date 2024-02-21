using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikasiPDAMTanjungUban.Data;
using AplikasiPDAMTanjungUban.Models;
using AplikasiPDAMTanjungUban.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikasiPDAMTanjungUban.Controllers
{
    public class PembayaranController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PembayaranController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            PembayaranVM vm = new PembayaranVM();

            vm = new PembayaranVM()
            {
                Pembayaran = new Pembayaran()
                {
                    Tanggal = DateTime.Now,
                    BiayaAdmin = 1000.0
                },

                ListPelanggan = _db.Pelanggans.Select(i => new SelectListItem
                {
                    Text = i.Nama,
                    Value = i.Id.ToString()
                })
            };

            return View(vm);
        }

        #region API CALLS

        public JsonResult GetDataPelanggan(int Id)
        {
            var listPelanggan = _db.Pelanggans.Where(x=> x.Id == Id).FirstOrDefault();

            string golongan = listPelanggan.Kategori;

            var tarif = _db.Tarifs.Where(x => x.Kategori == golongan).FirstOrDefault();

            PelangganVM vm = new PelangganVM()
            {
                Pelanggan = new Pelanggan()
                {
                    Id = listPelanggan.Id,
                    Alamat = listPelanggan.Alamat,
                    IdPelanggan = listPelanggan.IdPelanggan,
                    Kategori = listPelanggan.Kategori,
                    Kontak =listPelanggan.Kontak,
                    Nama = listPelanggan.Nama
                },

                Tarif = new Tarif()
                {
                    Biaya010 = tarif.Biaya010,
                    Biaya1120=tarif.Biaya1120,
                    Biaya2130=tarif.Biaya2130,
                    Biaya30=tarif.Biaya30,
                    Id=tarif.Id,
                    Kategori=tarif.Kategori
                }
            };

            return Json(new { data = vm });
        }

        [HttpPost]
        public IActionResult SimpanData(Pembayaran kr)
        {
            if (kr.Id == 0)
            {
                var plgn = _db.Pelanggans.Where(x => x.Id == Convert.ToInt16(kr.NamaPelanggan)).FirstOrDefault();

                if (plgn != null)
                {
                    kr.NamaPelanggan = plgn.Nama;
                    _db.Pembayarans.Add(kr);
                    _db.SaveChanges();
                    TempData["Success"] = "Data Pembayaran Berhasil di Tambahkan";
                }

                //TempData["Error"] = "Terjadi Kesalahan !!";
            }

            if (kr == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}