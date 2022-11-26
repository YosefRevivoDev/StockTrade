using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using StockTrade.Client.Converters;
using StockTrade.Client.Model;
using StockTrade.Entity;

namespace StockTrade.Client.ViewModel
{
    public class DisplayStockViewModel : BaseViewModel
    {
        private static Brush redColorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
        private static Brush greenColorForground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));

        PercentageChange percentageChange = new PercentageChange();
        EntityViewModel entityViewModel;

        BackgroundWorker backgroundWorker;

        public DisplayStockModel displayStockModel { get; set; }

        public DisplayStockViewModel()
        {
            displayStockModel = new DisplayStockModel();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            UpdateStockData(displayStockModel.convertJsonToObject);
            
        }

        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            while(true)
            {
                Thread.Sleep(3000);
                backgroundWorker.ReportProgress(0);
            }
        }

        public void PropertyChanges()
        {
            OnPropertyChanged(nameof(Stocks));
        }

        public async void UpdateStockData(List<StockData> stockDatas)
        {
            if(stockDatas is null)
            {
                return;
            }
       
            if (Stocks == null)
            {
                Stocks = new ObservableCollection<StockData>(stockDatas);
            }
            else
            {
                foreach (var item in stockDatas)
                {
                    var item2 = Stocks.FirstOrDefault(x => x.StockId == item.StockId);
                    int index = Stocks.IndexOf(item2);
                    if (item.DateUpdate != item2.DateUpdate)
                    {
                        item2 = item2;
                        Stocks[index] = item;
                    }
                }
            }
        }
        private double changePercentage(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue != e.OldValue)
            {
                
            }
            
            return (((entityViewModel.LastPrice / entityViewModel.BaseStockPrice) - 1) * 100);

        }

        /// <summary>
        /// 
        /// </summary>
        private Brush backgroundColor;

        public Brush BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); }
        }

        /// <summary>
        /// 
        /// </summary>
        private Brush foregroundColor;

        public Brush ForegroundColor
        {
            get { return foregroundColor; }
            set { foregroundColor = value; OnPropertyChanged(nameof(ForegroundColor)); }
        }

        private ObservableCollection<StockData> stocksData;

        public ObservableCollection<StockData> Stocks
        {
            get => stocksData;

            set
            {
                stocksData = value;
                OnPropertyChanged(nameof(Stocks));
            }
        }
    }
}


