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
            int[] checkValueAndPosition = new int[4];
            for (int i = 0; i < playerGuess.Length; i++)
            {
                for (int j = 0; j < playerGuess.Length; j++)
                {
                    if (playerGuess[i] == Numbers[i])
                    {
                        checkValueAndPosition[i] = 1; //correct value and position
                    }
                    else if (playerGuess[i] == Numbers[j])
                    {
                        checkValueAndPosition[i] = 2; //correct value wrong position
                        break;
                    }
                    else
                    {
                        checkValueAndPosition[i] = 0; //totally wrong
                    }
                }
            }
            return checkValueAndPosition;
        }



    }



    }

