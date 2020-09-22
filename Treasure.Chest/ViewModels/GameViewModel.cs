using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
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
        public ICommand BackCommand { get; set; }
        public ICommand RulesCommand { get; set; }

        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }
       
        public int[] PlayerGuess { get; set; }
        public int[] CorrectAnswer { get; set; }
        public static int Score { get; set; } = 0;


        #endregion

    
        public ObservableCollection<Guess> Guesses { get; set; } = new ObservableCollection<Guess>();


        public GameViewModel()
        {
            GuessCommand = new RelayCommand(CompareAnswers);
            CorrectAnswer = StartViewModel.SendNumbers();
            BackCommand = new RelayCommand(GoToStart);
            RulesCommand = new RelayCommand(ShowRules);
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
            Score++;
            GetPlayerGuess();
            Guess guess = new Guess()
            {
                FirstGuess = new SmallGuess { Number = Num1},
                SecondGuess = new SmallGuess { Number = Num2},
                ThirdGuess = new SmallGuess { Number = Num3},
                FourthGuess = new SmallGuess { Number = Num4}
            };
            CheckAnswer.CheckValueAndPosition(guess, CorrectAnswer);
            Guesses.Add(guess);
            IsWinner();
            RegistratePlayer();

            
        }
       public bool IsWinner()
        {

            for (int i = 0; i < PlayerGuess.Length; i++)
            {
                if (PlayerGuess[i] == CorrectAnswer[i])
                {
                    
                }
                else
                {
                    return false;
                }
            }return true;

            
        }

        public void RegistratePlayer()
        {
            
            if (IsWinner()== true)
            {
                MainWindow.GoToPage(new Winner());
            }
        }

        public void GoToStart()
        {
            MainWindow.GoToPage(new Start());
        }

        
        public static int GetScore()
        {

          return Score;
        }
        public void ShowRules()
        {
            MainWindow.GoToPage(new Rules());
        }
       

    }
}
