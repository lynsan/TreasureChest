using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Views;

namespace Treasure.Chest.ViewModels
{
    class GameViewModel
    {
        //här ska vi kontrollera gissningar mot svaret
        public ICommand GuessCommand { get; set; }

        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }

        public int[] PlayerGuess { get; set; }
        public int[] CorrectAnswer { get; set; }


        public GameViewModel()
        {
            GuessCommand = new RelayCommand(CompareAnswers);
            CorrectAnswer = StartViewModel.SendNumbers();
        }



        public void GetPlayerGuess()
        {
            int[] playerGuess = new int[]
            {
                Num1,Num2, Num3, Num4
            };
            PlayerGuess = playerGuess; 

        }
   
        public void CompareAnswers()
        {

            GetPlayerGuess();
            //MessageBox.Show(CorrectAnswer[0].ToString() + CorrectAnswer[1].ToString() + CorrectAnswer[2].ToString() + CorrectAnswer[3].ToString());
            MessageBox.Show(PlayerGuess[0].ToString() + PlayerGuess[1].ToString() + PlayerGuess[2].ToString() + PlayerGuess[3].ToString());

        }



    }
}
