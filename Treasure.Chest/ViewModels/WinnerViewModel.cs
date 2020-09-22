using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.Repositories;
using Treasure.Chest.ViewModels.Base;

namespace Treasure.Chest.ViewModels
{
    class WinnerViewModel : INotifyPropertyChanged
    {
        Player player= new Player();
        public string MyName { get; set; }
        public ICommand SaveCommand { get; set; }

        public int Score { get; set; } = GameViewModel.Score;


        public event PropertyChangedEventHandler PropertyChanged;

        public WinnerViewModel()
        {
            SaveCommand = new RelayCommand(AddPlayer);
        }


        public void AddPlayer()
        {


            player.Name = MyName;
            player.Score=GameViewModel.GetScore(); 
            PlayerRepository.AddPlayer(player);
        }
    }
}
