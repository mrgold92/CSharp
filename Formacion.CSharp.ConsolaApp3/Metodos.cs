using System;
using Formacion.CSharp.Objects;

namespace Formacion.CSharp.ConsolaApp3
{
    class Metodos
    {
        static void Main(string[] args)
        {
            Alumno alumno = new Alumno() { Nombre = "Pepe", Apellidos = "Sánchez", Edad = 29 };
            //Retornamos un console.writeline
            alumno.PintarNombre(100, "Sr.");
            alumno.PintarNombre(0, "Sr.");
            alumno.PintarNombre(100, "");
            alumno.PintarNombre(0, "");

            alumno.PintarNombre(prefijo: "Sr.", modo: 100);
            alumno.PintarNombre(0);
            alumno.PintarNombre(100, param2: "DEMO");


            //Retornamos un string
            Console.WriteLine(alumno.NombreCompleto());


            Calculos calculos = new Calculos();
            int nm1 = 25;
            int nm2 = 65;
            int result = 0;

            Console.WriteLine("Num1: {0} - Num2: {1} - Resultado: {2}", nm1, nm2, result);
            calculos.suma(nm1, nm2, result);
            Console.WriteLine("Num1: {0} - Num2: {1} - Resultado: {2}", nm1, nm2, result);
            calculos.suma(nm1, nm2, ref result);
            Console.WriteLine("Num1: {0} - Num2: {1} - Resultado: {2}", nm1, nm2, result);
        }
    }
}


namespace Formacion.CSharp.Objects
{
    public class Alumno
    {
        public string Nombre = "Pepe";
        public string Apellidos = "García";
        public int Edad = 28;

        /// <summary>
        /// Pinta el nombre y los apellidos del Alumno
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="prefijo"></param>
        public void PintarNombre(int modo, string prefijo = "Don", string param1 = "", string param2 = "")
        {
            if (prefijo.Length > 0)
            {
                if (modo == 100)
                {
                    Console.WriteLine($"{prefijo} {this.Apellidos}, {this.Nombre} ");
                }
                else
                {
                    Console.WriteLine($"{prefijo} {this.Nombre} {this.Apellidos}");
                }


            }
            else
            {
                Console.WriteLine($"{this.Nombre}, {this.Apellidos} ");
            }

        }

        public string NombreCompleto()
        {
            return $"{this.Nombre} {this.Apellidos}";
        }
    }

    public class Calculos
    {
        /// <summary>
        /// Método suma con parámetro valor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="resultado"></param>
        public void suma(int a, int b, int resultado)
        {
            resultado = a + b;
            Console.WriteLine("Método suma: el resultado es {0}", resultado);
        }

        /// <summary>
        /// Método suma con parámetro referencia
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="resultado"></param>
        public void suma(int a, int b, ref int resultado)
        {
            resultado = a + b;
            Console.WriteLine("Método suma: el resultado es {0}", resultado);

        }
    }
}
