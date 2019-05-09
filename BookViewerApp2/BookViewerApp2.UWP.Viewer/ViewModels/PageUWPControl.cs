using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using BookViewerApp2.Book;

using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using BookViewerApp2.Views;

namespace BookViewerApp2.ViewModels
{
    public class PageControlUWP : IPageControl
    {
        public PageControlUWP(PageViewControl content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public Views.PageViewControl Content { get; private set; }

        public double ActualWidth => Content?.ActualWidth ?? 0;

        public double ActualHeight => Content?.ActualHeight ?? 0;

        public async Task SetPage(IPage page)
        {
            if (page == null) return;
            var stream = await GetRandomAccessStream(page);
            if (stream == null) return;
            var result = new BitmapImage();
            await result.SetSourceAsync(stream);
            Content.Image.Source = result;
        }

        async Task<Windows.Storage.Streams.IRandomAccessStream> GetRandomAccessStream(IPage page)
        {
            if (Content == null || page == null) return null;
            try
            {
                if (page is IPageUWP contentUwp)
                    return await contentUwp.GetStreamUWP(ActualWidth, ActualHeight);
                else if (page is IPageStream contentStream)
                    return System.IO.WindowsRuntimeStreamExtensions.AsRandomAccessStream(contentStream.Stream);
                return null;
            }
            catch
            {
                return null;
                //ToDo: 失敗時に代替画像でも使うか？
            }
        }
    }
}
