using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookViewerApp2.Helper
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void Set<T>(ref T member, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(member, value)) return;
            member = value;
            OnPropertyChanged(propertyName);
        }
    }
}
