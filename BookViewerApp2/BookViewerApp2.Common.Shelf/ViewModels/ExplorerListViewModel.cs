using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;

namespace BookViewerApp2.ViewModels
{
    public class ExplorerListViewModel : Helper.Observable , INotifyCollectionChanged,IEnumerable<FileItemViewModel>
    {
        ObservableCollection<FileItemViewModel> Content;

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

        public IEnumerator<FileItemViewModel> GetEnumerator()
        {
            return ((IEnumerable<FileItemViewModel>)Content).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<FileItemViewModel>)Content).GetEnumerator();
        }
    }
}
