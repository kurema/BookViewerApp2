using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace BookViewerApp2.IO
{
    public class FileUWP : IFile
    {
        public FileUWP(Windows.Storage.IStorageFile content)
        {
            this.ContentUWP = content ?? throw new ArgumentNullException(nameof(content));
        }

        public string Name => ContentUWP?.Name ?? "";
        public DateTimeOffset DateTime => ContentUWP?.DateCreated ?? new DateTimeOffset();
        public object Content => ContentUWP;
        public IStorageFile ContentUWP { get; private set; }
    }
}
