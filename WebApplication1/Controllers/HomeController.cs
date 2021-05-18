using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {

            // Pasar datos a la vida con ViewBag
            ViewBag.numero = id;
            ViewBag.mensaje = $"Tabla de multiplicar del {id}";

            //Pasar datos a la vista como modelo de datos
            //return View(id);

            return View(id);
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}
