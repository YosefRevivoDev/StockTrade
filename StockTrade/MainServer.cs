using StockTrade.Entity;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace StockTrade.Server
{
    internal class MainServer
    {
        static Random random = new Random();

        static void InitStock(StockServer stockServer)
        {
            for (int i = 1000; i <= 1010; i++)
            {
                StockData stockData = new(
                    i, $"Stock : {i}", random.Next(0, 100) + random.NextDouble(), random.Next(0, 300),
                    random.Next(0, 100) + random.NextDouble(), random.Next(0, 100), random.Next(0, 600) + random.NextDouble(),
                    random.Next(0, 600) + random.NextDouble(), DateTime.Now
                    );
                stockServer.stockDatas.Add(stockData);
            }
        }

        static void Main()
        {
            StockServer stockServer = StockServer.GetInstance();

            InitStock(stockServer);

            Thread thread = new Thread(StockTradeUpdate);
            thread.Start();

            SendDataToClient();
        }

        private static async void SendDataToClient()
        {
            StockServer stockServer = StockServer.GetInstance();
            using Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, 8820));

        connection:
            try
            {
                server.Listen(3000);
            
                Socket client = await server.AcceptAsync();

                while (true)
                {
                    Thread.Sleep(3000);

                    byte[] data = JsonSerializer.SerializeToUtf8Bytes(stockServer.stockDatas);
                    string lenData = data.Length.ToString().PadLeft(4, '0');
                    client.Send(Encoding.ASCII.GetBytes(lenData));
                    client.Send(data);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("failed...");
                goto connection;
            }
            
        }

        private static void StockTradeUpdate()
        {
            StockServer stockServer = StockServer.GetInstance();

            while (true)
            {
                foreach (StockData stockData in stockServer.stockDatas)
                {
                    if (random.Next(0, 4) == 0)
                    {
                        stockData.SupplyQty += random.Next(-5, 5);
                        stockData.SupplyPrice += random.Next(-3, 2) + random.NextDouble();
                        stockData.DemandQty += random.Next(-3, 3);
                        stockData.DemandPrice += random.Next(-2, 1) + random.NextDouble();
                        stockData.LastPrice += random.Next(-3, 2) + random.NextDouble();
                        stockData.DateUpdate = DateTime.Now.ToString("T");
                    }
                }
                Thread.Sleep(3000);
            }
        }
    }
}
