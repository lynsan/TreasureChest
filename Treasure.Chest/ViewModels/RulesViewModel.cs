using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Views;

namespace Treasure.Chest.ViewModels
{
    class RulesViewModel
    {
        public ICommand BackCommand { get; set; }
        public RulesViewModel()
        {
            BackCommand = new RelayCommand(GoToStart);
        }
        public void GoToStart()
        {
            MainWindow.GoToPage(new Start());
        }
    }   
}
