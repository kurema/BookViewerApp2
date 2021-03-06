﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Manager.Viewer
{
    public interface IBookManagerUWP : BookViewerApp2.Manager.Viewer.IBookManager
    {
        Task<BookViewerApp2.Book.IBook> GetBook(Windows.Storage.IStorageFile file);
        Task<BookViewerApp2.Book.IBook> GetBook(Windows.Storage.Streams.IRandomAccessStream stream, string filename);
    }
}
