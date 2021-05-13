using System;
using Formacion.CSharp.Objects;
using System.Text;

namespace Formacion.CSharp.ConsolaApp1
{
    /// <summary>
    /// Clase principal del primer bloque.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {

            byte a = 10; // 8 bits
            int b = 1012; // 16 bits
            string c = "42";
            


            Alumno alumno1 = new Alumno();
            var alumno2 = new Alumno();
            Object alumno3 = new Alumno();
            dynamic alumno4 = new Alumno();

            Console.WriteLine("Tipo variable 1:" + alumno1.GetType());
            Console.WriteLine("Nombre: {0}", alumno1.nombre);

            Console.WriteLine("Tipo variable 2:" + alumno2.GetType());
            Console.WriteLine("Nombre: {0}", alumno2.nombre);

            // El tipo object necesita un casting para poder usar sus métodos
            // o llamar a sus parámetros
            Console.WriteLine("Tipo variable 3:" + alumno3.GetType());
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno3).nombre);

            // Las variables de tipo dynamic, no se comprueban en desarrollo,
            // solo en tiempo de ejecución, es decir, todo lo admite aunque no exista,
            // hata que ejecutemos el programa, que saltará error si no existe.
            //
            // Si queremos trabajar con autocompletado, etc, deberemos hacer un casting.
            Console.WriteLine("Tipo variable 4:" + alumno4.GetType());
            Console.WriteLine("Nombre: {0}", alumno4.nombre);
            Console.WriteLine($"Nombre: {alumno4.nombre}"); //Otra forma de interpolar texto y código
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno4).nombre);



            b = a; // Conversión implícita, porque el receptor es de mayor tamaño en bits.
            //a = b;  Conversión implícita. Error, porque el receptor es de menor tamaño en bits.

            a = (byte)b; // Conversión explícita -> Obligamos a que transforme el tipo int en byte (sabiendo que podemos perder información).

            // Conversión explícita -> Otra forma de transformar el tipo de dato.
            // A diferencia del casting anterior, si no puede transformarlo, porque sea
            // demasiado grande, saltará un error.
            a = Convert.ToByte(b);


            Console.WriteLine($"A , B = {a} , {b}");

            // Transformamos string en byte. a->42
            // Si no se puede convertir (porque haya texto), el valor será 0.
            byte.TryParse(c, out a);
            Console.WriteLine(a);

            // En este caso, si no es posible la conversión,
            // saltaría un error. Se suele utilizar TryParse
            // para que no genere error y devuelva 0.
            a = byte.Parse(c);
            Console.WriteLine(a);

            // Forma de concatenar texto.
            StringBuilder address = new StringBuilder();
            address.Append("23");
            address.Append(", Main Street");
            address.Append(", Bufalo");
            string concatened = address.ToString();

            Console.WriteLine(concatened);


            // Arrays

            int numero = 10;
            int[] numeros = new int[10];
            int[] numeros2 = { 10, 5, 345, 55, 13, 1000, 83 };

            numeros[7] = 32;
            Console.WriteLine(numeros[7]);

            Alumno[] alumnos = new Alumno[20];
            Alumno[] alumnos2 = { new Alumno() { nombre = "Pepe", apellidos = "García", edad = 19 }, new Alumno(), new Alumno() };

            Console.WriteLine(alumnos2[0].nombre);

            alumnos2[1].nombre = "Óscar";
            Console.WriteLine(alumnos2[1].nombre);




        }
    }

}

namespace Formacion.CSharp.Objects
{
    /// <summary>
    /// Clase Alumno
    /// </summary>
    public class Alumno
    {
        public string nombre = "Pepe";
        public string apellidos = "García";
        public int edad = 28;

    }
}