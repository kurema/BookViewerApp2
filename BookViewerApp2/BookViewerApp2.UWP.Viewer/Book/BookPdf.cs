using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookViewerApp2.Manager;
using Windows.Storage;
using Windows.Storage.Streams;
using pdf = Windows.Data.Pdf;

//Dependency: UWP
namespace BookViewerApp2.Book
{
    public class BookPdf: IBookUWP
    {
        public BookPdf() { }

        public BookPdf(pdf.PdfDocument content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            OnLoaded();
        }

        public BookPdf(Windows.Storage.IStorageFile file)
        {
            Task.Run(async () =>
            {
                await LoadAsync(file ?? throw new ArgumentNullException(nameof(file)));
            });
        }

        public pdf.PdfDocument Content { get; private set; }

        public string ID { get; private set; } = "Unloaded Pdf";

        public event EventHandler Loaded;
        private void OnLoaded() => Loaded?.Invoke(this, new EventArgs());

        public async Task LoadAsync(IStorageFile file)
        {
            try
            {
                Content = await pdf.PdfDocument.LoadFromFileAsync(file);
                OnLoaded();
                ID = Helper.Functions.CombineStringAndDouble(file.Name, Content.PageCount);
            }
            catch
            {
                Content = null;
            }
        }

        public async Task LoadAsync(Windows.Storage.Streams.IRandomAccessStream stream,string filename)
        {
            try
            {
                Content = await pdf.PdfDocument.LoadFromStreamAsync(stream);
                OnLoaded();
                ID = Helper.Functions.CombineStringAndDouble(filename, Content.PageCount);
            }
            catch
            {
                Content = null;
            }
        }

        public IEnumerator<IPageUWP> GetEnumerator()
        {
            if (Content == null) { throw new ArgumentOutOfRangeException(); }
            for (uint i = 0; i < Content.PageCount; i++)
            {
                yield return new PagePdf(Content, i);
            }
        }

        IEnumerator<IPageUWP> IEnumerable<IPageUWP>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<IPage> IEnumerable<IPage>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class PagePdf : IPageUWP
    {
        pdf.PdfDocument _Pdf;
        uint _PageCount;

        pdf.PdfPage _Page;

        public PagePdf(pdf.PdfPage Page)
        {
            _Page = Page ?? throw new ArgumentNullException(nameof(Page));
        }

        public PagePdf(pdf.PdfDocument Pdf, uint PageCount)
        {
            _Pdf = Pdf ?? throw new ArgumentNullException(nameof(Pdf));
            _PageCount = PageCount;
            if (_PageCount >= _Pdf.PageCount) throw new ArgumentOutOfRangeException(nameof(PageCount));
        }

        public pdf.PdfPage Content => _Page = _Page ?? _Pdf.GetPage(_PageCount);

        public async Task<Windows.Storage.Streams.InMemoryRandomAccessStream> GetStreamUWP(double width, double height)
        {
            var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            await RenderToStreamAsync(stream, width, height);
            return stream;
        }

        pdf.PdfPageRenderOptions _LastOption = null;

        public async Task RenderToStreamAsync(IRandomAccessStream stream, double width, double height)
        {
            if (width == 0 || height == 0)
            {
                await Content.RenderToStreamAsync(stream);
                _LastOption = null;
            }
            var pdfOption = new pdf.PdfPageRenderOptions();
            if (height / Content.Size.Height < width / Content.Size.Width)
                pdfOption.DestinationHeight = (uint)height;
            else
                pdfOption.DestinationWidth = (uint)width;
            _LastOption = pdfOption;
            await Content.RenderToStreamAsync(stream, pdfOption);
        }
    }

    public class ManagerPdf : Manager.Viewer.IBookManagerUWP
    {
        public string[] Extensions => new[] { ".pdf" };

        public async Task<IBook> GetBook(IStorageFile file)
        {
            var result = new BookPdf();
            await result.LoadAsync(file);
            return result;
        }

        public async Task<IBook> GetBook(IRandomAccessStream stream, string filename)
        {
            var result = new BookPdf();
            await result.LoadAsync(stream, filename);
            return result;
        }
    }
}
