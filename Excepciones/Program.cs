using System;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* No se puede dividir por cero.
                 * 
                 * Así que lo metemos en un try-catch
                 * para controlar la excepción.
                 */
                int num = 10;
                int num2 = 0;

                //También podemos provocar nuestros propios errores.

                if (num2 == 0)
                {
                    //Lanzar una excepción específica
                    throw new DivideByZeroException("Wrong! No se puede dividir por cero.");
                    //Lanzar una excepción genérica
                    throw new Exception("El valor es 0 y no se puede dividir entre cero.");
                }
                else
                {
                    int res = num / num2;

                    Console.WriteLine($"El resultado es: {res}");
                }
            }
            catch (DivideByZeroException e)
            {
                //Error específico
                Console.WriteLine("No se puede dividir por cero.");
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                //Error genérico (siempre irá al final el genérico.)
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                //Este bloque se ejecuta siempre,
                //haya o no error.
                Console.WriteLine("Bloque finally, siempre se ejecuta.");
            }
        }
    }
}
