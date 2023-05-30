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

            SQLiteModel.IniciarTabelas();

            SQLiteModel.AdicionarNovoAluno("Daniel", new DateOnly(1993, 1, 21), "Maiorga", "2460-819", 123456789, 911111111, "Portugal", "daniel@mail.com");

            DataTable dtAux = SQLiteModel.ObterDadosAluno(1);

            if (dtAux != null && dtAux.Rows.Count > 0)
            {
                DataRow row = dtAux.Rows[0];

                AlunoModel aluno = new AlunoModel((int)(long)row["id"], (string)row["nome"], DateOnly.FromDateTime((DateTime)row["data_nascimento"]), 
                                                  (string)row["morada"], (string)row["codigo_postal"], (int)row["nif"], 
                                                  (int)row["contacto"], (string)row["pais"], (string)row["email"]);

                var t1 = 0;
            }

            var teste = 0;
        }

        public IActionResult Index()
        {
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
}