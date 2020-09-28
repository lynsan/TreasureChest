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

        }

        private void AddPlayer()
        {

            player.Name = MyName;
            player.Score = Score;
            try
            {
                PlayerRepository.AddPlayer(player);
                GameViewModel.ResetScore();
                MainWindow.GoToPage(new Highscore());
            }
            catch (Exception)
            {
                NoName = Visibility.Visible;
            }
           
        }
        private void GoToStart()
        {

            GameViewModel.ResetScore();
            MainWindow.GoToPage(new Start());
        }
    }
}
