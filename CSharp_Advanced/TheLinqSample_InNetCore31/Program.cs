using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLinqSample_InNetCore31
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringListe = new List<string>();

            stringListe.First(); // Funktioniert nur, wenn System.Linq als using angegeben wird
        }
    }
}
