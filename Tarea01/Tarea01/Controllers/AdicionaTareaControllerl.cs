using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea01.Controllers
{
    public class AdicionaTareaControllerl : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult metodoAdicional()
        {
            return View();
        }
    }
}
