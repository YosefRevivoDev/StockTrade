using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrade.Client.ViewModel
{
    public class EntityViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [Key]
        private readonly int stockId;
        public int StockId
        {
            get { return stockId; }
        }

        private readonly string? stockName;

        public string StockName
        {
            get { return stockName; }
        }

        private readonly double baseStockPrice;


        public double BaseStockPrice
        {
            get { return baseStockPrice; }
        }

        private int supplyQty;

        public int SupplyQty
        {
            get { return supplyQty; }
            set { supplyQty = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SupplyQty))); }
        }

        private double supplyPrice;

        public double SupplyPrice
        {
            get { return supplyPrice; }
            set { supplyPrice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SupplyPrice))); }
        }

        private int demandQty;

        public int DemandQty
        {
            get { return demandQty; }
            set { demandQty = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DemandQty)));}
        }

        private double demandPrice;

        public double DemandPrice
        {
            get { return demandPrice; }
            set { demandPrice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DemandPrice))); }
        }

        private double lastPrice;

        public double LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastPrice))); }
        }

        private string dateUpdate;

        public string DateUpdate
        {
            get { return dateUpdate; }
            set { dateUpdate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateUpdate))); }
        }

        public EntityViewModel(int stockId, string? stockName, double baseStockPrice, int supplyQty,
                    double supplyPrice, int demandQty, double demandPrice, double lastPrice, DateTime dateUpdate)
        {
            this.stockId = stockId;
            this.stockName = stockName;
            this.baseStockPrice = baseStockPrice;
            SupplyQty = supplyQty;
            SupplyPrice = supplyPrice;
            DemandQty = demandQty;
            DemandPrice = demandPrice;
            LastPrice = lastPrice;
            DateUpdate = dateUpdate.ToString("T");
        }
    }
}
