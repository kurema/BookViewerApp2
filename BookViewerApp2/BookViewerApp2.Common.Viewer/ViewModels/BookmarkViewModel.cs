using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections;
using System.Linq;

namespace BookViewerApp2.ViewModels
{
    public class BookmarkViewModel : Helper.Observable, INotifyCollectionChanged, IEnumerable<BookmarkItemViewModel>
    {
        ObservableCollection<BookmarkItemViewModel> Items;

        public BookmarkViewModel(ObservableCollection<BookmarkItemViewModel> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                ((INotifyCollectionChanged)Items).CollectionChanged += value;
            }

            remove
            {
                ((INotifyCollectionChanged)Items).CollectionChanged -= value;
            }
        }

        public IEnumerator<BookmarkItemViewModel> GetEnumerator()
        {
            return ((IEnumerable<BookmarkItemViewModel>)Items).OrderBy(a => a.Page).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<BookmarkItemViewModel>)Items).OrderBy(a => a.Page).GetEnumerator();
        }
    }
}
