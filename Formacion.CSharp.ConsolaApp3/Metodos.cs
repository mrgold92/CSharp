using System;
using Formacion.CSharp.Objects;

namespace Formacion.CSharp.ConsolaApp3
{
    class Metodos
    {
        static void Main(string[] args)
        {
            Alumno alumno = new Alumno() { nombre = "Pepe", apellidos = "Sánchez", edad = 29 };
            //Retornamos un console.writeline
            alumno.pintaNombre(100, "Sr.");
            alumno.pintaNombre(0, "Sr.");
            alumno.pintaNombre(100, "");
            alumno.pintaNombre(0, "");

            alumno.pintaNombre(prefijo: "Sr.", modo: 100);
            alumno.pintaNombre(0);
            alumno.pintaNombre(100, param2: "DEMO");


            //Retornamos un string
            Console.WriteLine(alumno.nombreCompleto());


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
        public string nombre = "Pepe";
        public string apellidos = "García";
        public int edad = 28;

        /// <summary>
        /// Pinta el nombre y los apellidos del Alumno
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="prefijo"></param>
        public void pintaNombre(int modo, string prefijo = "Don", string param1 = "", string param2 = "")
        {
            if (prefijo.Length > 0)
            {
                if (modo == 100)
                {
                    Console.WriteLine($"{prefijo} {this.apellidos}, {this.nombre} ");
                }
                else
                {
                    Console.WriteLine($"{prefijo} {this.nombre} {this.apellidos}");
                }


            }
            else
            {
                Console.WriteLine($"{this.nombre}, {this.apellidos} ");


            }

        }

        public string nombreCompleto()
        {
            return $"{this.nombre} {this.apellidos}";
        }
    }

    public class Reserva
    {
        public string id;
        public string cliente;

        //100:habitación individual
        //200:habitación doble
        //300:junior suite
        //400:suit
        public int tipo;
        public bool fumador;
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
