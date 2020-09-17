using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.Models;
using Treasure.Chest.Views;

namespace Treasure.Chest.ViewModels
{
    class HighscoreViewModel
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public HighscoreViewModel()
        {
            Player player = new Player();
            player.Name = "bob";
            player.Score = 4;
            player.Time = DateTime.Now;
            Players.Add(player);
        }

    }
    
}
