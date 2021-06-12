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
using System.Drawing;

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
        public async Task<IActionResult> Index(PersoneFormFile formFile)
        {
            IFormFile file = formFile.MioFormFile;

            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }

            Image img= null;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                
                using (img = Image.FromStream(memoryStream))
                {
                    //img.Save( MyServer.MapPath("wwwroot/images/Elenco1.png") );
                    img.Save( MyServer.MapPath("wwwroot/images/" + file.FileName) );
                }
            }


            //var persone = new PersoneCSV( formFile );
            //return View("ListPersone", persone);        
            
            return View( new PersoneFormFile() );

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
