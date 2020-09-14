using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Views;


namespace Treasure.Chest.ViewModels
{
    class GameViewModel :INotifyPropertyChanged
    {
        //här ska vi kontrollera gissningar mot svaret
        #region Properties

        public ICommand GuessCommand { get; set; }
        
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }
       

        public int[] PlayerGuess { get; set; }
        public int[] CorrectAnswer { get; set; }

        public string Position0 { get; set; }
        public string Position1 { get; set; }
        public string Position2 { get; set; }
        public string Position3 { get; set; }
        #endregion

        public GameViewModel()
        {
            GuessCommand = new RelayCommand(CompareAnswers);
            CorrectAnswer = StartViewModel.SendNumbers();
       
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            //MessageBox.Show(PlayerGuess[0].ToString() + PlayerGuess[1].ToString() + PlayerGuess[2].ToString() + PlayerGuess[3].ToString());

            int[] checkedAnswer = new int[4];
            checkedAnswer = CheckAnswer.CorrectValueAndPosition(PlayerGuess,CorrectAnswer);
            //MessageBox.Show(checkedAnswer[0].ToString() + checkedAnswer[1].ToString() + checkedAnswer[2].ToString() + checkedAnswer[3].ToString());

            bool correctAnswer;
            correctAnswer = CheckAnswer.IsWinner(checkedAnswer);
            MessageBox.Show(correctAnswer.ToString());

            Position0 = PlayerGuess[0].ToString(); 
            Position1 = PlayerGuess[1].ToString();
            Position2 = PlayerGuess[2].ToString();
            Position3 = PlayerGuess[3].ToString();
        }



    }
}
