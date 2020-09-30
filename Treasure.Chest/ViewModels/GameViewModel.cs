using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;
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


        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Input3 { get; set; }
        public string Input4 { get; set; }
        public Visibility VisibilityNotNumber { get; set; } = Visibility.Hidden;

        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }
       
        public int[] CorrectAnswer { get; set; }
        public static int Score { get; set; } = 0;
        public string NumberOfTries { get; set;}

        public int Timer { get; set; } = 0;
        public string ShowTimer { get; set; }
        public static string SendTimer { get; set; }

        DispatcherTimer timer = new DispatcherTimer();
        public ObservableCollection<Guess> Guesses { get; set; } = new ObservableCollection<Guess>();

        #endregion

    

        public GameViewModel()
        {
            GuessCommand = new RelayCommand(CompareAnswers);
            CorrectAnswer = StartViewModel.SendNumbers();
            BackCommand = new RelayCommand(GoToStart);
            RulesCommand = new RelayCommand(ShowRules);
            StartTimer();
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
     
        //Metod som kollar input i textboxarna och använder tryparse för att göra om 
        //string properties till int properties. Om input är bokstav så returnerar den false. 
        public bool IsNumber()
        {
            //Försöker lägga Input1 i num1 som en int
            if (int.TryParse(Input1, out int num1))
            {
                Num1 = num1;

                if (int.TryParse(Input2, out int num2))
                {
                    Num2 = num2;

                    if (int.TryParse(Input3, out int num3))
                    {
                        Num3 = num3;

                        if (int.TryParse(Input4, out int num4))
                        {
                            Num4 = num4;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
               return false;
            }
            return true;
        }

        // Anropar Checkinput och om det är nummer så fortsätter den in i metoden, annars räknas inte
        // försöket och labeln kommer upp (du får endast skriva nummer.)
        public void CompareAnswers()
        {
            if (IsNumber())
            {
                VisibilityNotNumber = Visibility.Hidden;
                Score++;
                ShowNumberOfTries();
                Guess guess = new Guess()
                {
                    FirstGuess = new SmallGuess { Number = Num1},
                    SecondGuess = new SmallGuess { Number = Num2},
                    ThirdGuess = new SmallGuess { Number = Num3},
                    FourthGuess = new SmallGuess { Number = Num4}
                };
                CheckAnswer.CheckValueAndPosition(guess, CorrectAnswer);
                Guesses.Add(guess);
                ClearInput();
                RegistratePlayer(guess);
            }
            else
            {
                VisibilityNotNumber = Visibility.Visible;
            }
           
            
        }

       public bool IsWinner(Guess guess)
        {
            if (guess.FirstGuess.CorrectType == CorrectType.CorrectNumberAndPlace
                && guess.SecondGuess.CorrectType == CorrectType.CorrectNumberAndPlace 
                && guess.ThirdGuess.CorrectType == CorrectType.CorrectNumberAndPlace 
                && guess.FourthGuess.CorrectType == CorrectType.CorrectNumberAndPlace)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        public void RegistratePlayer(Guess guess)
        {
            
            if (IsWinner(guess)== true)
            {
                StopTimer();
                MainWindow.GoToPage(new Winner());
            }
           
        }

        public void GoToStart()
        {
            MainWindow.GoToPage(new Start());
            ResetGame();
        }

        public static void ResetGame()
        {
            Score = 0;
            SendTimer = "";
        }

        //Metod som rensar textboxarna
        public void ClearInput()
        {
            Input1 = "";
            Input2 = "";
            Input3 = "";
            Input4 = "";
        }
       
        public void ShowNumberOfTries()
        {
            NumberOfTries = $"Number Of Tries: {Score}";
        }

        public void ShowRules()
        {
            GameViewModel.ResetGame();
            MainWindow.GoToPage(new Rules());
        }

        public void StartTimer ()
        {

            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += Timer_Tick;
            timer.Start(); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer++;
            ShowTimer = string.Format("{0:mm\\:ss}", TimeSpan.FromSeconds(this.Timer).Duration());
            SendTimer = ShowTimer;
        }

        public void StopTimer()
        {
            timer.Stop();
        }
 
    }
}
