using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Repositories;
using Treasure.Chest.Views;
using System.Linq;
using System.ComponentModel;

namespace Treasure.Chest.ViewModels
{
    class HighscoreViewModel: INotifyPropertyChanged
    {
        
        public ICommand BackCommand { get; set; }
        public ICommand AllTimeCommand { get; set; }
        public ICommand SevenDaysCommand { get; set; }
        public List<Player> ShowPlayers { get; set; } = new List<Player>();


        public HighscoreViewModel()
        {
            PresentPlayers();


            BackCommand = new RelayCommand(GoToStart);
            AllTimeCommand = new RelayCommand(PresentPlayers);
            SevenDaysCommand = new RelayCommand(SortSevenDays);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SortSevenDays()
        {
            var players = PlayerRepository.GetPlayersByDate();

            ShowPlayers = players.ToList();
        }


        public void PresentPlayers()
        {
            var players = PlayerRepository.GetPlayers();

            ShowPlayers = players.ToList();

        }
    
        public void GoToStart()
        {
            MainWindow.GoToPage(new Start());
        }
    }
    
}
