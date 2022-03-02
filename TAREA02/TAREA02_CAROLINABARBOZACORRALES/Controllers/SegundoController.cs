using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAREA02_CAROLINABARBOZACORRALES.Controllers
{
    public class SegundoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult segundoMetodo()
        {
            return View();
        }
    }
}
