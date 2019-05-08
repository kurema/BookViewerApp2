using System;
using SharpCifs.Smb;

namespace BookViewerApp2.IO
{
    public abstract class FileItemSmb : IFileItem
    {
        protected FileItemSmb(SmbFile contentSmb)
        {
            ContentSmb = contentSmb ?? throw new ArgumentNullException(nameof(contentSmb));
        }

        public virtual SmbFile ContentSmb { get; protected set; }

        public virtual string Name => System.IO.Path.GetFileNameWithoutExtension(ContentSmb?.GetName() ?? "");

        public virtual DateTimeOffset DateTime => new DateTimeOffset(ContentSmb?.GetLastModified() ?? 0, TimeSpan.Zero);

        public virtual object Content => ContentSmb;
    }
}
