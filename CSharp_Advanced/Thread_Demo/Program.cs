using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Program
    {
        static int _value;
        static void Main(string[] args)
        {
            //#region Task erstellen

            ////.NET 2.0 
            //Thread thread = new Thread(IchMacheEtwasImThread);

            //thread.Start();

            ////thread.IsBackground = true -> Wenn der Parent Thread geschlossen wird, werden alle Child Theads (mit IsBackground = true) geschlossen (abort).
            //                      //false-> Child Thread bleiben erhalten und arbeiten ihre Logik bis zu Ende ab!


            //thread.Join(); // Join = Warte bis der Thread fertig ist! 

            //for (int i=0; i < 100; i++)
            //{
            //    Console.WriteLine("+");
            //}

            ////Console.WriteLine("Thread wird jetzt beendet");
            ////thread.Abort(); //Thread wird abgebrochen
            //#endregion

            //Console.WriteLine("####### Weiter mit Beispiel 2 (Threads mit Parameter");
            //Console.ReadLine();

            //#region Parameterübergabe bei Threads
            //ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwasinEinemThreadMitParameter);

            //Thread t2 = new Thread(parameterizedThreadStart);
            //t2.Start(333);
            //t2.Join();
            //#endregion

            //Console.WriteLine("####### Weiter mit Beispiel 3 (Thread-Pool");
            //Console.ReadLine();

            //#region ThreadPool
            //ThreadPool.QueueUserWorkItem(MachWasImPool1);
            //ThreadPool.QueueUserWorkItem(MachWasImPool2);
            //ThreadPool.QueueUserWorkItem(MachWasImPool3);


            //#endregion
            //Console.WriteLine("####### Weiter mit Beispiel 4 (Monitor / Lock");
            //Console.ReadLine();


            //#region Monitor / Lock


            //Konto meinKonto = new Konto();
            //for (int i = 0; i < 100; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(MachEinKontoUpdate, meinKonto);
            //}
            //#endregion

            //Console.WriteLine("####### Weiter mit Beispiel 4b - Interlock");
            //Console.ReadLine();



            #region Interlocked
            //https://docs.microsoft.com/de-de/dotnet/api/system.threading.interlocked.increment?view=netcore-3.1

            Thread thread1 = new Thread(new ThreadStart(A));
            Thread thread2 = new Thread(new ThreadStart(A));
            Thread thread3 = new Thread(new ThreadStart(A));
            Thread thread4 = new Thread(new ThreadStart(B));
            Thread thread5 = new Thread(new ThreadStart(C));
            
            
            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            thread4.Start();


            //thread1.Join();
            //thread2.Join();
            //thread3.Join();

            
            thread4.Join();

            thread5.Start();

            thread5.Join();
            Console.WriteLine(Program._value);
            #endregion



            Console.WriteLine("####### Weiter mit Beispiel 5 Mutex");
            Console.ReadLine();




        }

        static void A()
        {
            // Add one.
            Interlocked.Add(ref Program._value, 2);
        }

        static void B()
        {
            Interlocked.Exchange(ref Program._value, 99);
        }

        static void C()
        {
            Interlocked.Increment(ref Program._value);
        }

        private static void MachEinKontoUpdate(object state)
        {
            Random r = new Random();
            Konto meinKonto = new Konto();

            for (int i = 0; i <10; i++)
            {
                int auswahl = r.Next(0, 10);

                if (auswahl % 2 == 0)
                    meinKonto.Einzahlen(r.Next(0, 1000));
                else if (meinKonto.Kontostand < 0)
                    meinKonto.Einzahlen(r.Next(0, 1000));
                else meinKonto.Abheben(r.Next(0, 1000));

                Console.WriteLine(meinKonto.Kontostand);
            }
        }

        private static void IchMacheEtwasImThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                //Thread.Sleep(250); // 1/4 von einer Sekunde (250ms)
                Console.Write("*");
            }
        }

        private static void MachEtwasinEinemThreadMitParameter(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                //Thread.Sleep(500);
                Console.Write("#");
            }
        }
        private static void MachWasImPool3(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("#");
            }
        }
        private static void MachWasImPool2(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("-");
            }
        }
        private static void MachWasImPool1(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("*");
            }
        }



        
    }
}
