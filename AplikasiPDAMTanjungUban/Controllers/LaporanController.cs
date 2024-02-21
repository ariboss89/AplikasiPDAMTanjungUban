using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikasiPDAMTanjungUban.Data;
using AplikasiPDAMTanjungUban.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiPDAMTanjungUban.Controllers
{
    public class LaporanController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LaporanController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        public JsonResult GetAll()
        {
            List<Pembayaran> listPembayaran = _db.Pembayarans.OrderBy(x => x.Id).ToList();

            return Json(new { data = listPembayaran });
        }

        public JsonResult TampilData(string tglAwal, string tglAkhir)
        {
            List<Pembayaran> listPembayaran = _db.Pembayarans.Where(x=> x.Tanggal>=Convert.ToDateTime(tglAwal) && x.Tanggal<=Convert.ToDateTime(tglAkhir)).ToList();

            return Json(new { data = listPembayaran });
        }

        #endregion
    }
}