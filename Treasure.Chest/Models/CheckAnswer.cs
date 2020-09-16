using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.ViewModels;

namespace Treasure.Chest.Models
{
    abstract class CheckAnswer
    {

        public static int[] CheckValueAndPosition(int[] playerGuess, int[] Numbers)
        {
            int[] playerInput = new int[4];
            for (int i = 0; i < playerGuess.Length; i++)
            {
                for (int j = 0; j < playerGuess.Length; j++)
                {
                    if (playerGuess[i] == Numbers[i])
                    {
                        playerInput[i] = 1; //correct value and position
                    }
                    else if (playerGuess[i] == Numbers[j])
                    {
                        playerInput[i] = 2; //correct value wrong position
                        break;
                    }
                    else
                    {
                        playerInput[i] = 0; //totally wrong
                    }
                }
            }
            return playerInput;
        }



    }



    }

