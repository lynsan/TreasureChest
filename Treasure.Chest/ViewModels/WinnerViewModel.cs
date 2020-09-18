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


        public event PropertyChangedEventHandler PropertyChanged;

        public WinnerViewModel()
        {
            SaveCommand = new RelayCommand(AddPlayerName);
        }


        public void AddPlayerName()
        {
            player.Name = MyName;
            PlayerRepository.AddPlayer(player);

        }
    }
}
