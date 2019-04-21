using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using BookViewerApp2.Book;

using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BookViewerApp2.ViewModels
{
    public class PageViewModel : Helper.Observable
    {
        public Book.IPage Content { get; private set; }

        public Views.PageViewControl Control { get; set; }

        public PageViewModel(IPage content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public PageViewModel()
        {
        }

        public async Task UpdateImage()
        {
            var stream= await GetRandomAccessStream();
            if (stream == null) return;
            var result = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            await result.SetSourceAsync(stream);
            Control.Image.Source = result;
        }

        async Task<Windows.Storage.Streams.IRandomAccessStream> GetRandomAccessStream()
        {
            if (Control == null || Content == null) return null;
            try
            {
                if (Content is IPageUWP contentUwp)
                    return await contentUwp.GetStreamUWP(Control.ActualWidth, Control.ActualHeight);
                else if (Content is IPageStream contentStream)
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
