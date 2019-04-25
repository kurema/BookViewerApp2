using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System;

namespace BookViewerApp2.Helper.Order
{
    public class OrderCollection<T> : IEnumerable<IOrder<T>>,INotifyCollectionChanged
    {
        ObservableCollection<IOrder<T>> Content = new ObservableCollection<IOrder<T>>();

        public OrderCollection()
        {
        }

        public OrderCollection(IEnumerable<IOrder<T>> content)
        {
            Content = new ObservableCollection<IOrder<T>>(content) ?? throw new ArgumentNullException(nameof(content));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                ((INotifyCollectionChanged)Content).CollectionChanged += value;
            }

            remove
            {
                ((INotifyCollectionChanged)Content).CollectionChanged -= value;
            }
        }

        public IEnumerator<IOrder<T>> GetEnumerator()
        {
            return ((IEnumerable<IOrder<T>>)Content).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IOrder<T>>)Content).GetEnumerator();
        }
    }
}
