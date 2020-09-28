using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Repositories;
using Treasure.Chest.Views;
using System.Linq;


namespace Treasure.Chest.ViewModels
{
    class HighscoreViewModel
    {
        
        public ICommand BackCommand { get; set; }
        public List<Player> ShowPlayers { get; set; } = new List<Player>();


        public HighscoreViewModel()
        {
            PresentPlayers();


            BackCommand = new RelayCommand(GoToStart);
        }

        public void PresentPlayers()
        {
            var players = PlayerRepository.GetPlayers();

            ShowPlayers = players.ToList();

        }
    
        public void GoToStart()
        {
            GameViewModel.ResetScore();
            MainWindow.GoToPage(new Start());
        }
    }
    
}
