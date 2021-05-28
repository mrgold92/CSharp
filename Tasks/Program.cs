using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        delegate void Demo1();


        static void Main(string[] args)
        {
            Console.WriteLine("Inicio de la app");
            CreacionTareas();
            Console.WriteLine("Fin de la app");

            Console.ReadKey();
        }


        static async void CreacionTareas()
        {
            //un delegado es un tipo de dato que contiene código
            //Action es un tipo de delegado que existe en .NET que nos sirve para especificar el código de un método

            Demo1 demo = Saludo;

            //Demo1 demo = Saludo2; //error porque saludo2 tiene parámetro

            //con action
            Task tarea1 = new Task(new Action(Saludo));

            //con función lambda
            Task<bool> tarea2 = new Task<bool>(() =>
            {
                Console.WriteLine("Tarea 2 ejecutándose");
                Thread.Sleep(5000);
                return true;
            });

            //con delegate
            Task tarea3 = new Task(delegate
            {
                Console.WriteLine("Tarea 3 ejecutándose");
            });


            Task tarea4 = new Task(new Action(demo));

            Task tarea5 = Task.Run(() =>
            {
                Console.WriteLine("Tarea 5 ejecutándose");
                Thread.Sleep(5000);
                Console.WriteLine("Tarea 5 fin");
            });

            tarea5.Wait(1000); //Esperamos a que finalice la 5

            tarea1.Start();

            tarea2.Start();
            //tarea2.Wait(1000); //Esperamos a que finalice la 2

            // Con el result esperamos automáticamente a que finalice para pintar el resultado.
            // El result también bloquea el hilo principal, para arreglarlo,
            // tenemos que hacer que los métodos sean asíncronos.
            //Console.WriteLine($"Resultado tarea 2: {tarea2.Result}");
            Console.WriteLine($"Resultado tarea 2: {await tarea2}");

            tarea3.Start();
            tarea4.Start();

        }
        static void Procesos()
        {
            Saludo();
            Console.WriteLine("Tarea 2 ejecutándose");
            Console.WriteLine("Tarea 3 ejecutándose");
            Saludo();
            Console.WriteLine("Tarea 5 ejecutándose");

        }
        static void Saludo()
        {
            Console.WriteLine("Hola mundo !!!");
        }
        static void Saludo2(string nombre)
        {
            Console.WriteLine($"Hola {nombre} !!!");
        }
        static void Saludo3()
        {
            Console.WriteLine("Hola a todos !!!");
        }
    }


}
