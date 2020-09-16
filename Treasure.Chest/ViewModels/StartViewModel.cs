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

        public void GetNumbers()
        {
            RandomNumbers numbers = new RandomNumbers();

            //Visar siffrorna i en messagebox för att testa att det funkar
            MessageBox.Show(numbers.Numbers[0].ToString() + numbers.Numbers[1].ToString() + numbers.Numbers[2].ToString() + numbers.Numbers[3].ToString());
            correctAnswer = numbers.Numbers;

            MainWindow.GoToPage(new Game());
        }
        public void GetHighscore()
        {
            MainWindow.GoToPage(new Highscore());
        }
        public void GetRules()
        {
            MainWindow.GoToPage(new Rules());
        }

        public static int[] SendNumbers()
        {
            return correctAnswer;
        }

    }
}
