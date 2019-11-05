using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyContext _myContext;
        public HomeController(ILogger<HomeController> logger, MyContext myContext)
        {
            _logger = logger;
            _myContext = myContext;
        }


        public IActionResult Index()
        {
            var model = _myContext.Exercises.First();
            return View(model);
        }

        [Route("index/{id:int:min(1)}")]
        public IActionResult Index(int id)
        {
            var model = _myContext.Exercises.First(m => m.Id > id);
            return View(model);
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
