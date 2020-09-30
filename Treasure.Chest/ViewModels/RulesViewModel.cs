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
        public string GameRules { get; set; } = "You are a code breaker!" +
            "\nYour goal is to guess the secret code to open the treasure chest." +
            "\n" +
            " \nThe code is a sequence of numbers between 0 and 9, and note that the same number can take place several times. " +
            "After you make a guess, you will get hints which will lead you closer to guessing the secret code. " +
            "\n" +
            "\nGREEN background = your guess is correct and is in the correct position " +
            "\nYELLOW background = your guess is correct but is in the wrong position";

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
