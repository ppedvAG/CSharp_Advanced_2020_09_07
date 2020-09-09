using System;
using System.Threading.Tasks; // ->TPL
using System.Threading; // Altes Threading 
using System.Diagnostics;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Beispiel 1: Einfacher Task ausführen
            //Task t1 = new Task(IchMacheEtwasImTask);
            //t1.Start();

            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(100);
            //    Console.Write("*");
            //}
            //#endregion

            //#region Beispiel 2 Task.Factory
            //Task t2 = Task.Factory.StartNew(IchMacheEtwasImTask2);
            //#endregion

            //#region Beispiel 3 Task.Run()
            //Task t3 = Task.Run(IchMacheEtwasImTask3); //Task.Run macht in Wirklichkeit:-> Task.Factory.StartNew(IchMacheEtwasImTask, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default); 
            //#endregion

            //#region Task mit Parameter
            //Task<string> t4 = Task.Factory.StartNew(GibtDatumMitInput, 10000);
            //Console.Write($"Der Rückgabewert meiner GibtDatumMitInput ist : {t4.Result}");
            //#endregion

            //#region Beenden von Tasks
            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task t1 = Task.Factory.StartNew(MeineMethodeMitAbbrechen, cts);


            //Thread.Sleep(10000);
            //Console.WriteLine("Jetzt wird der Task geschlossen:");
            //cts.Cancel();
            //#endregion


            #region Exception-Handling im Task
            //Task t1 = null, t2 = null, t3 = null, t4 = null;

            //try
            //{
            //    ////Tasks werden gestartet
            //    t1 = new Task(MachEinenFehler1);
            //    t1.Start();

            //    t2 = Task.Factory.StartNew(MachEinenFehler2);

            //    t3 = Task.Run(MachEinenFehler3);

            //    t4 = Task.Run(MachKeinenFehler);


            //    Task.WaitAll(t1,t2,t3,t4);

            //}
            //catch (AggregateException ex) //<- Spezielle Exception nur für Tasks
            //{
            //    foreach (var einzelneException in ex.InnerExceptions)
            //        Console.WriteLine(einzelneException.Message);
            //}

            //if (t4.IsCompleted)
            //{
            //    Console.WriteLine("Task 4 ist fertig");
            //}

            //// Task t3 
            //if (t3.IsCompleted)
            //{
            //    Console.WriteLine("Task 3 ist fertig");
            //}

            //if (t3.IsFaulted)
            //{
            //    Console.WriteLine("Task 3 hat einen Fehler");
            //}

            //if (t3.IsCanceled)
            //{
            //    Console.WriteLine("Task 3 wurde abgebrochen");
            //}




            #endregion


            int[] durchgänge = { 1_000, 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 100_000_000 };
            Stopwatch watch = new Stopwatch();

            for (int i = 0; i < durchgänge.Length; i++)
            {
                Console.WriteLine($"Durchgang Nr {durchgänge[i]}");
                watch.Restart();
                ForSchleife(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                ParallelFor(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds}ms");
                Console.WriteLine("---------------------------------------------------");
            }

            





            Console.ReadLine();
        }

        private static void ParallelFor(int durchgänge)
        {
            double[] erg = new double[durchgänge];

            Parallel.For(0, durchgänge, i =>
            {
                erg[i] = ((Math.Pow(i, 0.33333333333333333333333333333333333333333333) * Math.Sin(i + 2)) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
            });
        }

        private static void ForSchleife(int durchgänge)
        {
            double[] erg = new double[durchgänge];

            for (int i = 0; i < durchgänge; i++)
            {
                erg[i] = ((Math.Pow(i, 0.33333333333333333333333333333333333333333333) * Math.Sin(i + 2)) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
            }
        }


        #region Task - Beispiele
        private static void IchMacheEtwasImTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }
        }

        private static void IchMacheEtwasImTask2()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("-");
            }
        }

        private static void IchMacheEtwasImTask3()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("-");
            }
        }
        #endregion

        #region Task mit Paramtern
        private static string GibtDatumMitInput(object input)
        {
            int dauer = (int)input;

            Thread.Sleep(dauer);
            return DateTime.Now.ToLongDateString();
        }
        #endregion

        #region Task mit CancellationTokenSource
        //private static void MeineMethodeMitAbbrechen(object param)
        //{
        //    CancellationTokenSource source = (CancellationTokenSource)param;

        //    while(true)
        //    {
        //        Console.WriteLine("zzz....zzz");
        //        Thread.Sleep(50);

        //        if (source.IsCancellationRequested)
        //            break;
        //    }
        //}
        #endregion


        #region Methoden mit Exceptions
        private static void MachEinenFehler1()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Thread.Sleep(5000);
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Thread.Sleep(8000);
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
        {
            Console.WriteLine("MachKeinenFehler wird ausgeführt");
        }
        #endregion
    }
}
