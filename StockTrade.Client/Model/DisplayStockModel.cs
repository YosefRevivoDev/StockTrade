//using Newtonsoft.Json;
//using StockTrade.Client.ViewModel;
//using StockTrade.Entity;
//using StockTrade.Server;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Net;
//using System.Net.Http.Json;
//using System.Net.Sockets;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Data;

//namespace StockTrade.Client.Model
//{
//    public class DisplayStockModel
//    {
//        private DisplayStockViewModel displayStockViewModel;

//        public void ReciveDataFromServer()
//        {
//            Socket clientSocket = null;
//            connection:
//            try
//            {
//                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//                clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 8820));

//                while(true)
//                {
//                    byte[] reciveDataLen = new byte[4];
//                    clientSocket.Receive(reciveDataLen);

//                    int byteCountLen = Int32.Parse(Encoding.ASCII.GetString(reciveDataLen));
//                    byte[] buffer = new byte[byteCountLen];

//                    clientSocket.Receive(buffer);

//                    string Message = Encoding.UTF8.GetString(buffer);

//                    List<StockData>? convertJsonToObject = JsonConvert.DeserializeObject<List<StockData>>(Message);

//                    UpdateStockData(convertJsonToObject);

//                    Thread.Sleep(3000);
//                }
//            }
//            catch (Exception)
//            {
//                try
//                {
//                    clientSocket.Close();
//                }
//                catch (Exception)
//                {

//                }
//                Console.WriteLine("Failed connection...");
//                goto connection;
//            }
//        }

//        public DisplayStockModel(DisplayStockViewModel _displayStockViewModel)
//        {
//            this.displayStockViewModel = _displayStockViewModel;

//            Thread threadClient = new Thread(ReciveDataFromServer);
//            threadClient.Start();
//        }

//        private static object _lock = new object();

//        public async void UpdateStockData(List<StockData> stockDatas)
//        {
//            if (displayStockViewModel.Stocks == null)
//            {
//                displayStockViewModel.Stocks = new System.Collections.ObjectModel.ObservableCollection<StockData>(stockDatas);
//            }
//            else
//            {
//                //_lock = new object();
//                //BindingOperations.EnableCollectionSynchronization(displayStockViewModel.Stocks, _lock);

//                foreach (StockData item in stockDatas)
//                {
//                    var item2 = displayStockViewModel.Stocks.FirstOrDefault(x => x.StockId == item.StockId);
//                    int index = displayStockViewModel.Stocks.IndexOf(item2);
//                    if (item.DateUpdate != item2.DateUpdate)
//                    {
//                        //await Task.Run(() => DoSomething(item, item2));
//                        item2.DateUpdate = item.DateUpdate;
//                        displayStockViewModel.Stocks[index] = item2;
//                    }
//                }
//            }

//        }

//        private void DoSomething(StockData item, StockData item2)
//        {
//            item.DateUpdate = item2.DateUpdate;
//        }

//    }
//}


using Newtonsoft.Json;
using StockTrade.Client.ViewModel;
using StockTrade.Entity;
using StockTrade.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StockTrade.Client.Model
{
    public class DisplayStockModel
    {
        public List<StockData>? convertJsonToObject;

        public DisplayStockModel()
        {
            Thread thread = new Thread(ReciveDataFromServer);
            thread.Start();
        }

        public void ReciveDataFromServer()
        {
            Socket clientSocket = null;
        connection:
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 8820));

                while (true)
                {
                    byte[] reciveDataLen = new byte[4];
                    clientSocket.Receive(reciveDataLen);

                    int byteCountLen = Int32.Parse(Encoding.ASCII.GetString(reciveDataLen));
                    byte[] buffer = new byte[byteCountLen];

                    clientSocket.Receive(buffer);

                    string Message = Encoding.UTF8.GetString(buffer);

                    convertJsonToObject = JsonConvert.DeserializeObject<List<StockData>>(Message);

                    Thread.Sleep(3000);
                }
            }
            catch (Exception)
            {
                try
                {
                    clientSocket.Close();
                }
                catch (Exception)
                {

                }
                Console.WriteLine("Failed connection...");
                goto connection;
            }
        }
    }
}
