using System;

/****************************************************************
* Muestra las siguientes secuencias de número utilizando un FOR:
* del 1 al 100
* del 200 al 190
* del 10 a 10000 de 100 en 100
* los números impares del 51 al 91
* los multiplos de 5 del 40 al 30
* tabla de multiplicar de PI
* del 10 al 20 sumado con el anterior
* del 20 al 10 multimplicado del 5 a 8, utilizando dos FOR
***************************************************************/

namespace Ejercicios
{
    class F
    {
        static void Main(string[] args)
        {
            // Del 1 al 100
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("------------------------");

            // Del 200 al 190
            for (int i = 200; i >= 190; i--)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("------------------------");

            //Del 100 al 10000 de 100 en 100
            for (int i = 100; i <= 10000; i += 100)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("------------------------");

            // Los números impares del 51 al 91
            for (int i = 51; i <= 91; i++)
            {
                if (i % 2 != 0) Console.WriteLine(i);
            }

            Console.WriteLine("------------------------");

            // Los múltiplos de 5, del 40 al 30
            for (int i = 40; i >= 30; i--)
            {
                if (i % 2 == 0) Console.WriteLine(i);
            }

            Console.WriteLine("------------------------");

            // La tabla de multiplicar de PI
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{(Math.PI).ToString("#.##")} x {i} = {(Math.PI * i).ToString("0.##")}");
            }

            Console.WriteLine("------------------------");

            // Del 10 al 20 sumado con el anterior
            for (int i = 10; i <= 20; i++)
            {
                if (i == 10) Console.WriteLine(10);
                else Console.WriteLine(i + (i - 1));
            }

            Console.WriteLine("------------------------");

            // Del 20 al 10 multiplicado del 5 a 8, utilizando dos FOR
            for (int i = 20; i >= 10; i--)
            {
                for (int j = 5; j <= 8; j++)
                {
                    Console.WriteLine($"{i} x {j} = {i * j}");
                }
                Console.WriteLine("");
            }
        }
    }
}
