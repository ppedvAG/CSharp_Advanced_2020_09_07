using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp8_Features
{
    class Program
    {
        static async Task Main(string[] args)
        {

            #region yield + IAsyncEnumerable
            Console.WriteLine("Start Programm");
            await foreach (var zahl in GeneriereZahlen())
            {
                Console.WriteLine(zahl);
            }

            Console.WriteLine("Hello World!");
            #endregion

            #region Array Access Varianten
            string[] words = new string[]
            {
                "Frantz",
                "jagt",
                "im",
                "komplett",
                "verwahrlosten",
                "Taxi",
                "quer",
                "durch",
                "Bayern"
            };

            Console.WriteLine($"Das letzte Wort ist {words[^1]}");


            var imKomplettVerwahrlostenTaxi = words[2..6]; //exkl wörter[6]
            var durchBayern = words[^2..^0]; //exkl wörter [^0]
            var alles = words[..];
            var ersterTeil = words[..4]; //Frantz jagt im komplett
            var letzterTeil = words[6..]; //quer durch Bayern

            Range phrase = 1..4;
            var text = words[phrase]; // jagt im komplett 

            #endregion


            #region Verbitim-String in Kombination
            string path = "C:\\Programme\\ABC";
            string path2 = @"C:\Programme\ABC";

            string einfacherString = "hallo ich schreibe hier was \n das kennst von printf \t \t das steht weiter weg....";

            #endregion

#nullable enable


            string darfNichtNullSein = null;

            string? darfNullSein = null;

            Console.WriteLine(darfNichtNullSein[0]);
            Console.WriteLine(darfNullSein[0]);

            darfNichtNullSein = "Demo";
            Console.WriteLine(darfNichtNullSein);

            if (darfNichtNullSein != null)
                Console.WriteLine(darfNullSein);
#nullable disable            
            
            Console.ReadLine();




        }


        #region yield + IAsyncEnumerable
        public static async IAsyncEnumerable<int> GeneriereZahlen()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100 * i);
                yield return i;
            }
        }
        #endregion
    }
}
