using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.Interfaces;

namespace Treasure.Chest.Models
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int Score { get; set; }
    }
}
