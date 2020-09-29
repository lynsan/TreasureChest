﻿using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.Interfaces;

namespace Treasure.Chest.Models
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string PlayTime { get; set; }
       
    }
}
