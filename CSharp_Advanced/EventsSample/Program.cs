using System;

namespace EventsSample
{
    public delegate void MyEventHandler();

    class Program
    {
        public static event MyEventHandler _show;


        static void Main(string[] args)
        {
            //Beispiel1: Hunde, Katze Maus
            _show += new MyEventHandler(Dog);
            _show += new MyEventHandler(Cat);
            _show.Invoke();
            _show += new MyEventHandler(Mouse);
            _show += new MyEventHandler(Mouse);

            _show.Invoke();

            //Beispiel 2: Like a WinForm - Button
            Button b1 = new Button();

            b1.KlickEvent += MeineKlickLogik;
            b1.KlickEvent += Logger;
            b1.Klick();
            //b1.KlickEvent = null;       // absolut verboten
            b1.KlickEvent -= Logger;
            b1.Klick();

            Console.ReadLine();
        }

        private static void MeineKlickLogik()
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        private static void Logger()
        {
            Console.WriteLine($"[{DateTime.Now}]: Button wurde geklickt");
        }

        static void Cat()
        {
            Console.WriteLine("Cat");
        }

        static void Dog()
        {
            Console.WriteLine("Dog");
        }

        static void Mouse()
        {
            Console.WriteLine("Mouse");
        }
    }




    class Button
    {
        public event Action KlickEvent;// "AutoProperty"
        public void Klick()
        {
            // Logik
            if (KlickEvent != null)
                KlickEvent();
        }
    }
}