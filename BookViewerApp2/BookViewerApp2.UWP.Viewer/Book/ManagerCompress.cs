﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace BookViewerApp2.Book
{


    public class ManagerCompressUWP : ManagerCompress, Manager.Viewer.IBookManagerUWP
    {
        public async Task<IBook> GetBook(IStorageFile file)
        {
            var book = new BookCompress();
            await book.LoadAsync(System.IO.WindowsRuntimeStreamExtensions.AsStream(await file.OpenReadAsync()), false, false);//ToDo:Config Support!
            return book;
        }

        public async Task<IBook> GetBook(IRandomAccessStream stream, string filename)
        {
            var book = new BookCompress();
            await book.LoadAsync(System.IO.WindowsRuntimeStreamExtensions.AsStream(stream), false, false);//ToDo:Config Support!
            return book;
        }
    }
}
