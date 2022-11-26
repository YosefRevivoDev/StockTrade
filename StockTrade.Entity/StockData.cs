using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;


namespace StockTrade.Entity
{
    public class StockData
    { 
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

        public int SupplyQty { get; set; }

        public double SupplyPrice { get; set; }

        public int DemandQty { get; set; }

        public double DemandPrice { get; set; }

        public double LastPrice { get; set; }

        public string DateUpdate { get; set; }
   

        public StockData(int stockId, string? stockName, double baseStockPrice, int supplyQty,
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