using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Compression;
using Windows.UI.Xaml.Media;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;

namespace BookViewerApp2.Books
{
    public class BookCbz : IBook
    {
        public string Title { get; private set; }
        public ZipArchive Content { get; private set; }

        public int Pages => AvailableEntries.Count();

        public ReadOnlyDictionary<string, int> Toc => throw new NotImplementedException();

        public ZipArchiveEntry[] AvailableEntries { get; private set; } = new ZipArchiveEntry[0];

        public string ID => _ID = _ID ?? "";
        private string _ID;

        public IPage GetPage(int i)
        {
            return new PageCbz(AvailableEntries[i]);
        }
    }

    public class PageCbz : IPage
    {
        private ZipArchiveEntry Content;

        public PageCbz(ZipArchiveEntry Content)
        {
            this.Content = Content;
        }

        public string Title => Content.FullName;

        public Stream GetStream()
        {
            var s = Content.Open();
            var ms = new MemoryStream();
            s.CopyTo(ms);
            s.Dispose();
            return ms;
        }
    }
}
