using Curzi.Lorenzo._4H.JSONContagi.Models;
using System;
using System.IO;

namespace Curzi.Lorenzo._4H.JSONContagi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problema Scelto: 6
            //Analizzando il file JSON, stampare le date corrispondenti al giorno del massimo numero di
            //contagi ed al giorno del minimo di contagi(escluso il primo giorno).

            Console.WriteLine("Programma JSONContagi di Lorenzo Curzi 4H, 24/02/2021");

            Statistica statistiche = new Statistica("ContagiRimini.json");

            //Console.WriteLine(statistiche);

            Console.WriteLine("\nRicerca del giorno con più contagi...");
            Console.WriteLine(statistiche.MassimoContagi());

            Console.WriteLine("\nRicerca del giorno con meno contagi...");
            Console.WriteLine("(Escluso il primo)");
            Console.WriteLine(statistiche.MinimoContagi());

            Console.WriteLine("\n" + statistiche.CalcolaContagiGiorbalieri(DayOfWeek.Monday));
            Console.WriteLine(statistiche.CalcolaContagiGiorbalieri(DayOfWeek.Tuesday));
            Console.WriteLine(statistiche.CalcolaContagiGiorbalieri(DayOfWeek.Wednesday));
            Console.WriteLine(statistiche.CalcolaContagiGiorbalieri(DayOfWeek.Thursday));
            Console.WriteLine(statistiche.CalcolaContagiGiorbalieri(DayOfWeek.Friday));
            Console.WriteLine(statistiche.CalcolaContagiGiorbalieri(DayOfWeek.Saturday));
            Console.WriteLine(statistiche.CalcolaContagiGiorbalieri(DayOfWeek.Sunday));
        }
    }
}
