using System;
using Formacion.CSharp.Objects;

namespace Formacion.CSharp.ConsolaApp3
{
    class Metodos
    {
        static void Main(string[] args)
        {


            /*==========================================
             *
             * Delegados y Eventos
             *
             *==========================================*/


            /*==========================================
             *
             * Objetos, constructores, getters y settes
             *
             *==========================================*/

            Alumno alumno = new Alumno() { Nombre = "Pepe", Apellidos = "Sánchez", Edad = 29 };
            //Retornamos un console.writeline
            alumno.PintarNombre(100, "Sr.");
            alumno.PintarNombre(0, "Sr.");
            alumno.PintarNombre(100, "");
            alumno.PintarNombre(0, "");

            alumno.PintarNombre(prefijo: "Sr.", modo: 100);
            alumno.PintarNombre(0);
            alumno.PintarNombre(100, param2: "DEMO");

            Console.WriteLine($"Retornando propio objeto: {alumno.GetObject()}");
            Console.WriteLine("Alumno nombre completo: {0}", alumno.nombreCompleto);


            //Retornamos un string
            Console.WriteLine(alumno.NombreCompleto());

            /*==========================================
            *
            * Paso por referencia y por valor
            *
            *==========================================*/

            Calculos calculos = new Calculos();
            int nm1 = 25;
            int nm2 = 65;
            int result = 0;

            Console.WriteLine("Num1: {0} - Num2: {1} - Resultado: {2}", nm1, nm2, result);
            calculos.suma(nm1, nm2, result);
            Console.WriteLine("Num1: {0} - Num2: {1} - Resultado: {2}", nm1, nm2, result);
            calculos.suma(nm1, nm2, ref result);
            Console.WriteLine("Num1: {0} - Num2: {1} - Resultado: {2}", nm1, nm2, result);

            Console.WriteLine("------------------------");


            /*==========================================
            *
            * Class y Struct
            *
            *==========================================*/

            //clase
            Alumno alumno1 = new Alumno() { Nombre = "María José", Apellidos = "Sanz" };
            Console.WriteLine("Alumno: {0} {1}", alumno1.Nombre, alumno1.Apellidos);
            calculos.TomarDatos(alumno1);
            Console.WriteLine("Alumno: {0} {1}", alumno1.Nombre, alumno1.Apellidos);

            Console.WriteLine("------------------------");

            //struct
            //Struct es de tipo valor, no referencia, como las clases, por lo tanto no cambian el objeto original
            //Struct está pensando para pequeños objetos, si son muy grandes, mejor una class
            Alumno2 alumno2 = new Alumno2() { Nombre = "María José", Apellidos = "Sanz" };
            Console.WriteLine("Alumno: {0} {1}", alumno2.Nombre, alumno2.Apellidos);
            calculos.TomarDatos2(alumno2);
            Console.WriteLine("Alumno: {0} {1}", alumno2.Nombre, alumno2.Apellidos);

            //Si queremos pasarlo como referencia, en un struct, deberemos poner ref.
            calculos.TomarDatos2Ref(ref alumno2);
            Console.WriteLine("Alumno: {0} {1}", alumno2.Nombre, alumno2.Apellidos);
        }
    }
}


namespace Formacion.CSharp.Objects
{
    public class Alumno
    {
        private string nombre;
        private string apellidos;
        private int edad;

        // Sobrecarga constructores
        public Alumno()
        {

        }

        public Alumno(string nombre)
        {
            this.nombre = nombre;
        }

        public Alumno(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.Apellidos = apellidos;
        }

        public Alumno(string nombre, string apellidos, int edad)
        {
            this.nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
        }


        //Getters y Setters

        // Forma 1
        public int Edad
        {
            get
            {
                return edad;
            }

            set
            {
                if (value >= 18)
                {
                    edad = value;
                }
            }
        }

        public string nombreCompleto
        {
            get
            {
                return $"{this.Nombre} {this.Apellidos}";
            }
        }


        //Forma 2
        public string Nombre { get => nombre; set => nombre = value; }
        //public int Edad { get => edad; set => edad = value; }

        //Forma 3
        //No necesitaríamos en este caso la variable de arriba
        public string Apellidos { get; set; }





        // Destructores: no tienen tipo, comienza por ~ más el nombre de la clase
        // No se le puede llamar y se ejecuta automáticamente.
        // No recibe parámetros.
        ~Alumno()
        {
            Console.WriteLine("Inicio destructor de Alumno.");

            this.nombre = null;
            this.Apellidos = null;
        }


        /// <summary>
        /// Pinta el nombre y los apellidos del Alumno
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="prefijo"></param>
        /// Los parámetros opcionales deben ir siempre detrás de todos los parámetros obligatorios.
        public void PintarNombre(int modo, string prefijo = "Don", string param1 = "", string param2 = "")
        {
            if (prefijo.Length > 0)
            {
                if (modo == 100)
                {
                    Console.WriteLine($"{prefijo} {this.Apellidos}, {this.nombre} ");
                }
                else
                {
                    Console.WriteLine($"{prefijo} {this.nombre} {this.Apellidos}");
                }

            }
            else
            {
                Console.WriteLine($"{this.nombre}, {this.Apellidos} ");
            }

        }

        public string NombreCompleto()
        {
            return $"{this.nombre} {this.Apellidos}";
        }

        public Alumno GetObject()
        {
            return this;
        }
    }

    public struct Alumno2
    {
        public string Nombre;
        public string Apellidos;
        public int Edad;

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

        public void TomarDatos(Alumno a)
        {
            Console.Write("Nombre: ");
            a.Nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            a.Apellidos = Console.ReadLine();
        }

        public void TomarDatos2(Alumno2 a)
        {
            Console.Write("Nombre: ");
            a.Nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            a.Apellidos = Console.ReadLine();
        }

        public void TomarDatos2Ref(ref Alumno2 a)
        {
            Console.Write("Nombre: ");
            a.Nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            a.Apellidos = Console.ReadLine();
        }
    }
}
