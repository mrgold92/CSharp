using System;
/********************************************
* Pregunta un número al operador y muestra el mensaje los siguientes mensajes:
*   - Correcto si el valor coincide con el contenido en la variable numero
*   - Bajo si el valor es inferior al contenido en la variable numero
*   - Alto si el valor es superior al contenido en la variable numero
*   - Añade la palabra Demasiado si la diferencia entre el valor y
*     contenido de la variable numero es de 25 o más.
********************************************/
namespace Ejercicios
{
    class E
    {

        static void Main(string[] args)
        {
            int numero = 100;
            Console.Write("Dime un número: ");
            bool esNumero = int.TryParse(Console.ReadLine(), out int n);

            if (esNumero)
            {
                string mensaje;

                if (n == numero)
                {
                    mensaje = "Correcto.";
                }
                else if (n < numero)
                {
                    mensaje = "Bajo.";
                }
                else if ((n - numero) >= 25)
                {
                    mensaje = "Demasiado.";
                }
                else
                {
                    mensaje = "Alto.";
                }

                Console.WriteLine(mensaje);
            }
            else
            {
                Console.WriteLine("Inserta un número.");
            }
        }
    }
}
