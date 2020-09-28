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
        public string GameRules { get; set; } = "You are a code breaker, and your goal is to guess the secret code to open the treasure chest." +
            " The code is a sequence of numbers between 0 and 9, and note that the same number can take place several times. " +
            "In each round after you make a guess, you will get hints which will lead you closer to guessing the secret code. " +
            "Repeat this until you figure out the secret code. The hints are either GREEN background or YELLOW background: " +
            "\nGREEN background = your guess is correct and is in the correct position " +
            "\nYELLOW background = your guess is correct but is in the wrong position";

        public RulesViewModel()
        {
            BackCommand = new RelayCommand(GoToStart);
        }
        public void GoToStart()
        {
            GameViewModel.ResetScore();
            MainWindow.GoToPage(new Start());
        }
    }   
}
