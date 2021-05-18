using System;
/*******************************************************************
* G1. Pregunta al operador cualquier cosa.
* G2. Muestra por Simón dice xxxxxxxxx incluyendo la respuesta
* del operador
* G3. Esta secuencia de pregunta/mostrar en pantalla se repite hasta
* que el operado responde fin
********************************************************************/
namespace Ejercicios
{
    class G
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("¿De qué color es el caballo blanco de Santiago? ");
                string res = Console.ReadLine();
                
                if (res.ToLower().Trim() == "fin") break;

                Console.WriteLine($"Simón dice {res}.");
            }


        }
    }
}
