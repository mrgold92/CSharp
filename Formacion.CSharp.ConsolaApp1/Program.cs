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

            Reserva reserva = new Reserva();

            Console.Write("ID de la reserva: ");
            reserva.id = Console.ReadLine();

            Console.Write("Nombre del cliente: ");
            reserva.cliente = Console.ReadLine();

            Console.Write("Tipo de reserva: ");
            //reserva.tipo = Convert.ToInt32(Console.ReadLine());

            string respuesta = Console.ReadLine();
            //int.TryParse(respuesta, out int respuestaNumero);
            //var respuestNum = int.TryParse(respuesta, out _);
            int.TryParse(respuesta, out reserva.tipo);


            Console.Write("¿Es fumador?: ");
            //reserva.fumador = Convert.ToBoolean(Console.ReadLine());
            string respuesta2 = Console.ReadLine();

            // Con if

            //if (respuesta2.ToLower().Trim() == "si" || respuesta2.ToLower().Trim() == "s" || respuesta2.ToLower().Trim() == "sí")
            //{
            //    reserva.fumador = true;
            //}
            //else
            //{
            //    reserva.fumador = false;
            //}

            // Con operadores ternarios

            //reserva.fumador = respuesta2.ToLower().Trim() == "si"
            //                || respuesta2.ToLower().Trim() == "s"
            //                || respuesta2.ToLower().Trim() == "sí"
            //                ? true
            //                : false;

            // Con switch
            switch (respuesta2.ToLower().Trim())
            {
                case "si":
                case "s":
                case "sí":
                    reserva.fumador = true;
                    break;
                default:
                    reserva.fumador = false;
                    break;
            }


            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ID Reserva:".PadRight(15, ' '));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(reserva.id);


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Cliente:".PadRight(15, ' '));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(reserva.cliente);

            string tipo = "Ha reservado una ";

            switch (reserva.tipo)
            {
                case 100:
                    tipo += "habitación individual";
                    break;
                case 200:
                    tipo += "habitación doble";
                    break;
                case 300:
                    tipo += "junior suite";
                    break;
                case 400:
                    tipo += "suit";
                    break;
                default:
                    tipo = $"Habitación {reserva.tipo} desconocida";
                    break;
            }


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Tipo:".PadRight(15, ' '));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(tipo);


            string fuma = reserva.fumador == true ? "Es fumador" : "No es fumador";

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("¿Fuma?:".PadRight(15, ' '));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(fuma);


            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();


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
            //byte.TryParse(c, out byte respuestaNumero);
            //var respuestNum = byte.TryParse(c, out _);
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
}