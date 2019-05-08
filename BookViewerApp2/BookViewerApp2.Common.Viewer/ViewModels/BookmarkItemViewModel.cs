using System;

namespace BookViewerApp2.ViewModels
{
    public class BookmarkItemViewModel : Helper.Observable
    {
        private int _Page;
        public int Page { get => _Page; set => SetProperty(ref _Page, value); }

        private string _Title;

        public string Title { get => _Title; set => SetProperty(ref _Title, value); }

        public BookmarkItemViewModel(int Page, string Title = "")
        {
            _Page = Page;
            _Title = Title ?? throw new ArgumentNullException(nameof(Title));
        }

    }
}
