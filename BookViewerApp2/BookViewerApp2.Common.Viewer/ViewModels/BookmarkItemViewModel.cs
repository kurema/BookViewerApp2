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


        private bool _CanRemove;
        public bool CanRemove { get => _CanRemove; set => SetProperty(ref _CanRemove, value); }


        private bool _IsAutoSave;
        public bool IsAutoSave { get => _IsAutoSave; set => SetProperty(ref _IsAutoSave, value); }

        private bool _IsHead;
        public bool IsHead { get => _IsHead; set => SetProperty(ref _IsHead, value); }

        private bool _IsTail;
        public bool IsTail { get => _IsTail; set => SetProperty(ref _IsTail, value); }

    }
}
