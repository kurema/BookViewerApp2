﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.IO;

namespace BookViewerApp2.Book
{
    public class BookCompress : IBook
    {
        public BookCompress(System.IO.Stream stream, bool naturalOrder, bool coverFirst)
        {
            Task.Run(async () => { await LoadAsync(stream, naturalOrder, coverFirst); });
        }

        public BookCompress()
        {
        }

        public string ID => _ID = _ID ?? GetID();
        string _ID = null;
        private string GetID()
        {
            return Entries?.OrderBy(a => a.Key)?.Aggregate("", (a, b) => a + Helper.Functions.CombineStringAndDouble(b.Key, b.Size));
        }

        public event EventHandler Loaded;
        private void OnLoaded() => Loaded?.Invoke(this, new EventArgs());
        private SharpCompress.Archives.IArchiveEntry[] Entries;

        public async Task LoadAsync(System.IO.Stream stream, bool naturalOrder, bool coverFirst)
        {
            SharpCompress.Archives.IArchive archive;

            await Task.Run(() =>
            {
                try
                {
                    archive = SharpCompress.Archives.ArchiveFactory.Open(stream);
                    var entries = archive.Entries.Where(entry => !entry.IsDirectory && !entry.IsEncrypted &&
                    Manager.Image.AvailableExtensions.Contains(System.IO.Path.GetExtension(entry.Key).ToLower()));
                    var order = naturalOrder ? entries.OrderBy(a => new Helper.NaturalSort.NaturalList(a.Key)) : entries.OrderBy(a => a.Key);
                    Entries = coverFirst ? order.ThenBy(a => a.Key.ToLower().Contains("cover")).ToArray() : order.ToArray();
                    OnLoaded();
                }
                catch
                {
                    this.Entries = new SharpCompress.Archives.IArchiveEntry[0];
                }
            });
        }
        public IEnumerator<IPage> GetEnumerator()
        {
            return Entries.Select(a => new PageCompress(a)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class PageCompress : IPageStream
    {
        SharpCompress.Archives.IArchiveEntry Entry;
        public PageCompress(SharpCompress.Archives.IArchiveEntry entry)
        {
            Entry = entry;
        }

        Stream _Stream;
        public Stream Stream => _Stream = _Stream ?? Entry.OpenEntryStream();
    }

    public class ManagerCompress : Manager.Viewer.IBookManager
    {
        public string[] Extensions => new[] { ".cbz", ".cbr", ".rar", ".zip", ".7z", ".cb7" };

    }
}
