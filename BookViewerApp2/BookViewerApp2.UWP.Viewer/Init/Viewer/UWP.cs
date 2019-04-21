using System;
using System.Collections.Generic;
using System.Text;

namespace BookViewerApp2.Init.Viewer
{
    public static class UWP
    {
        public static void Init()
        {
            InitManagerImage();
            InitManagerBook();
        }

        public static void InitManagerImage()
        {
            Manager.Image.AvailableExtensions = new string[] { ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".tiff", ".tif", ".hdp", ".wdp", ".jxr" };
        }

        public static void InitManagerBook()
        {
            Manager.Viewer.Common.AvailableBookManager = Manager.Viewer.UWP.AvailableBookManager = new Manager.Viewer.IBookManagerUWP[] { new Book.ManagerCompressUWP(), new Book.ManagerPdf() };
        }
    }
}
