using System;
/****************************************************************
 * B1.Pregunta un número al operador y muestra el resultado de 
 * multiplicarlo por PI. Utiliza la constante "math.pi" y 
 * recuerda incluir "import math".
 * 
 * B2. Muestra la raíz cuadrada del mismo número.
 * B3. Muestra el arco coseno del mismo número.
 * **************************************************************/

namespace Ejercicios
{
    class B
    {
        static void Main(string[] args)
        {
            //B1
            Console.Write("Dime un número: ");
            int.TryParse(Console.ReadLine(), out int numero);
            Console.WriteLine($"{numero} * PI = {(numero * Math.PI).ToString("#.##")}");

            //B2
            Console.WriteLine($"Raíz cuadrada de {numero}: {Math.Sqrt(numero)}");

            //B3
            if (numero >= -1 && numero <= 1)
            {
                Console.WriteLine($"Arco coseno de {numero}: {Math.Acos(numero)}");
            }
        }
    }
}
