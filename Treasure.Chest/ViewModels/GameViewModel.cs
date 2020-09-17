using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xaml.Schema;
using Treasure.Chest.Models;
using Treasure.Chest.ViewModels.Base;
using Treasure.Chest.Views;


namespace Treasure.Chest.ViewModels
{
    class GameViewModel :INotifyPropertyChanged
    {
        
        #region Properties

        public ICommand GuessCommand { get; set; }
        
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }
       
        public int[] PlayerGuess { get; set; }
        public int[] CorrectAnswer { get; set; }


        #endregion

        public ObservableCollection<Guess> Guesses { get; set; } = new ObservableCollection<Guess>();


        public GameViewModel()
        {
            GuessCommand = new RelayCommand(CompareAnswers);
            CorrectAnswer = StartViewModel.SendNumbers();

        }

        public event PropertyChangedEventHandler PropertyChanged;

 
        public void CompareAnswers()
        {

            Guess guess = new Guess()
            {
                FirstGuess = new SmallGuess { Number = Num1},
                SecondGuess = new SmallGuess { Number = Num2},
                ThirdGuess = new SmallGuess { Number = Num3},
                FourthGuess = new SmallGuess { Number = Num4}
            };
            CheckAnswer.CheckValueAndPosition(guess, CorrectAnswer);
            Guesses.Add(guess);

        }

    }
}
