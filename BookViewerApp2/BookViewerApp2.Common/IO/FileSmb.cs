using System;
using System.Collections.Generic;
using System.Text;
using SharpCifs.Smb;

namespace BookViewerApp2.IO
{
    public class FileSmb : FileItemSmb, IFile
    {
        public FileSmb(SmbFile contentSmb) : base(contentSmb ?? throw new ArgumentNullException(nameof(contentSmb)))
        {
            if (!contentSmb.IsFile()) throw new ArgumentException("Argument is not File.");
        }
    }
}
