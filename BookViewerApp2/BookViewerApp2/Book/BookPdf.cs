using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookViewerApp2.Manager;
using Windows.Storage;
using pdf = Windows.Data.Pdf;

//Dependency: UWP
namespace BookViewerApp2.Book
{
    public class BookPdf:IBook
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

        public async Task LoadAsync(Windows.Storage.IStorageFile file)
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

        public IEnumerator<IPage> GetEnumerator()
        {
            if (Content == null) { throw new ArgumentOutOfRangeException(); }
            for (uint i = 0; i < Content.PageCount; i++)
            {
                yield return new PagePdf(Content, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class PagePdf : IPage
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
    }

    public class ManagerPdf : Manager.Book.IBookManager
    {
        public string[] Extensions => new[] { ".pdf" };

        public async Task<IBook> GetBook(IStorageFile file)
        {
            var result = new BookPdf();
            await result.LoadAsync(file);
            return result;
        }
    }

}
