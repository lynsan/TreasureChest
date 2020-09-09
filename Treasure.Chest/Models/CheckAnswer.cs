using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.ViewModels;

namespace Treasure.Chest.Models
{
    abstract class CheckAnswer
    {
        //metoden för att kontrollera om gissningen stämmer överens med rätt svar

        //RandomNumbers randomNumbers = new RandomNumbers();
        //GameViewModel playerAnswer = new GameViewModel();

        
        public static bool CorrectValueAndPosition(int[] playerGuess, int [] Numbers)

        {
            for (int i = 0; i < playerGuess.Length;)
            {
                if (playerGuess[i] == Numbers[i])
                {
                    return true; //Byt färg på bakgrunden
                }

            }

            return false;
        }
        public static bool CorrectValueWrongPosition(int[] playerGuess, int[] Numbers)
        {
            if (playerGuess[0] != Numbers[0])
            {

            }

            return true;
        }

        

    }



    }

