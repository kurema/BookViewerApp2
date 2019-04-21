using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.ViewModels
{
    public class BookViewModel : Helper.Observable,IEnumerable<PageViewModel>
    {
        public Book.IBook Book { get; private set; }
        PageViewModel[] _Pages;
        PageViewModel[] Pages => _Pages = _Pages ?? Book?.Select(a => new PageViewModel(a)).ToArray() ?? new PageViewModel[0];

        public string ID => Book?.ID ?? "";

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<PageViewModel> GetEnumerator()
        {
            return ((IEnumerable<PageViewModel>)Pages).GetEnumerator();
        }
    }
}
