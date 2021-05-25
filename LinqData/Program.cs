using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using NorthwindDATA.Models;
using Microsoft.EntityFrameworkCore; //<-- para poder hacer include

namespace LinqData
{
    class Program
    {
        static void Main(string[] args)
        {
            //TrabajandoConADONET();

            Console.WriteLine("-------------------");

            //TrabajandoConEF();

            Console.WriteLine("-------------------");

            TrabajandoConEFInclude();

        }

        static void TrabajandoConADONET()
        {
            //ADO.NET Acces Data Object(manejamos las bases de datos con Transat-SQL)

            //Consola de datos - SELECT
            //Equivalente a: SELECT * FROM Customers

            //1. Crear un objeto para definir cadena de conexión
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "LOCALHOST",
                InitialCatalog = "NORTHWIND",
                UserID = "",
                Password = "",
                IntegratedSecurity = true,
                ConnectTimeout = 60
            };

            //Muestra la cadena de conexión resultante con los datos introducidos
            Console.WriteLine($"Cadena de conexión: {connectionString.ToString()}");

            //2. Creamos un objeto conexión, representa la conexión con la bbdd
            //Como parámetro le pasamos la cadena de conexión
            var connect = new SqlConnection(connectionString.ToString());
            Console.WriteLine($"Estado: {connect.State}");

            //3. Abrir la conexión con la bbdd
            connect.Open();
            Console.WriteLine($"Estado: {connect.State}");

            //4. Creamos un objeto Command que nos permite lanzar comandos contra la bbdd
            var command = new SqlCommand()
            {
                Connection = connect,
                CommandText = "SELECT * FROM dbo.Customers"
            };

            //5. Creamos un cursor para recoger los datos y después recorrerlos
            var reader1 = command.ExecuteNonQuery(); //<-- Cuando el comando no devuelva datos (ej: INSERT)
            var reader2 = command.ExecuteReader(); //<--Para cuando el comando devuelva datos (ej: SELECT)

            if (!reader2.HasRows) //<-- Preguntamos si tiene datos --> true | false
            {
                Console.WriteLine("Registros no encontrados.");
            }
            else
            {

                while (reader2.Read())
                {
                    Console.WriteLine($"ID: {reader2["CustomerID"]}");
                    Console.WriteLine($"Empresa: {reader2["CompanyName"]}");
                    Console.WriteLine($"País: {reader2["Country"]}");

                }
            }

            //6. Cerramos conexiones
            reader2.Close();
            command.Dispose();
            connect.Close();
            connect.Dispose();
        }

        static void TrabajandoConEF()
        {
            //EntityFramework(manejamos las bases de datos como colecciones)
            var context = new ModelNorthwind();
            //Insertar datos
            //Equivalente a: INSERT INTO Customers VALUES(...,...,)
            var clienteNuevo = new Customers()
            {
                CustomerID = "DEMO1",
                CompanyName = "Empresa Uno, S.L.",
                ContactName = "David Salazar",
                ContactTitle = "Gerente",
                Address = "Calle si nombre, s/n",
                City = "Madrid",
                Region = "Madrid",
                PostalCode = "12345",
                Country = "Spain",
                Phone = "+34 123456789",
                Fax = "+34 123456789"


            };

            //Si ya existe, nos daría un error
            try
            {
                context.Customers.Add(clienteNuevo);
                context.SaveChanges(); //<-- Hay que confirmar el guardado, por eso lo ponemos en un try/catch

            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e) { Console.WriteLine(e.Message); }


            //Consola de datos - SELECT
            //Equivalente a: SELECT * FROM Customers

            var clientes = context.Customers.ToList();
            //var clientes2 = from c in context.Customers select c;

            foreach (var item in clientes)
            {
                Console.WriteLine($"ID: {item.CustomerID}");
                Console.WriteLine($"Empresa: {item.CompanyName}");
                Console.WriteLine($"Ciudad: {item.City}");
                Console.WriteLine($"País: {item.Country}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("---------------------");

            //Filtrar
            var clientes2 = context.Customers
                .Where(r => r.Country == "Spain")
                .OrderBy(r => r.City)
                .ToList();

            //con exp
            var clientes3 = from c in context.Customers
                            where c.Country == "Spain"
                            orderby c.City
                            select c;

            foreach (var item in clientes2)
            {
                Console.WriteLine($"ID: {item.CustomerID}");
                Console.WriteLine($"Empresa: {item.CompanyName}");
                Console.WriteLine($"Ciudad: {item.City}");
                Console.WriteLine($"País: {item.Country}");
                Console.WriteLine();
            }

            //Modificar
            //Equivale a: UPDATE Customers SET ... = ... WHERE ... = ...;
            var c1 = context.Customers
                .Where(r => r.CustomerID == "DEMO1")
                .FirstOrDefault();


            c1.CompanyName = "Empresa Uno Dos y Tres, S.L.";
            c1.PostalCode = "28001";


            //Eliminar

            // si es 1 registro
            context.Customers.Remove(context.Customers.Where(r => r.CustomerID == "DEMO1").FirstOrDefault());
            context.SaveChanges();


            // si nos devuelve una lista (más de 1 registro)
            // context.Customers.RemoveRange(context.Customers.Where(r => r.Country == "Spain").ToList());

        }

        static void TrabajandoConEFInclude()
        {
            var context = new ModelNorthwind();

            //SELECT * FROM Customers WHERE CustomerID = 'ANATR
            var cliente = context.Customers.Where(r => r.CustomerID == "ANATR").FirstOrDefault();

            //SELECT * FROM Orders WHERE CustomerID = 'ANATR'
            var pedidos = context.Orders.Where(r => r.CustomerID == "ANATR").ToList();

            //SELECT* FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID WHERE c.CustomerID = 'ANATR'
            //Con métodos
            var clientePedidos = context.Customers.Include(r => r.Orders).Where(r => r.CustomerID == "ANATR").FirstOrDefault();

            //Con expresiones
            var clientePedidos2 = (from c in context.Customers
                                   join o in context.Orders on c.CustomerID equals o.CustomerID
                                   where c.CustomerID == "ANATR"
                                   select c).FirstOrDefault();


            Console.WriteLine("Con métodos: \n");
            Console.WriteLine($"Cliente: {clientePedidos.CompanyName}\n");
            foreach (var item in clientePedidos.Orders)
            {
                Console.WriteLine($"Order ID: {item.OrderID}");
                Console.WriteLine($"Ship name: {item.ShipName}");
                Console.WriteLine();
            }

            Console.WriteLine("Con expresiones: \n");
            Console.WriteLine($"Cliente: {clientePedidos2.CustomerID}\n");
            foreach (var item in clientePedidos2.Orders)
            {
                Console.WriteLine($"Order ID: {item.OrderID}");
                Console.WriteLine($"Ship name: {item.ShipName}");
                Console.WriteLine();
            }


        }
    }
}
