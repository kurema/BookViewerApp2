using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Book
{
    public interface IBookUWP : IBook , IEnumerable<IPageUWP>
    {

    }

    public interface IPageUWP : IPage
    {
        Task<Windows.Storage.Streams.InMemoryRandomAccessStream> GetStreamUWP(double width,double height);
    }
}
