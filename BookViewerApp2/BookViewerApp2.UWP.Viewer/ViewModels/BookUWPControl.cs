using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp2.ViewModels
{
    public class BookUWPControl : IBookControl
    {
        public bool IsFullScreen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanFullScreen => throw new NotImplementedException();

        public bool CanGoHome => throw new NotImplementedException();

        public void GoHome()
        {
            throw new NotImplementedException();
        }
    }
}
