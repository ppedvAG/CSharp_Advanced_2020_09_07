using System;
using System.Threading;

namespace MutexSample
{
    class Program
    {

        static Mutex _mutex;


        static void Main(string[] args)
        {
            if (!Program.IsSingleInstance())
            {
                Console.WriteLine("More than one instance");
            }
            else
            {
                Console.WriteLine("One Instance"); // Im Programm geht es weiter
            }

            Console.ReadLine();
        }

        static bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting("NOTEPAD");

            }
            catch (Exception ex)
            {
                Program._mutex = new Mutex(true, "NOTEPAD");
                return true;
            }
            return false;
        }
    }
}
