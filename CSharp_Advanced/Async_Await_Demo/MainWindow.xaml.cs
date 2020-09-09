using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Async_Await_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private CancellationTokenSource cts = null;


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            buttonTask.IsEnabled = false;

            //await Task.Run(MachEtwasImUI);

            //Task t1 = null;
            //t1.Wait = Macht Probleme

            cts = new CancellationTokenSource();

            Berechnung b1 = new Berechnung();
            await b1.MachEineBerechnungAsync(RefreshUI, cts);


            buttonTask.IsEnabled = true;
        }

        private void RefreshUI(int i)
        {
            Dispatcher.Invoke(() => progressBarWert.Value = i);
        }

        private void MachEtwasImUI()
        {
            for (int i = 0; i <= 100; i++)
            {
                Dispatcher.Invoke(() => progressBarWert.Value = i);
                Thread.Sleep(80);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }
    }
}
