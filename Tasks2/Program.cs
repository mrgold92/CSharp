using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIO DE LA APP");

            MainAsync();
            MainParallel();

            Console.WriteLine("FIN DE LA APP");
            Console.ReadKey();
        }

        static async void MainAsync()
        {
            var pruebas = new PruebaTask();


            //Usar método síncrono
            pruebas.Calculos();

            for (int i = 0; i < pruebas.array.LongLength; i++)
            {
                Console.WriteLine($"Raíz cuadrada de {i} = {pruebas.array[i]}");
            }

            //Usar método asíncrono
            bool resultado = await pruebas.CalculosAsync();

            for (int i = 0; i < pruebas.array.LongLength; i++)
            {
                Console.WriteLine($"Raíz cuadrada de {i} = {pruebas.array[i]}");
            }

            ////Usar método que retorna una tarea y no utilizamos el await
            Task tarea = pruebas.CalculosAsync2();
            tarea.Start();
            tarea.Wait();

            for (int i = 0; i < pruebas.array.LongLength; i++)
            {
                Console.WriteLine($"Raíz cuadrada de {i} = {pruebas.array[i]}");
            }

            //Usar método asíncrono sin await y con evento
            pruebas.FinCalculos += ((s, e) =>
            {

                for (int i = 0; i < pruebas.array.LongLength; i++)
                {
                    Console.WriteLine($"Raíz cuadrada de {i} = {pruebas.array[i]}");
                }
            });

            pruebas.CalculosAsync3();


        }

        static void MainParallel()
        {
            //Le ejecución en paralelo tiene coste en la CPU


            double[] array = new double[900000000];


            List<string> frutas = new List<string>()
            {
                "manzana",
                "pera",
                "fresa",
                "melón",
                "plátano"
            };

            //Parallel.Invoke ejecuta bloques de código en paralelo
            Parallel.Invoke(
                () => { Console.WriteLine("Ejecución en paralelo 1"); },
                () => { Console.WriteLine("Ejecución en paralelo 2"); },
                () => { Console.WriteLine("Ejecución en paralelo 3"); });


            // Recorrer un array normal
            foreach (var item in frutas)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // Recorrer un array en paralelo
            // Lo ejecuta todo a la vez, por lo que no están todos en orden
            Parallel.ForEach(frutas, item =>
            {
                Console.WriteLine(item);
            });

            Console.WriteLine();


            //LINQ
            var frutas2 = from c in frutas
                          where c[0] == 'm'
                          select c;

            var frutas3 = from c in frutas.AsParallel()
                          where c[0] == 'm'
                          select c;

            foreach (var item in frutas2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in frutas3)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            DateTime a1 = DateTime.Now;

            for (int i = 0; i < 900000000; i++) array[i] = Math.Sqrt(i);

            DateTime a2 = DateTime.Now;

            //se ejecuta en paralelo por cada uno de los elementos
            Parallel.For(0, 900000000, i =>
            {
                array[i] = Math.Sqrt(i);
                //Console.WriteLine($"Raíz cuadrada de {i} = {array[i]}");
            });

            DateTime a3 = DateTime.Now;

            Console.WriteLine("FOR -> {0}", a2.Subtract(a1).Milliseconds.ToString());
            Console.WriteLine("PARARELL FOR -> {0}", a3.Subtract(a2).Milliseconds.ToString());

        }
    }


    class PruebaTask
    {
        //Ejemplo de ejecución síncrona
        public double[] array = new double[50000000];
        public event EventHandler<bool> FinCalculos;
        public bool Calculos()
        {
            for (int i = 0; i < 50000000; i++)
            {
                array[i] = Math.Sqrt(i);
            }

            return true;
        }

        //Ejemplo de ejecución asíncrono
        public async Task<bool> CalculosAsync()
        {
            return await Task<bool>.Run(() =>
            {
                for (int i = 0; i < 50000000; i++)
                {
                    array[i] = Math.Sqrt(i);
                }

                return true;
            });
        }

        //Ejemplo que retorna una tarea sin iniciar
        public Task<bool> CalculosAsync2()
        {
            return new Task<bool>(() =>
            {

                for (int i = 0; i < 50000000; i++)
                {
                    array[i] = Math.Sqrt(i);
                }

                return true;
            });
        }

        //El final del metodo se controla mediante un evento.
        public Task<bool> CalculosAsync3()
        {
            return Task<bool>.Run(() =>
         {

             for (int i = 0; i < 50000000; i++)
             {
                 array[i] = Math.Sqrt(i);
             }

             //una vez que rellenamos el array, llamamos al evento y devolvemos true en este caso
             FinCalculos?.Invoke(this, true);

             return true;
         });
        }
    }
}

