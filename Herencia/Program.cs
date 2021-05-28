using System;
using System.Collections.Generic;
using System.Linq;

namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {

            //DEMOB hereda de DEMOA
            var demo = new DemoB();

            demo.Nombre = "David";
            demo.Apellidos = "Salazar";
            demo.Edad = 28;

            demo.PintarDatos(); //hereda de A <-- Está sobreescrito en B
            demo.PintarDatos2(); //método propio de B
            demo.PintarDatos3(); //método propio de B que llama a pintardatos de A (padre)

            Console.WriteLine("------------------------");

            //Interfaces
            IElectrodomestico electrodomestico;
            IDispositivosDomotica domotica;

            Lavadora lavadora1 = new Lavadora() { Nombre = "Lavadora 1", Revoluciones = 750, Color = "Blanco" };
            IElectrodomestico lavadora2 = new Lavadora() { Nombre = "Lavadora 2", Revoluciones = 1000, Color = "Gris" };
            Nevera nevera1 = new Nevera() { Nombre = "Nevera 1", ConsumoWatios = 250, Color = "Verde" };


            Console.WriteLine(lavadora1.GetType().ToString());
            lavadora1.Encender();
            lavadora1.Apagar();
            lavadora1.PintarFicha();

            Console.WriteLine();

            Console.WriteLine(lavadora2.GetType().ToString());
            lavadora2.Encender();
            lavadora2.Apagar();
            //lavadora2.PintarFicha(); // error
            ((Lavadora)lavadora2).PintarFicha();

            Console.WriteLine("-------------------");

            nevera1.Encender();
            nevera1.Apagar();

            domotica = nevera1;
            domotica.Encender();
            domotica.Apagar();

            electrodomestico = nevera1;

            electrodomestico.Encender();
            electrodomestico.Apagar();



        }
    }


    class DemoA
    {

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public int Edad { get; set; }

        public virtual void PintarDatos()
        {
            Console.WriteLine($"{Nombre} {Apellidos}");
        }

    }

    //Con sealed sellamos la clase, es decir, impedimos que nadie puede heredar
    class DemoB : DemoA
    {
        //También podemos sellar métodos, para que no podamos sobreescribirlo en otro lado
        sealed public override void PintarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Apellidos: {Apellidos}");
        }

        public void PintarDatos2()
        {
            Console.WriteLine($"{Nombre} {Apellidos} {Edad}");
        }

        public void PintarDatos3()
        {
            base.PintarDatos(); //llamada a padre
            Console.WriteLine($"{Edad}");
        }


    }

    //Demob está sellada y no podemos heredarla.
    //class DemoC : DemoB { }

    class DemoC
    {
        //IQueryable = consultable, solo trae los datos cuando se quiere acceder a la información
        //ej: al recorrer una lista que previamente hemos cargado con una consulta linq

    }

    //INTERFACES
    interface IElectrodomestico
    {
        int ConsumoWatios { get; set; }
        string Nombre { get; set; }
        string Color { get; set; }

        void Encender();
        void Apagar();
    }

    interface IDispositivosDomotica
    {
        public void Apagar();

        public void Encender();
    }

    class Nevera : IElectrodomestico, IDispositivosDomotica
    {
        public int ConsumoWatios { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Puertas { get; set; }
        public int TempMin { get; set; }

        public void Encender()
        {
            Console.WriteLine("Nevera On");
        }

        public void Apagar()
        {
            Console.WriteLine("Nevera Off");
        }

        void IDispositivosDomotica.Encender()
        {
            Console.WriteLine("Domótica Nevera On");
        }

        void IDispositivosDomotica.Apagar()
        {
            Console.WriteLine("Domótica Nevera Off");
        }

        void IElectrodomestico.Encender()
        {
            Console.WriteLine("Electro Nevera On");
        }

        void IElectrodomestico.Apagar()
        {
            Console.WriteLine("Electro Nevera Off");
        }

        public void TurboCool()
        {
            Console.WriteLine("Turbo On");
        }
    }

    class Lavadora : IElectrodomestico
    {
        public int ConsumoWatios { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Revoluciones { get; set; }


        public void Apagar()
        {
            Console.WriteLine("Nevera Off");
        }

        public void Encender()
        {
            Console.WriteLine("Nevera On");
        }

        public void PintarFicha()
        {
            Console.WriteLine($"Lavadora de color {Color}, con un máximo de {Revoluciones} revoluciones.");
        }
    }
}
