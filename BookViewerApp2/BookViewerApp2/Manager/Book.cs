using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Manager
{
    //Dependency:UWP
    public class Book
    {
        public static string[] AvailableExtensions => AvailableBookManager.SelectMany((a) => a.Extensions).ToArray();

        public static IBookManager[] AvailableBookManager { get; set; }

        public interface IBookManager
        {
            string[] Extensions { get; }
            Task<BookViewerApp2.Book.IBook> GetBook(Windows.Storage.IStorageFile file);
        }
    }
}
