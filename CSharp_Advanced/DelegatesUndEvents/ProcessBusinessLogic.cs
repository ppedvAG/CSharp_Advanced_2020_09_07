using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesUndEvents
{
    public delegate void Notiy(); //delegate


    public class ProcessBusinessLogic
    {
        public event Notiy ProcessCompleted; //Event

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }


    public class ProcessBusinessLogic2
    {
        public event EventHandler ProcessCompleted;
        public event EventHandler ProcessCompletedNew;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");

            


            MyEventArg myEventArg = new MyEventArg();
            myEventArg.Uhrzeit = DateTime.Now;


            OnProcessCompletedNew(myEventArg); //Beispiel 2
            OnProcessCompleted(EventArgs.Empty); //No event data -> Beispiel1
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

        protected virtual void OnProcessCompletedNew(MyEventArg e)
        {
            ProcessCompletedNew?.Invoke(this, e);
        }

    }

    public class ProcessBusinessLogic3
    {
        public event EventHandler ProcessCompleted;
        public event EventHandler ProcessCompletedNew;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");




            MyEventArg myEventArg = new MyEventArg();
            myEventArg.Uhrzeit = DateTime.Now;


            OnProcessCompletedNew(myEventArg); //Beispiel 2
            OnProcessCompleted(EventArgs.Empty); //No event data -> Beispiel1
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

        protected virtual void OnProcessCompletedNew(MyEventArg e)
        {
            ProcessCompletedNew?.Invoke(this, e);
        }

    }

    public class MyEventArg : EventArgs
    {
        public DateTime Uhrzeit { get; set; }
    }
}
