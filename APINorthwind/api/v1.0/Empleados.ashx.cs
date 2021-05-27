using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APINorthwind.Models;
using Newtonsoft.Json;

namespace APINorthwind.api.v1._0
{
    /// <summary>
    /// Descripción breve de Empleados
    /// https://localhost:44378/api/v1.0/empleados.ashx?id=1
    /// </summary>
    public class Empleados : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                //Parametro id, que determina el id del empleado
                string id = context.Request.Params["id"];
                int.TryParse(id, out int idInt);

                var db = new ModelNorthwind();
                db.Configuration.LazyLoadingEnabled = false;

                var empleado = db.Employees
                    .Where(x => x.EmployeeID == idInt)
                    .FirstOrDefault();

                if (empleado != null)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(JsonConvert.SerializeObject(empleado));
                    context.Response.StatusCode = 200;
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Empleado no encontrado");
                    context.Response.StatusCode = 200;
                }
            }
            catch (Exception e)
            {
                context.Response.ContentType = "text/plain";
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