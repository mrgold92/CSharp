using System;
using System.Collections.Generic;
using System.Linq;
/*
* LINQ (Language Integrated Query) es una sintaxis de consulta uniforme 
* en C # y VB.NET utilizada para guardar y recuperar datos de diferentes fuentes:
* colecciones, bases de datos, etc. 
*/
namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {


            /**************************** 
             * Ejercicios
             ****************************/

            //Lista completa de clientes

            var clientes = DataLists.ListaClientes.ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Id:{cliente.Id} Nombre: { cliente.Nombre} Fecha Nac.: {cliente.FechaNac.ToShortDateString()}");
            }

            Console.WriteLine("************************************");


            //Buscar el que tenga el id = 2
            //var clientesWhere = DataLists.ListaClientes.Where(x => x.Id == 2).First() //devuelve el primero o error si no lo encuentra
            var clientesWhere = DataLists.ListaClientes.Where(x => x.Id == 2).FirstOrDefault(); //devuelve el primero o null
            Console.WriteLine($"Id:{clientesWhere.Id} Nombre: { clientesWhere.Nombre} Fecha Nac.: {clientesWhere.FechaNac.ToShortDateString()}");

            Console.WriteLine("************************************");

            //Cuántos clientes nacidos entre 1980 y 1990

            var cuantos = DataLists.ListaClientes
                          .Where(x => x.FechaNac.Year >= 1980 && x.FechaNac.Year <= 1990)
                          .Count();
            var c = (from r in DataLists.ListaClientes
                     where r.FechaNac.Year >= 1980 && r.FechaNac.Year <= 1990
                     select r)
                     .Count();

            Console.WriteLine($"Clientes nacidos entre 1980 y 1990: {cuantos} clientes");
            Console.WriteLine($"Clientes nacidos entre 1980 y 1990: {c} clientes");

            Console.WriteLine("************************************");

            //Listado de productos que contengan la palabra cuaderno
            var productos = DataLists.ListaProductos
                            .Where(x => x.Descripcion.ToLower().Contains("cuaderno"))
                            .ToList();
            foreach (var producto in productos)
            {
                Console.WriteLine($"{producto.Id}# {producto.Descripcion} {producto.Precio}");
            }

            Console.WriteLine("************************************");


            //Buscar el producto de mayor precio
            //4 formas distintas (hay más)
            var mayorPrecio = DataLists.ListaProductos.OrderByDescending(x => x.Precio).FirstOrDefault();
            var mayorSub = DataLists.ListaProductos.Where(x => x.Precio == DataLists.ListaProductos.Select(r => r.Precio).Max()).FirstOrDefault();
            var mayorMax = DataLists.ListaProductos.Where(x => x.Precio == DataLists.ListaProductos.Max(r => r.Precio)).FirstOrDefault();
            var mayorP = (from r in DataLists.ListaProductos orderby r.Precio descending select r).FirstOrDefault();



            Console.WriteLine($"Producto de mayor precio: {mayorPrecio.Descripcion} {mayorPrecio.Precio}");
            Console.WriteLine($"Producto de mayor precio: {mayorSub.Descripcion} {mayorSub.Precio}");
            Console.WriteLine($"Producto de mayor precio: {mayorMax.Descripcion} {mayorMax.Precio}");
            Console.WriteLine($"Producto de mayor precio: {mayorP.Descripcion} {mayorP.Precio}");

            Console.WriteLine("************************************");

            //Agrupaciones
            //Pintamos datos del cliente y número de pedidos

            //Forma normal
            foreach (var a in DataLists.ListaClientes.ToList())
            {
                int numPedidos = DataLists.ListaPedidos.Where(r => r.IdCliente == a.Id).Count();
                Console.WriteLine($"{a.Nombre} - {numPedidos} pedidos");
            }

            Console.WriteLine("************************************");

            //Por métodos
            var data = DataLists.ListaPedidos.GroupBy(r => r.IdCliente)
                .Select(r => new
                {
                    Clave = r.Key,
                    TotalPedidos = r.Count(),
                    lineas = r,
                    Cliente = DataLists.ListaClientes.Where(s => s.Id == r.Key).FirstOrDefault()
                }).ToList();

            foreach (var a in data)
            {
                Console.WriteLine($"Cliente: {a.Clave} {a.Cliente.Nombre} Total Pedidos: { a.TotalPedidos}");

                foreach (var l in a.lineas)
                {
                    Console.WriteLine($"--> {l.Id } - {l.FechaPedido.ToShortDateString()}");
                }

            }

            Console.ReadKey();

            /**************************** 
             * Forma normal
             ****************************/
            foreach (var item in DataLists.ListaProductos)
            {
                if (item.Precio > 2)
                {
                    Console.WriteLine($"{item.Descripcion} {item.Precio}");
                }
            }

            Console.WriteLine("************************************");

            /**************************** 
             * Expresiones con LINQ
             ****************************/

            //SQL equivalente -> SELECT * FROM ListaProductos
            var resultado = from r in DataLists.ListaProductos
                            select r;

            foreach (var item in resultado)
            {
                Console.WriteLine($"{item.Descripcion} {item.Precio}");
            }

            Console.WriteLine("************************************");

            //Buscar productos con precio mayor a 2

            //SQL equivalente -> SELECT * FROM ListaProductos WHERE Precio > 2
            var resultado2 = from r in DataLists.ListaProductos
                             where r.Precio > 2
                             select r;


            foreach (var item in resultado2)
            {
                Console.WriteLine($"{item.Descripcion} {item.Precio}");
            }

            Console.WriteLine("************************************");

            //Buscar productos con precio mayor a 2 ordenado descendente

            var resultado3 = from r in DataLists.ListaProductos
                             where r.Precio > 2
                             orderby r.Precio descending
                             select r;

            foreach (var item in resultado3)
            {
                Console.WriteLine($"{item.Id} {item.Descripcion} {item.Precio}");
            }

            Console.WriteLine("************************************");

            //Buscar productos con precio mayor a 2 ordenado descendente limitado
            //SQL equivalente -> SELECT Descripcion, Precio FROM ListaProductos WHERE Precio > 2 ORDER BY Precio DESC
            var resultado4 = from r in DataLists.ListaProductos
                             where r.Precio > 2
                             orderby r.Precio descending
                             select new { r.Descripcion, r.Precio };

            foreach (var item in resultado4)
            {
                Console.WriteLine($"{item.Descripcion} {item.Precio}");
            }


            /**************************** 
             * Métodos con LINQ
             ****************************/
            Console.WriteLine();
            Console.WriteLine("************************************");
            Console.WriteLine("Métodos: ");
            Console.WriteLine("************************************");


            //SELECT * FROM ListaProductos
            var result = DataLists.ListaProductos.ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Descripcion} {item.Precio}");
            }

            Console.WriteLine("************************************");

            //SELECT * FROM ListaProductos WHERE Precio > 2
            var resultWhere = DataLists.ListaProductos
                              .Where(x => x.Precio > 2)
                              .ToList();


            foreach (var item in resultWhere)
            {
                Console.WriteLine($"{item.Descripcion} {item.Precio}");
            }

            Console.WriteLine("************************************");

            //SELECT Descripcion, Precio FROM ListaProductos WHERE Precio > 2 ORDER BY Precio DESC

            var resultOrder = DataLists.ListaProductos
                              .Where(x => x.Precio > 2)
                              .OrderByDescending(x => x.Precio)
                              .ToList();

            foreach (var item in resultOrder)
            {
                Console.WriteLine($"#{item.Id}# {item.Descripcion} {item.Precio}");
            }

            Console.WriteLine("************************************");

            //SELECT Descripcion, Precio FROM ListaProductos WHERE Precio > 2 ORDER BY Precio DESC
            var resultWithFields = DataLists.ListaProductos
                                   .Where(x => x.Precio > 2)
                                   .OrderByDescending(x => x.Precio)
                                   .Select(x => new { x.Precio, x.Descripcion })
                                   .ToList();

            foreach (var item in resultWithFields)
            {
                Console.WriteLine($"{item.Descripcion} {item.Precio}");
            }


        }

    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaPedido { get; set; }
    }

    public class LineaPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

    public static class DataLists
    {

        //Se crea una lista privada de cada clase y se añaden elementos a cada una.

        private static List<Cliente> _listaClientes = new List<Cliente>() {
            new Cliente { Id = 1,   Nombre = "Carlos Gonzalez Rodriguez",   FechaNac = new DateTime(1980, 10, 10) },
            new Cliente { Id = 2,   Nombre = "Luis Gomez Fernandez",        FechaNac = new DateTime(1961, 4, 20) },
            new Cliente { Id = 3,   Nombre = "Ana Lopez Diaz ",             FechaNac = new DateTime(1947, 1, 15) },
            new Cliente { Id = 4,   Nombre = "Fernando Martinez Perez",     FechaNac = new DateTime(1981, 8, 5) },
            new Cliente { Id = 5,   Nombre = "Lucia Garcia Sanchez",        FechaNac = new DateTime(1973, 11, 3) }
        };

        private static List<Producto> _listaProductos = new List<Producto>()
        {
            new Producto { Id = 1,      Descripcion = "Boligrafo",          Precio = 0.35f },
            new Producto { Id = 2,      Descripcion = "Cuaderno grande",    Precio = 1.5f },
            new Producto { Id = 3,      Descripcion = "Cuaderno pequeño",   Precio = 1 },
            new Producto { Id = 4,      Descripcion = "Folios 500 uds.",    Precio = 3.55f },
            new Producto { Id = 5,      Descripcion = "Grapadora",          Precio = 5.25f },
            new Producto { Id = 6,      Descripcion = "Tijeras",            Precio = 2 },
            new Producto { Id = 7,      Descripcion = "Cinta adhesiva",     Precio = 1.10f },
            new Producto { Id = 8,      Descripcion = "Rotulador",          Precio = 0.75f },
            new Producto { Id = 9,      Descripcion = "Mochila escolar",    Precio = 12.90f },
            new Producto { Id = 10,     Descripcion = "Pegamento barra",    Precio = 1.15f },
            new Producto { Id = 11,     Descripcion = "Lapicero",           Precio = 0.55f },
            new Producto { Id = 12,     Descripcion = "Grapas",             Precio = 0.90f }
        };

        private static List<Pedido> _listaPedidos = new List<Pedido>()
        {
            new Pedido { Id = 1,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 2,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 8) },
            new Pedido { Id = 3,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 12) },
            new Pedido { Id = 4,     IdCliente = 1,  FechaPedido = new DateTime(2013, 11, 5) },
            new Pedido { Id = 5,     IdCliente = 2,  FechaPedido = new DateTime(2013, 10, 4) },
            new Pedido { Id = 6,     IdCliente = 3,  FechaPedido = new DateTime(2013, 7, 9) },
            new Pedido { Id = 7,     IdCliente = 3,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 8,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 8) },
            new Pedido { Id = 9,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 22) },
            new Pedido { Id = 10,    IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 29) },
            new Pedido { Id = 11,    IdCliente = 4,  FechaPedido = new DateTime(2013, 10, 19) },
            new Pedido { Id = 12,    IdCliente = 4,  FechaPedido = new DateTime(2013, 11, 11) }
        };

        private static List<LineaPedido> _listaLineasPedido = new List<LineaPedido>()
        {
            new LineaPedido() { Id = 1,  IdPedido = 1,  IdProducto = 1,     Cantidad = 9 },
            new LineaPedido() { Id = 2,  IdPedido = 1,  IdProducto = 3,     Cantidad = 7 },
            new LineaPedido() { Id = 3,  IdPedido = 1,  IdProducto = 5,     Cantidad = 2 },
            new LineaPedido() { Id = 4,  IdPedido = 1,  IdProducto = 7,     Cantidad = 2 },
            new LineaPedido() { Id = 5,  IdPedido = 2,  IdProducto = 9,     Cantidad = 1 },
            new LineaPedido() { Id = 6,  IdPedido = 2,  IdProducto = 11,    Cantidad = 15 },
            new LineaPedido() { Id = 7,  IdPedido = 3,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 8,  IdPedido = 3,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 9,  IdPedido = 4,  IdProducto = 2,     Cantidad = 3 },
            new LineaPedido() { Id = 10, IdPedido = 5,  IdProducto = 4,     Cantidad = 2 },
            new LineaPedido() { Id = 11, IdPedido = 6,  IdProducto = 1,     Cantidad = 20 },
            new LineaPedido() { Id = 12, IdPedido = 6,  IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 13, IdPedido = 7,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 14, IdPedido = 7,  IdProducto = 2,     Cantidad = 10 },
            new LineaPedido() { Id = 15, IdPedido = 7,  IdProducto = 11,    Cantidad = 2 },
            new LineaPedido() { Id = 16, IdPedido = 8,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 17, IdPedido = 8,  IdProducto = 3,     Cantidad = 9 },
            new LineaPedido() { Id = 18, IdPedido = 9,  IdProducto = 5,     Cantidad = 11 },
            new LineaPedido() { Id = 19, IdPedido = 9,  IdProducto = 6,     Cantidad = 9 },
            new LineaPedido() { Id = 20, IdPedido = 9,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 21, IdPedido = 10, IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 22, IdPedido = 10, IdProducto = 3,     Cantidad = 2 },
            new LineaPedido() { Id = 23, IdPedido = 10, IdProducto = 11,    Cantidad = 10 },
            new LineaPedido() { Id = 24, IdPedido = 11, IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 25, IdPedido = 12, IdProducto = 1,     Cantidad = 20 }
        };

        // Propiedades de los elementos privados
        //Getters de cada lista
        public static List<Cliente> ListaClientes { get { return _listaClientes; } }
        public static List<Producto> ListaProductos { get { return _listaProductos; } }
        public static List<Pedido> ListaPedidos { get { return _listaPedidos; } }
        public static List<LineaPedido> ListaLineasPedido { get { return _listaLineasPedido; } }
    }
}
