using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;

using System.Threading.Tasks;
using System.Linq;
using BookViewerApp2.Helper.Order;
using BookViewerApp2.IO;

namespace BookViewerApp2.ViewModels
{
    public class ExplorerListViewModel : Helper.Observable
    {
        ObservableCollection<FileItemViewModel> _Content;
        public ObservableCollection<FileItemViewModel> Content
        {
            get => _Content; set => SetProperty(ref _Content, value);
        }
        public OrderCollection<IO.IFileItem> Orders
        {
            get
            {
                if (_Orders == null)
                {
                    _Orders = new OrderCollection<IO.IFileItem>(new OrderFunc<IO.IFileItem>[]
                    {
                        new OrderFunc<IO.IFileItem>("order_file_name",a=>a.OrderBy(b=>b.Name)),
                        new OrderFunc<IO.IFileItem>("order_datetime",a=>a.OrderBy(b=>b.DateTime.Ticks))
                    }
                    );
                }
                return _Orders;
            }
            set => SetProperty(ref _Orders, value);
        }

        public IOrder<IFileItem> Order { get => _Order ?? Orders.FirstOrDefault() ?? new OrderKeep<IFileItem>(); set { if (value != null) { SetProperty(ref _Order, value); } } }

        OrderCollection<IO.IFileItem> _Orders;

        IOrder<IO.IFileItem> _Order;

        public async Task OpenAsync(IO.IDirectory directory)
        {
            var items = Order.Sort(await directory.GetDirectories()).Select(a => new FileItemViewModel(a)).ToList();
            items.AddRange(Order.Sort(await directory.GetFiles()).Select(a => new FileItemViewModel(a)));

            this.Content = new ObservableCollection<FileItemViewModel>(items);
        }
    }
}
