using System;
using System.Collections.Generic;

/**********************************************************************
* I1. Pregunta al operador 5 colores
* I2. Muestra los colores ordenados
* I3. Muestra el color que más letras contenga
* I4. Muestra el color que más vocales contenga
* I5. Muestra la cantidad de colores que comienza y finaliza por vocal.
* *********************************************************************/

namespace Ejercicios
{
    class I
    {
        static void Main(string[] args)
        {
            string[] colores = new string[5];

            // I1
            for (int i = 0; i < colores.Length; i++)
            {
                Console.Write("Dime un color: ");
                colores[i] = Console.ReadLine();
            }

            Console.WriteLine("--------------");

            // I2
            Array.Sort(colores);
            foreach (string color in colores)
            {
                Console.WriteLine(color);
            }

            Console.WriteLine("--------------");

            // I3
            string colorMayor = "";

            foreach (string c in colores)
            {
                if (c.Length > colorMayor.Length) colorMayor = c;
            }

            Console.WriteLine($"Color con más letras: {colorMayor}");

            Console.WriteLine("--------------");

            // I4
            char[] vocales = { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'ü' };
            string coloreElegido = "";
            int suma = 0, sumaAux = 0;
            foreach (string color in colores)
            {
                foreach (char v in vocales)
                {
                    if (color.ToLower().Contains(v)) suma++;
                }

                if (suma >= sumaAux) coloreElegido = color;

                sumaAux = suma;
                suma = 0;

            }

            Console.WriteLine($"Color con más vocales: {coloreElegido}");

            Console.WriteLine("--------------");


            //I5
            int s = 0;
            foreach (string color in colores)
            {
                foreach (char v in vocales)
                {
                    if (color.ToLower().StartsWith(v) || color.ToLower().EndsWith(v))
                    {
                        s++;
                        break;
                    }
                }
            }

            Console.WriteLine($"Número de colores que empiezan o acaban por vocal: {s}");
        }
    }
}
