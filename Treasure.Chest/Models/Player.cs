using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.Interfaces;

namespace Treasure.Chest.Models
{
    public class Player : IPlayer
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Time { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Score { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
