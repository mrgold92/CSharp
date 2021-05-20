using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using NorthwindDATA.Models;

namespace LinqData
{
    class Program
    {
        static void Main(string[] args)
        {
            TrabajandoConADONET();

            Console.WriteLine("-------------------");

            TrabajandoConEF();
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

            //Consola de datos - SELECT
            //Equivalente a: SELECT * FROM Customers
            var context = new ModelNorthwind();
            var clientes = context.Customers.ToList();
            //var clientes2 = from c in context.Customers select c;

            foreach (var item in clientes)
            {
                Console.WriteLine($"ID: {item.CustomerID}");
                Console.WriteLine($"Empresa: {item.CompanyName}");
                Console.WriteLine($"País: {item.Country}");
            }


        }
    }
}
