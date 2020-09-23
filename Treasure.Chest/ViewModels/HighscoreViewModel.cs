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
        public List<Player> Players { get; set; } = new List<Player>();
        public ICommand BackCommand { get; set; }
        public List<Player> ShowPlayers { get; set; } = new List<Player>();


        public HighscoreViewModel()
        {
            PresentPlayers();

            //Test players for testing highscorepage
            Player player = new Player();
            player.Name = "bob";
            player.Score = 4;
            player.PlayTime = DateTime.Now;
            Players.Add(player);
            Player player2 = new Player();
            player2.Name = "Lisa";
            player2.Score = 6;
            player2.PlayTime = DateTime.Now;
            Players.Add(player2);

            BackCommand = new RelayCommand(GoToStart);
        }

        public void PresentPlayers()
        {
            var players = PlayerRepository.GetPlayers();

            ShowPlayers= players.ToList();

        }
    }
        public void GoToStart()
        {
            MainWindow.GoToPage(new Start());
        }
    }
    
}
