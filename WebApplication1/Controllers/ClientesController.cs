using Microsoft.AspNetCore.Mvc;
using NorthwindDATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        ModelNorthwind context;
        public ClientesController(ModelNorthwind context)
        {
            this.context = context;
        }

        //Mostrar listado de clientes
        public IActionResult Index()
        {
            //var context = new ModelNorthwind();
            var clientes = context.Customers.ToList();
            ViewBag.Title = "Lisado de clientes";

            return View(clientes);
        }

        public IActionResult Ficha(string id)
        {
            var cliente = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            ViewBag.Title = $"Ficha de {cliente.CustomerID}";
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Grabar(Customers cliente)
        {

            context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            //return View("Ficha", cliente);
            return RedirectToAction("Index");
            //return RedirectToAction("Ficha", new { id = cliente.CustomerID });
        }


    }
}
