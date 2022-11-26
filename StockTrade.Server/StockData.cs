using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrade.Server
{
    internal class StockData
    {
        [Key]
        public readonly int StockId;

        public readonly string? StockName;

        public readonly double BaseStockPrice;

        public int 
    }
}
