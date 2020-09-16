using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.ViewModels;

namespace Treasure.Chest.Models
{
    public class Guess
    {
        public SmallGuess FirstGuess { get; set; }
        public SmallGuess SecondGuess { get; set; }
        public SmallGuess ThirdGuess { get; set; }
        public SmallGuess FourthGuess { get; set; }
    }
}
