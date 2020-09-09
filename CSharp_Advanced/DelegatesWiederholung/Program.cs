using System;
using System.Collections.Generic;

namespace DelegatesWiederholung
{
    class Program
    {


        public delegate void MeinDelegate(); //Signatur Methode wird verwenden mit void + ohne Methodenparameter

        public delegate void ZweitesDelegate(IList<int> resultList);

        static void Main(string[] args)
        {
            MeinDelegate meinDelegate1 = new MeinDelegate(Logger);
            meinDelegate1();//Hier Rufe ich die Methode Logger() auf!

            ZweitesDelegate zweitesDelegate = new ZweitesDelegate(Logger);

            MethodeMitCallback(32, 250, zweitesDelegate);
        }


        public static void Logger()
        {
            Console.WriteLine($"[{DateTime.Now}]: Schreibe eine Log-Eintrag");
        }

        public static void Logger(IList<int> primzahlen)
        {
            foreach (int currentNumber in primzahlen)
            {
                Console.WriteLine($"Primzahl: {currentNumber}");
            }
        }

        private static bool istPrimzahl(int testZahl)
        {
            int teiler = testZahl / 2;
            while (testZahl % teiler != 0)
            {
                teiler--;
            }
            if (teiler == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void MethodeMitCallback (int zahl1, int zahl2, ZweitesDelegate callback)
        {
            //Berechnung mit ganz viel Rechenaufwand
            IList<int> primzahlen = new List<int>();
            for (int i = zahl1; i < zahl2; i++)
            {
                if (istPrimzahl(i))
                {
                    primzahlen.Add(i);
                }
            }


            callback(primzahlen);
        }
    }
}
