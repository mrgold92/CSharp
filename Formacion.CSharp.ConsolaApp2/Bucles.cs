using System;
using Formacion.CSharp.Objects;

namespace Formacion.CSharp.ConsolaApp2
{
    class Bucles
    {
        static void Main(string[] args)
        {
            //While y do-while
            bool testigo = true;

            while (testigo)
            {
                Console.WriteLine("Se ejecuta el bloque WHILE");
                break;
            }

            do
            {
                Console.WriteLine("Se ejecuta el bloque del DO/WHILE");
                break;

            } while (testigo);

            Console.WriteLine("");

            //Ejercicio: recorrer el array
            string[] frutasD = { "naranja", "limón", "pomelo", "lima", "fresa", "sandía", "melón" };
            int contador = 0;

            while (contador < frutasD.Length)
            {
                Console.WriteLine($"Fruta: {frutasD[contador]}");
                contador++;
            }

            contador = 0;
            Console.WriteLine("");

            do
            {
                Console.WriteLine($"Fruta: {frutasD[contador]}");
                contador++;
            } while (contador < frutasD.Length);

            Console.WriteLine("");

            Object[] objetos = { "naranja", 10, new Alumno(), new Reserva() };
            string[] frutas = { "naranja", "limón", "pomelo", "lima" };
            decimal[] numeros3 = { 10, 5, 345, 55, 13, 1000, 83 };


            //Foreach
            Console.WriteLine("Con foreach:");
            foreach (string fruta in frutas)
            {
                Console.WriteLine($"Fruta: {fruta}");
            }


            foreach (decimal num in numeros3)
            {
                Console.WriteLine(num);
            }

            foreach (var objeto in objetos)
            {
                Console.WriteLine(objeto);
            }


            Console.WriteLine("");

            //For
            Console.WriteLine("Con for:");
            for (int i = 0; i < frutas.Length; i++)
            {
                Console.WriteLine(frutas[i]);
            }

            for (int i = 0; i < numeros3.Length; i++)
            {
                Console.WriteLine(numeros3[i]);
            }

            for (int i = 0; i < objetos.Length; i++)
            {
                Console.WriteLine(objetos[i]);
            }

            Console.WriteLine("");


            //Ejercicio: Preguntamos un número y pintamos la tabla de multiplicar de ese número
            Console.Write("Dime un número: ");
            int.TryParse(Console.ReadLine(), out int numMulti);

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numMulti} x {i} = {numMulti * i} ");
            }

            Console.WriteLine("");

            //Ejercicio: suma de numeros y media con for y foreach

            decimal suma = 0, sumaForeach = 0;

            for (int i = 0; i < numeros3.Length; i++)
            {
                suma += numeros3[i];
            }

            foreach (decimal n in numeros3)
            {
                sumaForeach += n;
            }


            Console.WriteLine($"Suma de números con for: {suma}");
            Console.WriteLine($"Suma de números con foreach: {sumaForeach}");
            //Formateamos la división para que solo aparezcan dos decimales
            Console.WriteLine($"Media de números con for: {(suma / numeros3.Length).ToString("#.##")}");
            Console.WriteLine($"Media de números con foreach: {(sumaForeach / numeros3.Length).ToString("#.##")}");


            Console.WriteLine("");

            //Ejercicio: Mínimo y máximo con for y foreach
            decimal max = 0, min = numeros3[0];

            for (int i = 0; i < numeros3.Length; i++)
            {

                if (numeros3[i] > max)
                {
                    max = numeros3[i];
                }

                if (numeros3[i] < min)
                {
                    min = numeros3[i];
                }
            }


            decimal maxForeach = 0, minForeach = numeros3[0];
            foreach (decimal n in numeros3)
            {

                if (n > maxForeach)
                {
                    maxForeach = n;
                }

                if (n < minForeach)
                {
                    minForeach = n;
                }
            }




            Console.WriteLine($"Número mayor con for: {max}");
            Console.WriteLine($"Número menor con for: {min}");
            Console.WriteLine($"Número mayor con foreach: {maxForeach}");
            Console.WriteLine($"Número menor con foreach: {minForeach}");


            Console.WriteLine("");
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
