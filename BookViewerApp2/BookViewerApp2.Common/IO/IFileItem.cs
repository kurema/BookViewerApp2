using System;
using System.Collections.Generic;
using System.Text;

namespace BookViewerApp2.IO
{
    public interface IFileItem
    {
        string Name { get; }
        DateTimeOffset DateTime { get; }

        object Content { get; }
    }
}
