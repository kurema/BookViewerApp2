using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Book
{
    public interface IBook:IEnumerable<IPage>
    {
        string ID { get; }
        event EventHandler Loaded;
    }

    public interface IPage
    {

    }
}
