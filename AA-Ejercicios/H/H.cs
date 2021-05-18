using System;
/******************************************************************
* H1. Muestra las siguientes secuencias de número utilizando
* un WHILE:
*  * del 1 al 100
*  * los números impares del 51 al 91
*  * tabla de multiplicar de PI
*  * del 20 al 10 multimplicado del 5 a 8, utilizando un FOR.
******************************************************************/
namespace Ejercicios
{
    class H
    {
        static void Main(string[] args)
        {
            // Números del 1 al 100
            int c = 0;
            while (c < 100)
            {
                c++;
                Console.WriteLine(c);
            }

            Console.WriteLine("--------------------");

            // Números impares del 51 al 91
            c = 51;
            while (c <= 91)
            {
                if (c % 2 != 0) Console.WriteLine(c);
                c++;
            }

            Console.WriteLine("--------------------");

            // Tabla de multiplicar de PI
            c = 0;
            while (c <= 10)
            {
                Console.WriteLine($"{(Math.PI).ToString("#.##")} x {c} = {(Math.PI * c).ToString("0.##")}");
                c++;
            }

            Console.WriteLine("--------------------");

            // Del 20 al 10 multiplicado del 5 a 8, utilizando un while
            int c1 = 20, c2 = 5;
            while (c1 >= 10)
            {
                while (c2 <= 8)
                {
                    Console.WriteLine($"{c1} x {c2} = {c1 * c2}");
                    c2++;
                }
                c1--;
                c2 = 5;
                Console.WriteLine("");
            }


        }
    }
}
