using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AplikasiPDAMTanjungUban.Models;
using AplikasiPDAMTanjungUban.SD;
using AplikasiPDAMTanjungUban.Data;

namespace AplikasiPDAMTanjungUban.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (StaticDetails.Role == null)
        {
            StaticDetails.Role = "";
            return RedirectToAction("Index","Home");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Index(Pengguna png)
    {
        var check = _db.Penggunas.Where(x => x.Username == png.Username && x.Password == png.Password).FirstOrDefault();

        if (check != null)
        {
            var role = check.Role;

            StaticDetails.Role = role;
            StaticDetails.Username = $"{check.Username}!";

            return RedirectToAction("Index","Home"); 
        }
        else if (png.Username == null || png.Password == null)
        {

            return View();
        }

        //TempData["error"] = "Password atau Username Salah !!";

        return Json(new { data = "Password atau Username Salah !!" });
    }

    public IActionResult Logout()
    {
        if (StaticDetails.Role != null)
        {
            StaticDetails.Role = "";
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

