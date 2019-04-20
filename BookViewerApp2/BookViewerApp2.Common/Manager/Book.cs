using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Manager
{
    public static class Book
    {
        public static string[] AvailableExtensions => AvailableBookManager.SelectMany((a) => a.Extensions).ToArray();

        public static IBookManager[] AvailableBookManager { get; set; }
    }

    public interface IBookManager
    {
        string[] Extensions { get; }
    }
}
