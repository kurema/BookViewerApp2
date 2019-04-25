using System;
using System.Collections.Generic;
using System.Text;
using BookViewerApp2.IO;

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
                Set(ref _Content, value);
                OnPropertyChanged(nameof(IsDirectory));
                OnPropertyChanged(nameof(Name));
            }
        }

        public bool IsDirectory => Content is IO.IDirectory;

        public string Name => _Content?.Name ?? "";
        public DateTimeOffset DateTime => _Content?.DateTime ?? new DateTimeOffset();
    }
}
