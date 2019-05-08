using System;
using System.Threading.Tasks;
using SharpCifs.Smb;
using System.Linq;

namespace BookViewerApp2.IO
{
    public class DirectorySmb : FileItemSmb, IDirectory
    {
        public DirectorySmb(SmbFile contentSmb) : base(contentSmb ?? throw new ArgumentNullException(nameof(contentSmb)))
        {
            if (!contentSmb.IsDirectory()) throw new ArgumentException("Argument is not Directory.");
        }

        public async Task<IDirectory[]> GetDirectories()
        {
            return (await ContentSmb?.ListFilesAsync()).Where(a => a.IsDirectory())?.Select(a => new DirectorySmb(a)).ToArray();
        }

        public async Task<IFile[]> GetFiles()
        {
            return (await ContentSmb?.ListFilesAsync()).Where(a => a.IsFile())?.Select(a => new FileSmb(a)).ToArray();
        }
    }
}
