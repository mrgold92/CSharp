/*************************************************
* A1. Pregunta el nombre de Operador
* y muestra un saludo incluyendo el contenido
* de la variable cadena.
* 
* A2. Muestra el saludo en mayúsculas, minúsculas
* y con la letra de cada palabra en mayúsculas.
**************************************************/

using System;

namespace Ejercicios
{
    class A
    {
        static void Main(string[] args)
        {

            string cadena = "Hola mundo !!";
            Console.Write("Dime tu nombre: ");
            string nombre = Console.ReadLine();
            string saludo = $"{cadena}, ¿Qué tal {nombre}?";

            //A1
            Console.WriteLine(saludo);

            //A2
            Console.WriteLine(saludo.ToLower());
            Console.WriteLine(saludo.ToUpper());
            Console.WriteLine(ToTitle(saludo));

        }
        /// <summary>
        /// Capitaliza cada palabra de una frase
        /// </summary>
        /// <param name="frase"></param>
        /// <returns></returns>
        static string ToTitle(string frase)
        {
            string fraseTitle = "";
            string[] fraseSeparada = frase.Split(" ");

            for (int i = 0; i < fraseSeparada.Length; i++)
            {
                fraseTitle += fraseSeparada[i].Substring(0, 1).ToUpper() + fraseSeparada[i].Substring(1);
                if (fraseSeparada.Length - 1 != i) fraseTitle += " ";
            }

            return fraseTitle;
        }
    }
}
