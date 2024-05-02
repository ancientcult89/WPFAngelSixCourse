using System;
using System.Windows.Input;

namespace Fasetto.Word.ViewModels.Base
{
    public class RelayCommand : ICommand
    {
        private Action mAction;
        /// <summary>
        /// the event thats fired then the CanExecute values has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
