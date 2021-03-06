using System;
using System.Collections.Generic;
using System.Linq;

/*************************************************************
 * A1. Listado de Pedidos con el importe total.
 * B1. Cliente que han comprado más de 10 unidades.
 * C1. Productos que han comprado más de un cliente.
 * D1. Productos del que se ha vendido menos unidades.
 * E1. Cliente que se ha gastado más dinero.
 * F1. Pregunta por el código de un pedido.
 * F2. Muestra los datos del cliente.
 * F3. Muestra los datos del pedido.
 * F4. Muestra el detalle del pedido con los totales.
 **************************************************************/
namespace LINQ
{
    class Program
    {

        static void Main(string[] args)
        {

            //A1();
            //B1();
            //C1(); //<--TODO
            //D1();
            //E1();
            //F1();
            //F2();
            //F3();
            F4();

        }

        /****************************************
        *               EJERCICIOS              *
        ****************************************/

        /// <summary>
        ///  Listado de Pedidos con el importe total.
        /// </summary>
        static void A1()
        {
            var dat2 = DataLists.ListaLineasPedido.GroupBy(a => a.IdPedido)
              .Select(r => new
              {
                  r.Key,
                  lineas = r,
                  totalPedido = r.Sum(x => x.Cantidad * (DataLists.ListaProductos.Where(s => s.Id == x.IdProducto).Select(h => h.Precio).FirstOrDefault()))
              }).ToList();


            foreach (var item in dat2)
            {
                Console.WriteLine($"Clave (IdPedido): {item.Key} - Total pedido: {item.totalPedido}");
            }
        }

        /// <summary>
        /// Clientes que han comprado más de 10 unidades
        /// </summary>
        static void B1()
        {

            var data = DataLists.ListaLineasPedido
               .GroupBy(x => x.IdPedido)
               .Where(r => r.Sum(x => x.Cantidad) > 10)
               .Select(r => new
               {

                   Clientes = DataLists.ListaClientes
                                       .Where(x => x.Id == DataLists.ListaPedidos
                                                           .Where(x => x.Id == r.Key)
                                                           .Select(y => y.IdCliente)
                                                           .FirstOrDefault())
                                       .Select(q => new { id = q.Id, Nombre = q.Nombre })

                                       .FirstOrDefault()


               }).Distinct().ToList();

            foreach (var bb in data)
            {
                Console.WriteLine($"Cliente: {bb.Clientes.Nombre}");
            }


            //var b = DataLists.ListaLineasPedido
            //    .Where(x => x.Cantidad > 10)
            //    .Select(r => new
            //    {
            //        Clientes = DataLists.ListaClientes
            //                    .Where(x => x.Id == DataLists.ListaPedidos
            //                                        .Where(x => x.Id == r.IdPedido)
            //                                        .Select(y => y.IdCliente)
            //                                        .FirstOrDefault())
            //                    .Select(q => new { id = q.Id, Nombre = q.Nombre })

            //                    .FirstOrDefault()

            //    }).Distinct().ToList();

            ///Console.WriteLine($"Numero de clientes que han comprado más de 10 unidades: {b.Count()}");




            //foreach (var d in data)
            //{
            //    Console.WriteLine($"Id pedido: {d.Key}  - Cantidad: { d.cantidad}");
            //    Console.WriteLine();
            //}



        }

        /// <summary>
        /// Productos que han comprado más de un cliente.
        /// </summary>
        // TODO
        static void C1()
        {
            //Productos

            //Productos que ha comprado más de un cliente



            //foreach (var pedido in pedidos)
            //{

            //    Console.WriteLine($"ID pedido: {pedido.Id} - Cliente: {pedido.IdCliente}");

            //    var idProductos = DataLists.ListaLineasPedido.Where(x => x.IdPedido == pedido.Id).Select(x => x.IdProducto).ToList();

            //    foreach (var id in idProductos)
            //    {

            //        var productos = DataLists.ListaProductos.Where(x => x.Id == id).ToList();

            //        foreach (var producto in productos)
            //        {
            //            Console.WriteLine("--> " + producto.Descripcion);


            //        }

            //    }


            //}
            //}

        }

        /// <summary>
        /// Productos del que se ha vendido menos unidades.
        /// </summary>
        static void D1()
        {
            var data = DataLists.ListaLineasPedido
               .GroupBy(x => x.IdProducto)
                .Select(r => new
                {
                    r.Key,
                    cantidad = r.Sum(s => s.Cantidad)
                    //cantidad =r.Sum(x => r.Select(h=>h.Cantidad).FirstOrDefault()),
                }).OrderBy(x => x.cantidad).ToList();


            foreach (var d in data)
            {
                Console.WriteLine($"Id producto: {d.Key}  - Cantidad: { d.cantidad}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Cliente que se ha gastado más dinero.
        /// </summary>
        static void E1()
        {
            var data = DataLists.ListaLineasPedido
               .GroupBy(x => x.IdPedido)
               .Select(r => new
               {
                   r.Key,
                   maximo = r.Max(x => x.Cantidad),
                   Clientes = DataLists.ListaClientes
                                       .Where(x => x.Id == DataLists.ListaPedidos
                                                           .Where(x => x.Id == r.Key)
                                                           .Select(y => y.IdCliente)
                                                           .FirstOrDefault())
                                       .Select(q => new { id = q.Id, Nombre = q.Nombre })

                                       .FirstOrDefault()


               }).OrderByDescending(x => x.maximo).FirstOrDefault();


            Console.WriteLine("El cliente que se ha gastado más dinero es:\n");
            Console.WriteLine("{0,-8} {1,5}", "ID:", "Nombre:");
            Console.WriteLine("{0,-8} {1,5}", data.Clientes.id, data.Clientes.Nombre);

        }

        /// <summary>
        /// Pregunta por el código de un pedido.
        /// </summary>
        static void F1()
        {
            Console.Write("Dime el código de pedido: ");
            int.TryParse(Console.ReadLine(), out int idPedido);

            var pedido = DataLists.ListaPedidos.Where(x => x.Id == idPedido).FirstOrDefault();

            Console.WriteLine($"ID pedido: {idPedido}");
            Console.WriteLine($"Fecha pedido: {pedido.FechaPedido.ToShortDateString()}");
            Console.WriteLine($"Cliente del pedido: {pedido.IdCliente}");
        }

        /// <summary>
        /// Muestra los datos del cliente
        /// </summary>
        static void F2()
        {
            Console.Write("Dime el código de pedido: ");
            int.TryParse(Console.ReadLine(), out int idPedido);

            var pedidos = DataLists.ListaPedidos.Where(x => x.Id == idPedido)
                .Select(r => new
                {
                    r,
                    Cliente = DataLists.ListaClientes.Where(x => x.Id == r.IdCliente).FirstOrDefault()
                }).FirstOrDefault();


            Console.WriteLine($"Pedido id: {pedidos.r.Id}");
            Console.WriteLine($"-->Id cliente: {pedidos.Cliente.Id}");
            Console.WriteLine($"-->Nombre cliente: {pedidos.Cliente.Nombre}");

        }


        /// <summary>
        /// Muestra los datos del pedido.
        /// </summary>
        static void F3()
        {
            Console.Write("Dime el código de pedido: ");
            int.TryParse(Console.ReadLine(), out int idPedido);

            var pedido = DataLists.ListaPedidos.Where(x => x.Id == idPedido)
                .Select(r => new
                {
                    r,
                    Pedido = DataLists.ListaPedidos.Where(x => x.Id == r.Id).FirstOrDefault()
                }).FirstOrDefault();


            Console.WriteLine($"-->Id Pedido: {pedido.Pedido.Id}");
            Console.WriteLine($"-->Id del cliente: {pedido.Pedido.IdCliente}");
            Console.WriteLine($"-->Fecha del pedido: {pedido.Pedido.FechaPedido.ToShortDateString()}");

        }

        /// <summary>
        ///  Muestra el detalle del pedido con los totales.
        /// </summary>
        static void F4()
        {
            Console.Write("Dime el código de pedido: ");
            int.TryParse(Console.ReadLine(), out int idPedido);

            var pedidos = DataLists.ListaLineasPedido
                .Where(x => x.IdPedido == idPedido)
                .GroupBy(x => x.IdProducto)
                .Select(r => new
                {

                    cantidad = r.Select(x => x.Cantidad).FirstOrDefault(),
                    Productos = DataLists.ListaProductos.Where(x => x.Id == r.Key).Select(h => new { h }).FirstOrDefault(),

                })
                .ToList();

            Console.WriteLine($"Pedido id: {idPedido}");
            Console.WriteLine();
            Console.WriteLine("Productos:");

            float total = 0;
            Console.WriteLine("{0, -10} {1, -20} {2, 10} {3, 10}", "ID", "Producto", "Cantidad", "Pprecio");
            foreach (var item in pedidos)
            {

                Console.Write("{0,-10}", item.Productos.h.Id);
                Console.Write("{0, -20}", item.Productos.h.Descripcion);
                Console.Write("{0, 10}", item.cantidad);
                Console.Write("{0, 10}", item.Productos.h.Precio);
                total += item.cantidad * item.Productos.h.Precio;
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Total: {total}");






        }
        /****************************************
        *               CLASES                 *
        ****************************************/


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
}
