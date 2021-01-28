using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using maurizio.conti.Uploadfile.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace maurizio.conti.Uploadfile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View( new PersoneFormFile() );
        }

        [HttpPost]
        public IActionResult Index(PersoneFormFile formFile)
        {
            var persone = new PersoneCSV( formFile );
            return View("ListPersone", persone);        
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
}
