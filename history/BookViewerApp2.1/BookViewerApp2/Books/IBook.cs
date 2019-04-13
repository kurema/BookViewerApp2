using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Books
{
    public interface IBook
    {
        string Title { get; }
        IPage GetPage(int i);
        int Pages { get; }
        System.Collections.ObjectModel.ReadOnlyDictionary<string,int> Toc { get; }
        string ID { get; }
    }
}
