using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.Models;
using Treasure.Chest.Repositories;
using Treasure.Chest.Views;
using System.Linq;


namespace Treasure.Chest.ViewModels
{
    class HighscoreViewModel
    {
        public List<Player> ShowPlayers { get; set; } = new List<Player>();


        public HighscoreViewModel()
        {
            PresentPlayers();

        }

        public void PresentPlayers()
        {
            var players = PlayerRepository.GetPlayers();

            ShowPlayers= players.ToList();

        }
    }
    
}
