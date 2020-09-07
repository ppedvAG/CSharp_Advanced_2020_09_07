using System;

namespace DelegatesUndEreignisse
{
    class Program
    {
        delegate int NumbChanger(int n);


        static int num = 10;
        static void Main(string[] args)
        {
            #region Delegates vor .NET 2.0
            NumbChanger nc1 = new NumbChanger(AddNum);
            nc1(12);
            
            nc1 += MultNum;
            nc1(25);
            nc1 -= AddNum;
            nc1(12);

            NumbChanger nc2 = new NumbChanger(MultNum);
            nc2(11); // ruft nur MultNum

            NumbChanger numberChanger1 = new NumbChanger(AddNum);
            NumbChanger numberChanger2 = new NumbChanger(MultNum);
            nc1 = numberChanger1;
            nc1 += numberChanger2;
            nc1(123);
            #endregion


            #region Action<T> und Func<T>
            //Action<T>: Für alles was void ist
            Action a1 = new Action(A);
            a1 += B;
            a1();

            //Action<int> a2 = new Action<int>(C);
            Action<int> a2 = C;
            Action<int, int, int> a3 = new Action<int, int, int>(AddNums);
            a3(2, 5, 19);

            a2(123);




            Func<int, int, int> rechner = Add;
            int result = rechner(10, 29);


            #endregion
        }


        public static void AddNums(int a, int b, int c)
        {
            int result = a + b + c;

            Console.WriteLine($"{result}");
        }
        #region Methoden zum Kapseln 
        public static int AddNum(int p)
        {
            num += p;

            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        #endregion

        public static void A()
        { 
            Console.WriteLine("A");
        }

        public static void B()
        {
            Console.WriteLine("B");
        }

        static void C(int zahl)
        {
            Console.WriteLine("C" + zahl);
        }
        public static int getNum()
        {
            return num;
        }



        public static int Add(int z1, int z2)
        {
            return z1 + z2;
        }
    }
}
