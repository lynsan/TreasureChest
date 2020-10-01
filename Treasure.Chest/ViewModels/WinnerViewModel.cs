using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.Repositories;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Views;

namespace Treasure.Chest.ViewModels
{
    class WinnerViewModel : INotifyPropertyChanged
    {
        Player player = new Player();
        public ICommand SaveCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public string MyName { get; set; }
        public int Score { get; set; } = GameViewModel.Score;
        public string Time { get; set; } = GameViewModel.SendTimer;
        public Visibility NoName { get; set; } = Visibility.Hidden;


        public event PropertyChangedEventHandler PropertyChanged;

        public WinnerViewModel()
        {
            
            BackCommand = new RelayCommand(GoToStart);
            SaveCommand = new RelayCommand(AddPlayerAndGoHighScore);
            
        }

        public void AddPlayerAndGoHighScore()
        {
            AddPlayer();
            GameViewModel.ResetGame();
        }

        private void AddPlayer()
        {

            player.Name = MyName;
            player.Score = Score;
            player.PlayTime = Time;
            if (MyName == "")
            {
                NoName = Visibility.Visible;
            }
            else
            {
                PlayerRepository.AddPlayer(player);
                GameViewModel.ResetGame();
                MainWindow.GoToPage(new Highscore());
            }



        }
        private void GoToStart()
        {

            GameViewModel.ResetGame();
            MainWindow.GoToPage(new Start());
        }
    }
}
