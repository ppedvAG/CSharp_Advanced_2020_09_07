using System;
using System.Diagnostics;
using System.Text;

namespace StringBuilderBenachmarkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string aufbauenString = string.Empty;

            Stopwatch stopUhr = new Stopwatch();

            stopUhr.Start();
            for (int i = 0; i < 10000; i++)
            {
                
                aufbauenString += i.ToString();
            }
            stopUhr.Stop();

            long test1 = stopUhr.ElapsedMilliseconds;
            
            Console.WriteLine("Taste drücken.....");
            Console.ReadKey();


            StringBuilder sb = new StringBuilder();

            Stopwatch stopUhr2 = new Stopwatch();
            stopUhr2.Start();

            for (int i = 0; i < 10000; i++)
            {
                sb.Append(i);
            }
            
            //Auslesen von StringBuilder -> sb.ToString();

            stopUhr2.Stop();

            long test2 = stopUhr2.ElapsedMilliseconds;


            Console.WriteLine("Benchmark Ergebnis");
            Console.WriteLine($"einfaches addieren von Strings - Zeit: {test1}");
            Console.WriteLine($"Arbeiten mit StringBuilder - Zeit: {test2}");

            Console.ReadLine();
        }
    }
}
