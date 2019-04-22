using System;
using System.Collections.Generic;
using System.Text;

namespace BookViewerApp2.IO
{
    public interface IDirectory : IFileItem
    {
        IFile[] Files { get; }
        IDirectory[] Directories { get; }
    }
}
