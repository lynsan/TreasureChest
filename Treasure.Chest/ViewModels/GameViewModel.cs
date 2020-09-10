using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Treasure.Chest.ViewModels
{
    class GameViewModel
    {
        //här ska vi kontrollera gissningar mot svaret

        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }
        public ICommand GuessCommand { get; set;}

        public int[] PlayerGuess()
        {
            int[] playerAnswer = new int[]
            {
                Num1,Num2, Num3, Num4
            };
            return playerAnswer;
        }

    }
}
