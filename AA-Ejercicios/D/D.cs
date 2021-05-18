using System;
/*******************************************************************
* D1. Pregunta al operador su DNI sin letra.
* D2. Calcula el resto de dividir el número del DNI entre 23.
* D3. Muestra el DNI con la letra. El resto de la división
* representa la posición de la letra del DNI en lista.
*------------------------------------------------------------------*/
namespace D
{
    class D
    {
        static void Main(string[] args)
        {
            string[] lista = {"T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X",
                              "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };

            //D1
            Console.Write("Dime tu DNI sin letra: ");
            int.TryParse(Console.ReadLine(), out int dni);

            //D2 y D3
            string dniResult = (dni.ToString().Length == 8)
                ? $"Tu DNI es: {dni}{lista[dni % 23]}."
                : "Error: Inserta un número de 8 dígitos.";
            Console.WriteLine(dniResult);

        }
    }
}
