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
    public class PelangganController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PelangganController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            PelangganVM vm = new PelangganVM();

            vm = new PelangganVM()
            {
                Pelanggan = new Pelanggan(),
                ListGolongan = _db.Tarifs.Select(i => new SelectListItem
                {
                    Text = i.Kategori,
                    Value = i.Id.ToString()
                })
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            PelangganVM kr = new PelangganVM()
            {
                Pelanggan = new Pelanggan(),
                ListGolongan = _db.Tarifs.Select(i => new SelectListItem
                {
                    Text = i.Kategori,
                    Value = i.Id.ToString()
                }),

            };

            if (id == null)
            {
                return View(kr);
            }
            else
            {
                var dataPelanggan = _db.Pelanggans.ToList().OrderBy(x => x.Id).ToList();

                var idRow = id - 1;

                var data = dataPelanggan[Convert.ToInt32(idRow)];

                kr.Pelanggan.Id = data.Id;
                kr.Pelanggan.Nama = data.Nama;
                kr.Pelanggan.Kontak = data.Kontak;
                kr.Pelanggan.Alamat = data.Alamat;
                kr.Pelanggan.Kategori = data.Kategori;
                kr.Pelanggan.IdPelanggan = data.IdPelanggan;
            }

            if (kr.Pelanggan == null)
            {
                return NotFound();
            }


            return Json(new { data = kr.Pelanggan });

        }

        [HttpPost]
        public IActionResult Edit(Pelanggan pelanggan)
        {
            
            if (pelanggan.Id == null)
            {
                TempData["Error"] = "Silahlan pilih data pelanggan yang akan di ubah datanya";
                return RedirectToAction("Index","Pelanggan");
            }
            else
            {
                var dataGol = _db.Tarifs.Where(x => x.Id == Convert.ToInt32(pelanggan.Kategori)).FirstOrDefault();

                string namaGol = dataGol.Kategori;

                pelanggan.Kategori = namaGol;

                _db.Pelanggans.Update(pelanggan);
                _db.SaveChanges();
                TempData["Success"] = "Pelanggan berhasil di ubah";
            }

            if (pelanggan == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Pelanggan");

        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var objFromDb = _db.Pelanggans.Find(Id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            _db.Pelanggans.Remove(objFromDb);
            _db.SaveChanges();
            return Json(new { success = true, message = "Delete Successful" });
        }

        [HttpPost]
        public IActionResult Index(PelangganVM kr)
        {
            if (kr.Pelanggan.Kategori != null)
            {
                var dataGol = _db.Tarifs.Where(x => x.Id == Convert.ToInt32(kr.Pelanggan.Kategori)).FirstOrDefault();

                string namaGol = dataGol.Kategori;

                kr.Pelanggan.Kategori = namaGol;

                if (kr.Pelanggan.Id == 0)
                {
                    _db.Pelanggans.Add(kr.Pelanggan);
                    _db.SaveChanges();

                    TempData["success"] = "Data pelanggan berhasil di tambahkan";
                }
                else
                {
                    _db.Pelanggans.Update(kr.Pelanggan);
                    TempData["success"] = "Data pelanggan berhasil di ubah";

                }

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            TempData["error"] = "Data pelanggan gagal di tambahkan";

            kr = new PelangganVM()
            {
                Pelanggan = new Pelanggan(),

                ListGolongan = _db.Tarifs.Select(i => new SelectListItem
                {
                    Text = i.Kategori,
                    Value = i.Id.ToString()
                })
            };

            return View(kr);
        }

        #region API CALLS

        public JsonResult GetAll()
        {
            List<Pelanggan> listPelanggan = _db.Pelanggans.OrderBy(x=>x.Id).ToList();

            return Json(new { data = listPelanggan });
        }

        #endregion
    }
}