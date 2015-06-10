﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurboRango.Web.Models;

namespace TurboRango.Web.Controllers
{
    public class SorteiosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public static int GetIluminismo()
        {
            var nonz = 33;
            return nonz;
        }

        // GET: Sorteios
        public ActionResult Index()
        {
            ViewBag.QtdRestaurantes = db.Restaurantes.Count();
            return View();
        }
    }
}