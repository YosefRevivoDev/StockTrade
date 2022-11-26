using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTrade.Client.Model;

namespace StockTrade.Client.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            NavigationStore = new DisplayStockViewModel();
        }

        private BaseViewModel navigationStore;

        public BaseViewModel NavigationStore
        {
            get => navigationStore;

            set
            {
                navigationStore = value;
                OnPropertyChanged(nameof(NavigationStore));
            }
        }
    }
}
