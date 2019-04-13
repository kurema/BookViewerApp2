using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Books
{
    public interface IPage
    {
        string Title { get; }
        System.IO.Stream GetStream();
    }
}
