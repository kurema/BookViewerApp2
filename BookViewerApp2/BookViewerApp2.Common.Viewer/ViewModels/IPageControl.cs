using System.Threading.Tasks;
using BookViewerApp2.Book;

namespace BookViewerApp2.ViewModels
{
    public interface IPageControl
    {
        double ActualWidth { get; }
        double ActualHeight { get; }
        Task SetPage(IPage page);
    }

    public interface IBookControl
    {
        bool IsFullScreen { get; set; }
        bool CanFullScreen { get; }
        void GoHome();
        bool CanGoHome { get; }
    }
}
