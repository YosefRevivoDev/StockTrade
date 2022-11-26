using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StockTrade.Client.Model;
using StockTrade.Client.ViewModel;

namespace StockTrade.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            try
            {
                MainViewModel mainViewModel = new();
                mainWindow.DataContext = mainViewModel;
                mainWindow.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            base.OnStartup(e);
        }
    }
}
