using System;
using System.Collections.Generic;
using System.Text;

namespace Treasure.Chest.Interfaces
{
    public interface IPlayer
    {
        public string Name { get; set; }
        //public DateTime Time { get; set; }
        public int Score { get; set; }
       
    }
}
