using System;

namespace DelegateAndCallback
{
    class Program
    {
        public delegate void Del(string message);

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            //Mach was mit param1 und param2
            //30 Minuten später 


            callback("The number is: " + (param1 + param2).ToString());
        }

        static void Main(string[] args)
        {
            // Aufruf eines normaln Delagates -> Methode
            Del handler = DelegateMethod;
            handler("Hello World");


            // Rufe eine Methode auf und übergebe ein Delegate für den Callback
            MethodWithCallback(1, 2, handler);

            Console.WriteLine("Hello World!");
        }
    }
}
