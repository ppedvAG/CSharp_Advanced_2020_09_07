using System;
using System.Collections.Generic;
using System.Text;

namespace Thread_Demo
{
    public class Konto
    {
        public decimal Kontostand { get; set; }

        private object lockObject = new object(); //Irgendeine Instanz, NICHT VERÄNDERN!

        public void Einzahlen(decimal betrag)
        {
            lock (lockObject) // Nur ein Thread kann diesen Part verwenden. Die Anderen Thread müssen warten. 
            {
                //Console.WriteLine($"Kontostand vor dem Einzahlen: {Kontostand}");
                Kontostand += betrag;
                //Console.WriteLine($"Kontostand nach dem Einzahlen: {Kontostand}");
            }
        }

        public void Abheben(decimal betrag)
        {
            lock (lockObject) // Nur ein Thread kann diesen Part verwenden. Die Anderen Thread müssen warten. 
            {
                //Console.WriteLine($"Kontostand vor dem Abheben: {Kontostand}");
                Kontostand -= betrag;
                //Console.WriteLine($"Kontostand nach dem Abheben: {Kontostand}");
            }
        }
    }
}
