using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace BookViewerApp2.Helper.Order
{
    public interface IOrder<T>
    {
        string NameKey { get; }
        IEnumerable<T> Sort(IEnumerable<T> item);
    }
}
