using System;
using System.Collections.Generic;
using System.Text;
using BookViewerApp2.IO;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;

using System.Threading.Tasks;
using System.Linq;

namespace BookViewerApp2.ViewModels
{
    public class FileItemViewModel:Helper.Observable
    {
        IO.IFileItem _Content;

        public FileItemViewModel(IFileItem content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public IO.IFileItem Content
        {
            get => _Content;
            set {
                SetProperty(ref _Content, value);
                OnPropertyChanged(nameof(IsDirectory));
                OnPropertyChanged(nameof(Name));
            }
        }

        ObservableCollection<FileItemViewModel> _Children = new ObservableCollection<FileItemViewModel>();
        public ObservableCollection<FileItemViewModel> Children
        {
            get => _Children; set => SetProperty(ref _Children, value);
        }

        public bool IsDirectory => Content is IO.IDirectory;

        public string Name => _Content?.Name ?? "";
        public DateTimeOffset DateTime => _Content?.DateTime ?? new DateTimeOffset();

        public async Task LoadChildren()
        {
            if (Content is IDirectory dir)
            {
                Children = new ObservableCollection<FileItemViewModel>((await dir.GetDirectories())?.Select(a => new FileItemViewModel(a)));
            }
        }

        public void ClearChildren() => Children = new ObservableCollection<FileItemViewModel>();
    }
}
