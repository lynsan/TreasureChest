using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
        public string MyName { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public int Score { get; set; } = GameViewModel.Score;


        public event PropertyChangedEventHandler PropertyChanged;

        public WinnerViewModel()
        {
            
            BackCommand = new RelayCommand(GoToStart);
            SaveCommand = new RelayCommand(AddPlayerAndGoHighScore);
            
        }


        public void AddPlayerAndGoHighScore()
        {
            AddPlayer();
            GoToHighscore();
        
        }

        public void AddPlayer()
        {

            player.Name = MyName;
            player.Score=GameViewModel.GetScore(); 
            PlayerRepository.AddPlayer(player);
            GameViewModel.ResetScore();
           
        }
        private void GoToStart()
        {
            MainWindow.GoToPage(new Start());

            
        }
        public void GoToHighscore()
        {
            MainWindow.GoToPage(new Highscore());
        }
    }
}
