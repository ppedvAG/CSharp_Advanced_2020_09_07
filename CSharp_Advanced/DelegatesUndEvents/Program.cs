using System;

namespace DelegatesUndEvents
{
    class Program
    {
        #region Sample1 delegate + events
        //static void Main(string[] args)
        //{
        //    ProcessBusinessLogic bl = new ProcessBusinessLogic();

        //    bl.ProcessCompleted += Bl_ProcessCompleted;
        //    bl.StartProcess();
        //}

        //private static void Bl_ProcessCompleted()
        //{
        //    Console.Write("Process Completed");
        //}
        #endregion



        #region EventHandler
        static void Main(string[] args)
        {
            ProcessBusinessLogic2 bl = new ProcessBusinessLogic2();


            ProcessBusinessLogic3 bl3 = new ProcessBusinessLogic3();
            bl3.ProcessCompletedNew += Bl_ProcessCompletedNew;
            bl.ProcessCompleted += Bl_ProcessCompleted;

            bl.ProcessCompletedNew += Bl_ProcessCompletedNew;

            bl.StartProcess();

            Console.ReadLine();
        }

        private static void Bl_ProcessCompletedNew(object sender, EventArgs e)
        {
            MyEventArg myEventArg = (MyEventArg)e;

            Console.WriteLine($"Übertragene Zahl {myEventArg.Uhrzeit.ToString()}");
        }

        private static void Bl_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!");
        }
        #endregion
    }
}
