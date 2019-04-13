using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

namespace BookViewerApp2.ViewerLibrary.ViewModels
{
    public class PageViewModel:BaseViewModel
    {
        public PageViewModel(Books.IPageFixed page)
        {
            this.Page = page;
        }

        private Books.IPageFixed Page;

        public ImageSource Source
        {
            get
            {
                if (_Source != null) return _Source;
                _Source = new BitmapImage();
                SetImage(_Source);
                return _Source;
            }
        }
        public BitmapImage _Source;

        private async void SetImage(BitmapImage im)
        {
            try
            {
                await Page.SetBitmapAsync(im);
            }
            catch
            {
                // ignored
            }
        }
    }
}
