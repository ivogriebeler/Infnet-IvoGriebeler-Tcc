﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}