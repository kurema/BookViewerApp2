using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// ユーザー コントロールの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234236 を参照してください

namespace BookViewerApp2.Views
{
    public sealed partial class PageViewControl : UserControl
    {
        public Image Image => this.ImageMain;

        DispatcherTimer _SizeChangedTimer;

        public ViewModels.PageViewModel ViewModel
        {
            get => (ViewModels.PageViewModel)(this.DataContext = this.DataContext ?? new ViewModels.PageViewModel());
            set => this.DataContext = value;
        }
        public PageViewControl()
        {
            this.InitializeComponent();

            _SizeChangedTimer = new DispatcherTimer();
            _SizeChangedTimer.Tick += SizeChangedTimerTick;

            ViewModel.Control = this;
            this.SizeChanged += (s, e) =>
            {
                _SizeChangedTimer.Interval = TimeSpan.FromSeconds(0.3);
                _SizeChangedTimer.Start();
            };
        }

        private async void SizeChangedTimerTick(object sender, object e)
        {
            (sender as DispatcherTimer)?.Stop();
            await ViewModel.UpdateImage();
        }
    }
}
