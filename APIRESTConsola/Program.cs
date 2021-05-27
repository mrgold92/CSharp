using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using NorthwindDATA.Models;
using System.Net.Http.Headers;

namespace APIRESTConsola
{
    class Program
    {
        static readonly HttpClient http = new HttpClient();
        static readonly string url = "http://api.labs.com.es/v1.0/";

        static void Main(string[] args)
        {
            //HttpClientWithDynamic();

            Console.WriteLine("-------------------");

            //HttpClientWithCustomers();

            Console.WriteLine("-------------------");

            //HttpClientDemo();

            Console.WriteLine("-------------------");

            //HttpClientWithHeaders();

            Console.WriteLine("-------------------");

            //HttpClientWithHeaders2();

            Console.WriteLine("-------------------");

            //HttpClientPost();

            Console.WriteLine("-------------------");

            //Ejercicio1();

            Console.WriteLine("-------------------");

            //Ejercicio2();

            Console.WriteLine("-------------------");

            //Ejercicio3GET();

            Console.WriteLine("-------------------");

            //Ejercicio3POST();

            Console.WriteLine("-------------------");

            //Ejercicio3PUT();

            Console.WriteLine("-------------------");

            Ejercicio3DELETE();

        }

        static void HttpClientWithDynamic()
        {

            http.BaseAddress = new Uri(url);
            var response = http.GetAsync("clientes.ashx?all").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {

                var contenido = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Respuesta JSON: {0}", contenido);

                var clientes = JsonConvert.DeserializeObject<List<dynamic>>(contenido);

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());

            }
        }

        static void HttpClientWithCustomers()
        {

            http.BaseAddress = new Uri(url);
            var response = http.GetAsync("clientes.ashx?all").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {

                var contenido = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Respuesta JSON: {0}", contenido);

                var clientes = JsonConvert.DeserializeObject<List<Customers>>(contenido); // Añadiendo el using NorthwindDATA.Models (Librería)

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());

            }
        }

        static void HttpClientDemo()
        {
            http.BaseAddress = new Uri(url);

            var clientes = http.GetFromJsonAsync<List<Customers>>("clientes.ashx?all").Result;

            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
            }
        }

        static void HttpClientWithHeaders()
        {
            http.BaseAddress = new Uri(url);

            var request = new HttpRequestMessage(HttpMethod.Get, url + "clientes.ashx?all");

            //Headers
            request.Headers.Clear();

            //dos formas para el content-type
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("ContentType", "application/json");

            request.Headers.Add("User-Agent", "ConsoleApp for Nortwind");
            request.Headers.Add("Authorization", "key of access");

            var response = http.SendAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {

                var contenido = response.Content.ReadAsStringAsync().Result;


                var clientes = JsonConvert.DeserializeObject<List<dynamic>>(contenido);

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());

            }
        }

        static void HttpClientWithHeaders2()
        {
            http.BaseAddress = new Uri(url);
            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Add("ContentType", "application/json");
            http.DefaultRequestHeaders.Add("User-Agent", "ConsoleApp for Nortwind");
            http.DefaultRequestHeaders.Add("Authorization", "key of access");

            var response = http.GetAsync("clientes.ashx?all").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {

                var contenido = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Respuesta JSON: {0}", contenido);

                var clientes = JsonConvert.DeserializeObject<List<Customers>>(contenido); // Añadiendo el using NorthwindDATA.Models (Librería)

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());

            }
        }

        static void HttpClientPost()
        {
            http.BaseAddress = new Uri("https://postman-echo.com/");

            var region = new Region() { RegionID = 10, RegionDescription = "Comunidad de Madrid" };

            //Convertimos el objeto a json
            var regionJSON = JsonConvert.SerializeObject(region);
            //Console.WriteLine(regionJSON);

            //para enviar el contenido necesitamos un objeto de tipo content y pasarle el json, el encoding y el content-type
            var content = new StringContent(regionJSON, System.Text.Encoding.UTF8, "application/json");

            //enviamos la petición (la ruta es https://postman-echo.com/post)
            var response = http.PostAsync("post", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Respuesta: {responseContent}");

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());
            }

        }

        static void Ejercicio1()
        {
            //193.146.141.207
            //83.59.32.223
            //91.213.103.0
            string url = "http://ip-api.com/json/";

            Console.Write("Dime una dirección IP: ");
            var ip = Console.ReadLine();

            http.BaseAddress = new Uri(url);

            var response = http.GetAsync(ip).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {

                var contenido = response.Content.ReadAsStringAsync().Result;

                //JSON -> OBJECT
                var c = JsonConvert.DeserializeObject<dynamic>(contenido);


                Console.WriteLine($"Proveedor: {c.isp}");
                Console.WriteLine($"País: {c.country}");
                Console.WriteLine($"Región: {c.region}");
                Console.WriteLine($"Nombre región: {c.regionName}");
                Console.WriteLine($"Ciudad: {c.city}");
                Console.WriteLine($"Organización: {c.org}");
                Console.WriteLine($"Propietario: {c["as"]}");


            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());

            }
        }

        static void Ejercicio2()
        {
            http.BaseAddress = new Uri("https://localhost:44378/api/v1.0/");

            //Preguntamos por el id de un empleado de Northwind y retornamos los datos
            Console.Write("ID Empleado: ");
            var id = Console.ReadLine();

            var response = http.GetAsync("empleados.ashx?id=" + id).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {
                var contentType = response.Content.Headers.ContentType.MediaType;

                var contenido = response.Content.ReadAsStringAsync().Result;

                if (contentType == "text/plain")
                {
                    Console.WriteLine(contenido);

                }
                else if (contentType == "application/json")
                {
                    //JSON -> OBJECT
                    var c = JsonConvert.DeserializeObject<Employees>(contenido);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0,-20}", "Nombre:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{c.FirstName}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0,-20}", "Apellidos: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{c.LastName}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0,-20}", "Title: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{c.Title}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0,-20}", "Fecha nacimiento: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{((DateTime)c.BirthDate).ToShortDateString()}");

                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());

            }
        }

        static void Ejercicio3GET()
        {
            //all o id del producto

            http.BaseAddress = new Uri("https://localhost:44395/api/");

            //Preguntamos por el id de un producto de Northwind y retornamos los datos
            Console.Write("ID Producto: ");
            var id = Console.ReadLine().Trim();

            string url = (id == "" || id.ToLower() == "all") ? "products" : "products/" + id;


            var response = http.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {
                var contentType = response.Content.Headers.ContentType.MediaType;

                var contenido = response.Content.ReadAsStringAsync().Result;

                if (contentType == "text/plain")
                {
                    Console.WriteLine(contenido);

                }
                else if (contentType == "application/json")
                {

                    if (url == "products")
                    {
                        //JSON -> OBJECT
                        var collection = JsonConvert.DeserializeObject<List<Products>>(contenido);

                        foreach (var c in collection)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("{0,-20}", "Nombre:");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{c.ProductName}");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("{0,-20}", "Precio: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{c.UnitPrice}");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("{0,-20}", "Stock: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{c.UnitsInStock}");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        var c = JsonConvert.DeserializeObject<Products>(contenido);


                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0,-20}", "Nombre:");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{c.ProductName}");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0,-20}", "Precio: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{c.UnitPrice}");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0,-20}", "Stock: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{c.UnitsInStock}");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                    }


                }

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());

            }
        }

        static void Ejercicio3POST()
        {
            Products producto = new Products()
            {
                ProductName = "DEMO2",
                SupplierID = 1,
                CategoryID = 1,
                QuantityPerUnit = "10 kg",
                UnitPrice = 25,
                UnitsInStock = 200,
                UnitsOnOrder = 0,
                ReorderLevel = 10,
                Discontinued = false
            };
            http.BaseAddress = new Uri("https://localhost:44395/api/");


            var productoJSON = JsonConvert.SerializeObject(producto);
            var content = new StringContent(productoJSON, System.Text.Encoding.UTF8, "application/json");

            var response = http.PostAsync("products", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Created) // 201
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Respuesta: {responseContent}");

            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode.ToString());
            }

        }

        static void Ejercicio3PUT()
        {
            http.BaseAddress = new Uri("https://localhost:44395/api/");

            Console.Write("ID Producto: ");
            var id = Console.ReadLine().Trim();

            var response = http.GetAsync("products/" + id).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
            {

                var contenido = response.Content.ReadAsStringAsync().Result;

                //JSON -> OBJECT
                var producto = JsonConvert.DeserializeObject<Products>(contenido);

                //cambiamos el nombre
                producto.ProductName = "DEMOMODIFICADO";

                var productoJSON = JsonConvert.SerializeObject(producto);
                var content = new StringContent(productoJSON, System.Text.Encoding.UTF8, "application/json");

                var response2 = http.PutAsync("products/" + id, content).Result;


                if (response2.StatusCode == System.Net.HttpStatusCode.NoContent) // 204
                {
                    Console.WriteLine($"Producto modificado.");
                }
                else
                {
                    Console.WriteLine("Error: {0}", response2.StatusCode.ToString());
                }

            }
            else
            {
                Console.WriteLine("Algo ha fallado.");
            }




        }

        static void Ejercicio3DELETE()
        {
            http.BaseAddress = new Uri("https://localhost:44395/api/");

            Console.Write("ID Producto a eliminar: ");
            var id = Console.ReadLine().Trim();

            Console.WriteLine("¿Seguro que quieres eliminarlo? [s/n]");

            switch (Console.ReadLine().ToLower())
            {
                case "si":
                case "sí":
                case "s":
                case "y":
                case "yes":
                    var delete = http.DeleteAsync("products/" + id).Result;

                    if (delete.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responseContent = delete.Content.ReadAsStringAsync().Result;
                        Console.WriteLine($"Producto eliminado: {responseContent}");
                    }
                    else
                    {
                        Console.WriteLine("Error.");
                    }
                    break;
                default:
                    Console.WriteLine("Cancelado");
                    break;
            }

            var response = http.GetAsync("products/" + id).Result;
        }
    }
}
