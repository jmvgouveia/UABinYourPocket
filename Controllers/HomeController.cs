﻿using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using TesteASP.Models;

namespace TesteASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
            //TempData["User"] = null;
            SQLiteModel.IniciarTabelas();

            //Util.Utilizador = null;

        }

        public IActionResult Index()
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