using StockTrade.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrade.Server
{
    public class StockServer
    {

        static StockServer instance;
        public static StockServer GetInstance()
        {
            if (instance is null)
                instance = new StockServer();
            return instance;
        }

        StockServer() { stockDatas = new(); }

        //static readonly StockServer instance = new StockServer();

        //public static StockServer Instance { get { return instance; } }

        //static StockServer() { }

        //StockServer() { }

        public List<StockData> stockDatas;

    }
}
