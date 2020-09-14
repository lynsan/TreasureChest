using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.ViewModels;

namespace Treasure.Chest.Models
{
    abstract class CheckAnswer
    {
        //metoden för att kontrollera om gissningen stämmer överens med rätt svar
  
        public static int[] CorrectValueAndPosition(int[] playerGuess, int [] Numbers)

        {
            for (int i = 0; i < playerGuess.Length; i++)
            {
                if (playerGuess[i] == Numbers[i])
                {
                    playerGuess[i] = 1;
                }
                else 
                { 
                    playerGuess[i] = 0;
                }
            }
            return playerGuess;
        }
        public static int[] CorrectValueWrongPosition(int[] playerGuess, int[] Numbers)
        {
            int[] correctValueWrongPosition = new int[4];
            for (int i = 0; i < playerGuess.Length; i++)
            {
                for (int j = 0; j < playerGuess.Length; j++)
                {
                    if (playerGuess[i] == Numbers[j])
                    {
                        correctValueWrongPosition[i] = 1;
                        break;
                    }
                    else
                    {
                        correctValueWrongPosition[i] = 0;
                    }
                }
            }
            return correctValueWrongPosition;
        }



    }



    }

