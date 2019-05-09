using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using BookViewerApp2.Book;

namespace BookViewerApp2.ViewModels
{
    public class PageViewModel : Helper.Observable
    {
        public Book.IPage Content { get; private set; }

        public IPageControl Control { get; set; }

        public PageViewModel(IPage content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public PageViewModel()
        {
        }

        public PageViewModel(IPage content, IPageControl control) : this(content)
        {
            Control = control ?? throw new ArgumentNullException(nameof(control));
        }

        public async Task UpdateImage()
        {
            if (Control == null || Content == null) return;
            await Control.SetPage(Content);
        }
    }
}
