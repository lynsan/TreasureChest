using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Views;

namespace Treasure.Chest.ViewModels
{
    class StartViewModel
    {
        #region Properties

        public ICommand PlayCommand { get; set; }
        public ICommand HighscoreCommand { get; set; }
        public ICommand RulesCommand { get; set; }

        #endregion

        public static int[] correctAnswer = new int[4];

        public StartViewModel()
        {
            PlayCommand = new RelayCommand(GetNumbers);
            HighscoreCommand = new RelayCommand(GetHighscore);
            RulesCommand = new RelayCommand(GetRules);
        }

        private void GetNumbers()
        {
            RandomNumbers numbers = new RandomNumbers();
            correctAnswer = numbers.Numbers;
            MainWindow.GoToPage(new Game());
        }

        private void GetHighscore()
        {
            MainWindow.GoToPage(new Highscore());
        }

        private void GetRules()
        {
            MainWindow.GoToPage(new Rules());
        }

        //Skickar det rätta svaret
        public static int[] SendNumbers()
        {
            return correctAnswer;
        }

    }
}
