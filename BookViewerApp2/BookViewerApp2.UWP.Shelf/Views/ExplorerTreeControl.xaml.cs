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
    public sealed partial class ExplorerTreeControl : UserControl
    {
        public ExplorerTreeControl()
        {
            this.InitializeComponent();
        }

        private void TreeView_Expanding(TreeView sender, TreeViewExpandingEventArgs args)
        {
            (args.Item as ViewModels.FileItemViewModel)?.LoadChildren();
        }

        private void TreeView_Collapsed(TreeView sender, TreeViewCollapsedEventArgs args)
        {
            (args.Item as ViewModels.FileItemViewModel)?.ClearChildren();
        }
    }
}
