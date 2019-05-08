using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq;

namespace BookViewerApp2.IO
{
    public class DirectoryCombined : IDirectory
    {
        public DirectoryCombined(params IDirectory[] contentDirectories)
        {
            ContentDirectories = contentDirectories ?? throw new ArgumentNullException(nameof(contentDirectories));

        }

        public DirectoryCombined(IDirectory[] contentDirectories, string name)
        {
            ContentDirectories = contentDirectories ?? throw new ArgumentNullException(nameof(contentDirectories));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public IDirectory[] ContentDirectories { get; private set; }

        public string Name { get; set; }

        public DateTimeOffset DateTime => ContentDirectories.Max(a => a.DateTime);

        public object Content => ContentDirectories;

        public async Task<IDirectory[]> GetDirectories()
        {
            return (await Task.WhenAll(ContentDirectories.Select(async a => await a.GetDirectories()))).SelectMany(a => a)
                .GroupBy(a => a.Name).Select(a =>
                {
                    var list = a.ToArray();
                    if (a.Count() == 1) return list[0];
                    else if (a.Count() == 0) return null;
                    else return new DirectoryCombined(list, a.Key);
                }).Where(a => a != null).ToArray();
        }

        public async Task<IFile[]> GetFiles()
        {
            return (await Task.WhenAll(ContentDirectories.Select(async a => await a.GetFiles()))).SelectMany(a => a).ToArray();
        }
    }
}
