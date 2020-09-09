using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await_Demo
{
    public class Berechnung
    {
        public Task MachEineBerechnungAsync(Action<int> refreshUI, CancellationTokenSource cts)
        {
            return Task.Run(() =>
            {
                //Eigener Thread 
                for (int i = 0; i <= 100; i++)
                {
                    refreshUI(i);
                    Thread.Sleep(80);

                    if (cts.IsCancellationRequested)
                        break;
                }
            });
        }
    }
}
