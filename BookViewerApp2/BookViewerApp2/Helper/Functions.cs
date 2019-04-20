using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.Helper
{
    static class Functions
    {
        public static string CombineStringAndDouble(string str, double value)
        {
            return "\"" + str + "\"" + "<" + value.ToString() + "> ";
        }
    }
}
