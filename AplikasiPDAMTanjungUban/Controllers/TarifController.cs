using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikasiPDAMTanjungUban.Data;
using AplikasiPDAMTanjungUban.Models;
using AplikasiPDAMTanjungUban.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiPDAMTanjungUban.Controllers
{
    public class TarifController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TarifController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Tarif vm = new Tarif();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            Tarif kr = new Tarif();

            if (id == null)
            {
                return View(kr);
            }

            var data = _db.Tarifs.Where(x => x.Id == id).FirstOrDefault();

            kr.Id = data.Id;
            kr.Kategori = data.Kategori;
            kr.Biaya010 = data.Biaya010;
            kr.Biaya1120 = data.Biaya1120;
            kr.Biaya2130 = data.Biaya2130;
            kr.Biaya30 = data.Biaya30;

            if (kr == null)
            {
                return NotFound();
            }

            return View(kr);

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
        public IActionResult Upsert(Tarif kr)
        {
            if (kr.Id == 0)
            {
                _db.Tarifs.Add(kr);
                _db.SaveChanges();

                TempData["success"] = "Tarif berhasil di tambahkan";
            }
            else
            {
                _db.Tarifs.Update(kr);
                TempData["success"] = "Tarif berhasil di ubah";

            }

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        #region API CALLS

        public JsonResult GetAll()
        {
            List<Tarif> listTarif = _db.Tarifs.ToList();

            return Json(new { data = listTarif });
        }
        #endregion
    }
}