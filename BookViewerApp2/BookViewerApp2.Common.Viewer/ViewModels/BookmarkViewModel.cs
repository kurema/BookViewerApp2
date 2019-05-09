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

        public BookmarkViewModel(params BookmarkItemViewModel[] items)
        {
            Items = new ObservableCollection<BookmarkItemViewModel>(items) ?? throw new ArgumentNullException(nameof(items));
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
            return ((IEnumerable<BookmarkItemViewModel>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<BookmarkItemViewModel>)Items).GetEnumerator();
        }

        public void Add(BookmarkItemViewModel item)
        {
            if (Items.Count(a => a.Page == item.Page && !a.IsAutoSave) > 0) return;
            Items.Insert(Items.IndexOf(Items.Last(a => a.Page <= item.Page)), item);
        }

        public void Add(int page, string title = "") => Add(new BookmarkItemViewModel(page, title));

        public void Remove(BookmarkItemViewModel item)
        {
            if (Items.Contains(item) && item?.CanRemove == true) Items.Remove(item);
        }
    }
}
