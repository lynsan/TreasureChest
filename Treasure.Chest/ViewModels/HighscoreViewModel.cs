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
            string stmt = "SELECT playername, score, playtime FROM players WHERE playdate >= current_date - 7 order by score asc, playtime asc limit 10";
            var players = PlayerRepository.GetPlayers(stmt);

            ShowPlayers = players.ToList();
        }


        public void PresentPlayers()
        {
            string stmt = "SELECT playername, score, playtime FROM players order by score asc, playtime asc limit 10";
            var players = PlayerRepository.GetPlayers(stmt);

            ShowPlayers = players.ToList();

        }
    
        public void GoToStart()
        {
            MainWindow.GoToPage(new Start());
        }
    }
    
}
