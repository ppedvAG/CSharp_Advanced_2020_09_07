using ErweitungsmethodenLib;
using System;

namespace ErweiterungsmethodenSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl1 = 12;

            int result1 = IntegerErweiterungsMethoden.Verdoppeln(13);
            int result2 = zahl1.Verdoppeln();

            Console.WriteLine($"IntegerErweiterungsMethoden.Verdoppeln(13) = {result1}");


            Console.WriteLine("Hello World!");
        }
    }

    
}
