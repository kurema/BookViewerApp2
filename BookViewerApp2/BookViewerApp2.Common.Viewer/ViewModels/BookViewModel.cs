using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookViewerApp2.Book;
using System.Windows.Input;

namespace BookViewerApp2.ViewModels
{
    public class BookViewModel : Helper.Observable,IEnumerable<PageViewModel>
    {
        public Book.IBook Book { get; private set; }
        PageViewModel[] _Pages;
        public IBookControl Control;

        private ICommand _CommandToggleFullScreen;
        public ICommand CommandToggleFullScreen { get => _CommandToggleFullScreen = _CommandToggleFullScreen ?? new Helper.DelegateCommand((a) =>
        {
            if (Control != null) Control.IsFullScreen = !Control.IsFullScreen;
        }, (a) => Control?.CanFullScreen ?? false); }

        private ICommand _CommandGoHome;
        public ICommand CommandGoHome { get => _CommandGoHome = _CommandGoHome ?? new Helper.DelegateCommand((a) => Control?.GoHome(), (a) => Control?.CanGoHome ?? false); }

        //private ICommand _CommandAddPage;
        //public ICommand CommandAddPage { get => _CommandAddPage= _CommandAddPage??new Helper.DelegateCommand((a)=>);  }

        private BookmarkViewModel _Bookmark = new BookmarkViewModel();
        public BookmarkViewModel Bookmark { get => _Bookmark; set => SetProperty(ref _Bookmark, value); }

        public BookViewModel()
        {
        }

        public BookViewModel(IBook book)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
        }

        public BookViewModel(IBook book, IBookControl control) : this(book)
        {
            Control = control ?? throw new ArgumentNullException(nameof(control));
        }

        PageViewModel[] Pages => _Pages = _Pages ?? Book?.Select(a => new PageViewModel(a)).ToArray() ?? new PageViewModel[0];

        public string ID => Book?.ID ?? "";

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<PageViewModel> GetEnumerator()
        {
            return ((IEnumerable<PageViewModel>)Pages).GetEnumerator();
        }
    }
}
