﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

namespace BookViewerApp2.IO
{
    public interface IDirectory : IFileItem
    {
        Task<IFile[]> GetFiles();
        Task<IDirectory[]> GetDirectories();
    }
}
