﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookViewerApp2.Init
{
    public static class Common
    {
        public static void Init()
        {
            InitManagerImage();
            InitManagerBook();
        }

        public static void InitManagerImage()
        {
            Manager.Image.AvailableExtensions = new string[] { ".jpg", ".jpeg", ".gif", ".png" };
        }

        public static void InitManagerBook()
        {
            Manager.Book.AvailableBookManager = new[] { new Book.ManagerCompress() };
        }
    }
}
