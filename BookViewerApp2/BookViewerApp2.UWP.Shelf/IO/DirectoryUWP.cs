using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace BookViewerApp2.IO
{
    public class DirectoryUWP : IDirectory
    {
        public DirectoryUWP(IStorageFolder contentUWP)
        {
            ContentUWP = contentUWP ?? throw new ArgumentNullException(nameof(contentUWP));
        }

        public string Name => ContentUWP?.Name ?? "";

        public DateTimeOffset DateTime => ContentUWP?.DateCreated ?? new DateTimeOffset();

        public object Content => ContentUWP;

        public Windows.Storage.IStorageFolder ContentUWP { get; private set; }

        public async Task<IDirectory[]> GetDirectories()
        {
            return (await ContentUWP?.GetFoldersAsync())?.Select(a => new DirectoryUWP(a)).ToArray();
        }

        public async Task<IFile[]> GetFiles()
        {
            return (await ContentUWP?.GetFilesAsync())?.Select(a => new FileUWP(a)).ToArray();
        }
    }
}
