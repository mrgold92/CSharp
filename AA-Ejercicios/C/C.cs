using System;
/****************************************************************
* C1. Muestra el número de elementos de lista.
* C2. Muestra el primer y el último elemento de lista.
* **************************************************************/
namespace Ejercicios
{
    class C
    {
        static void Main(string[] args)
        {
            //C1
            string[] lista =  {"T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X",
                               "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };


            Console.WriteLine($"Nº Elementos de la lista: {lista.Length}");

            //C2
            Console.WriteLine($"Primer elemento de la lista: {lista[0]}");
            Console.WriteLine($"Último elemento de la lista: {lista[lista.Length-1]}");
        }
    }
}
