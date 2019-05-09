using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Windows.Input;

namespace BookViewerApp2.Helper
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _Command;
        private Func<object, bool> _CanExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> command, Func<object, bool> canExecute = null)
        {
            _Command = command ?? throw new ArgumentNullException(nameof(command));
            _CanExecute = canExecute;
        }

        void ICommand.Execute(object parameter) => _Command?.Invoke(parameter);
        bool ICommand.CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, new EventArgs());
    }
}
