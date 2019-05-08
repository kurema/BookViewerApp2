using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BookViewerApp2.Book;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace BookViewerApp2.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class ViewerPage : Page
    {
        public ViewerPage()
        {
            this.InitializeComponent();

            flipViewer.DataContext = new ViewModels.BookViewModel(new SampleBook());

        }

        public class SamplePage : IPage
        {

        }

        public class SampleBook : Book.IBook
        {
            public string ID => "";

            public event EventHandler Loaded;

            Book.IPage[] pages { get; set; } = new[] { new SamplePage(), new SamplePage() };

            public IEnumerator<IPage> GetEnumerator()
            {
                return ((IEnumerable<IPage>)pages).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<IPage>)pages).GetEnumerator();
            }
        }
    }
}
