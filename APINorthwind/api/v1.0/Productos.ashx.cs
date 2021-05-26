using APINorthwind.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINorthwind.api.v1._0
{
    /// <summary>
    /// Descripción breve de Productos
    ///  https://localhost:44378/api/v1.0/productos.ashx?id=1
    /// </summary>
    public class Productos : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //Parametro id, que determina el id del producto
                string id = context.Request.Params["id"];
                int.TryParse(id, out int idInt);

                var db = new ModelNorthwind();
                db.Configuration.LazyLoadingEnabled = false;

                var producto = db.Employees
                    .Where(x => x.EmployeeID == idInt)
                    .FirstOrDefault();

                if (producto == null)
                {


                    context.Response.ContentType = "application/json";
                    context.Response.Write("Producto no encontrado");
                    context.Response.StatusCode = 200;
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(JsonConvert.SerializeObject(producto));
                    context.Response.StatusCode = 200;
                }
            }
            catch (Exception e)
            {
                context.Response.ContentType = "application/json";
                context.Response.Write(e.Message);
                context.Response.StatusCode = 500;
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}