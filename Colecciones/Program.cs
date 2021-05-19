using System;
using System.Collections;
using System.Collections.Generic;

namespace Colecciones
{
    class Program
    {
        static void Main(string[] args)
        {
            /********************************
             * Colecciones
             ********************************/

            //Arraylist
            ArrayList();

            Console.WriteLine("***********************");

            //Hashtable
            HashTable();

            Console.WriteLine("***********************");

            //Lista
            Lista();

            Console.WriteLine("***********************");

            //Diccionario
            Diccionario();


            //Queue y stack
            Queue cola = new Queue();
            Stack stack = new Stack();

            cola.Enqueue("añadir"); //añade elemento al final de la lista
            cola.Dequeue(); //Elimina y devuelve el elemento al principio de la lista
            cola.Peek(); //Devuelve el elemeto del principio de la lista sin borrarlo

            stack.Push("añadir"); //Inserta el elemento al stack
            stack.Pop(); //Elimina y devuelve el elemento al principio de la lista

        }

        static void ArrayList()
        {
            ArrayList array = new ArrayList();

            /***************************************
             * Limpiar el contenido de la colección
             ***************************************/

            array.Clear();


            /***************************************
            * Añadir elementos a la colección
            ***************************************/

            array.Add("azul");
            array.Add("rojo");
            array.Add("amarillo");
            array.Add("verde");

            //Otra forma de añadir elementos a la colección
            array.AddRange(new string[] { "marrón", "naranja", "violeta" });

            string[] colores = new string[] { "blanco", "negro" };
            array.AddRange(colores);

            /***************************************
             * Contar elementos de la colección
             **************************************/

            Console.WriteLine($"Número de elementos: {array.Count}");
            Console.WriteLine("---------------");

            /***************************************
            * Recorrer la colección
            ***************************************/

            //Con for
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine($"For: {array[i]}");
            }

            Console.WriteLine("---------------");

            //Con foreach

            //ponemos var porque no todos los elementos
            //podrían ser del mismo tipo
            foreach (var item in array)
            {
                Console.WriteLine($"Foreach: {item}");
            }

            /***************************************
            * Eliminar elementos de la colección
            ***************************************/

            array.Remove("verde");
            array.RemoveAt(4);
            array.RemoveRange(2, 2); //de la posición 2, 2 elementos (pos 2 y pos 3)

            Console.WriteLine("---------------");

            Console.WriteLine($"Número de elementos: {array.Count}");
        }

        static void HashTable()
        {
            Hashtable dicc = new Hashtable();

            /***************************************
             * Limpiar el contenido del diccionario
             ***************************************/
            dicc.Clear();

            /***************************************
            * Añadir elementos al diccionario
            ***************************************/
            dicc.Add("ANATR", "Ana Trujillo");
            dicc.Add("ANTON", "Antonio Sanz");
            dicc.Add("CARSA", "Carlos Sánchez");

            /***************************************
             * Recorrer el diccionario
             ***************************************/
            foreach (var clave in dicc.Keys)
            {
                Console.WriteLine($"{clave} -> {dicc[clave]}");
            }

            Console.WriteLine("----------------------------");

            /***************************************
             * Número de elementos
             ***************************************/
            Console.WriteLine($"Número de elementos: {dicc.Count}");

            /***************************************
            * Eliminar elementos del diccionario
            ***************************************/
            dicc.Remove("ANTON");

            Console.WriteLine("----------------------------");

            Console.WriteLine($"Número de elementos: {dicc.Count}");

            Console.WriteLine("----------------------------");

            //Volvemos a recorrer el diccionario para ver que se ha borrado
            foreach (var clave in dicc.Keys)
            {
                Console.WriteLine($"{clave} -> {dicc[clave]}");
            }
        }

        static void Lista()
        {
            //Esta colección sí está tipada, a diferencia del ArrayList y el Hashtable
            //Puede contener objetos, int, string, char,etc.

            List<string> lista = new List<string>();

            /***************************************
            * Limpiar el contenido de la lista
            ***************************************/
            lista.Clear();

            /***************************************
            * Añadir elementos a la lista
            ***************************************/
            lista.Add("azul");
            lista.Add("verde");
            lista.Add("rojo");
            lista.AddRange(new string[] { "rosa", "blanco", "amarillo" });

            /***************************************
            * Recorrer el diccionario
            ***************************************/
            foreach (string c in lista)
            {
                Console.WriteLine($"Elemento lista: {c}");
            }

            Console.WriteLine("-----------------------------");

            /***************************************
             * Número de elementos
             ***************************************/
            Console.WriteLine($"Nº de elementos de la lista: {lista.Count}");

            Console.WriteLine("-----------------------------");

            /***************************************
             * Eliminar elementos
             ***************************************/
            lista.Remove("azul");
            lista.RemoveAt(2);

            //Recorremos todos los elementos para ver si se han eliminado
            foreach (string c in lista)
            {
                Console.WriteLine($"Elemento lista: {c}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Nº de elementos de la lista: {lista.Count}");
        }

        static void Diccionario()
        {
            Dictionary<int, string> dicc = new Dictionary<int, string>();

            /***************************************
            * Limpiar el contenido del diccionario
            ***************************************/
            dicc.Clear();

            /***************************************
            * Añadir elementos a la lista
            ***************************************/
            dicc.Add(1, "azul");
            dicc.Add(2, "verde");
            dicc.Add(3, "rojo");


            /***************************************
            * Recorrer el diccionario
            ***************************************/
            foreach (int c in dicc.Keys)
            {
                Console.WriteLine($"Elemento del diccionario: clave: {c} -> {dicc[c]}");
            }

            Console.WriteLine("-----------------------------");

            /***************************************
             * Número de elementos
             ***************************************/
            Console.WriteLine($"Nº de elementos de la lista: {dicc.Count}");

            Console.WriteLine("-----------------------------");

            /***************************************
             * Eliminar elementos
             ***************************************/
            dicc.Remove(1);

            //Recorremos todos los elementos para ver si se han eliminado
            foreach (int c in dicc.Keys)
            {
                Console.WriteLine($"Elemento del diccionario: clave: {c} -> {dicc[c]}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Nº de elementos de la lista: {dicc.Count}");
        }
    }
}
