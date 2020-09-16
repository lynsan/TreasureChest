using System;
using System.Collections.Generic;
using System.Text;
using Treasure.Chest.ViewModels;

namespace Treasure.Chest.Models
{
    abstract class CheckAnswer
    {

        public static void CheckValueAndPosition(Guess guess, int[] numbers)
        {
            #region FirstGuess
            if (guess.FirstGuess.Number == numbers[0])
            {
                guess.FirstGuess.CorrectType = CorrectType.CorrectNumberAndPlace;
            }
            else if(guess.FirstGuess.Number == numbers[1] || guess.FirstGuess.Number == numbers[2] || guess.FirstGuess.Number == numbers[3])
            {
                guess.FirstGuess.CorrectType = CorrectType.CorrectNumber;
            }
            else
            {
               guess.FirstGuess.CorrectType = CorrectType.Incorrect;
            }
            #endregion

            #region SecondGuess
            if (guess.SecondGuess.Number == numbers[1])
            {
                guess.SecondGuess.CorrectType = CorrectType.CorrectNumberAndPlace;
            }
            else if (guess.SecondGuess.Number == numbers[0] || guess.SecondGuess.Number == numbers[2] || guess.SecondGuess.Number == numbers[3])
            {
                guess.SecondGuess.CorrectType = CorrectType.CorrectNumber;
            }
            else
            {
                guess.SecondGuess.CorrectType = CorrectType.Incorrect;
            }
            #endregion

            #region ThirdGuess
            if (guess.ThirdGuess.Number == numbers[2])
            {
                guess.ThirdGuess.CorrectType = CorrectType.CorrectNumberAndPlace;
            }
            else if (guess.ThirdGuess.Number == numbers[0] || guess.ThirdGuess.Number == numbers[1] || guess.ThirdGuess.Number == numbers[3])
            {
                guess.ThirdGuess.CorrectType = CorrectType.CorrectNumber;
            }
            else
            {
                guess.ThirdGuess.CorrectType = CorrectType.Incorrect;
            }
            #endregion

            #region FourthGuess
            if (guess.FourthGuess.Number == numbers[3])
            {
                guess.FourthGuess.CorrectType = CorrectType.CorrectNumberAndPlace;
            }
            else if (guess.FourthGuess.Number == numbers[1] || guess.FourthGuess.Number == numbers[2] || guess.FourthGuess.Number == numbers[0])
            {
                guess.FourthGuess.CorrectType = CorrectType.CorrectNumber;
            }
            else
            {
                guess.FourthGuess.CorrectType = CorrectType.Incorrect;
            }
            #endregion
        }



    }



}

