using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Manager.Viewer
{
    public static class Common
    {
        public static string[] AvailableExtensions => AvailableBookManager.SelectMany((a) => a.Extensions).ToArray();

        public static IBookManager[] AvailableBookManager { get; set; }
    }
}
