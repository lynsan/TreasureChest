using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xaml.Schema;
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

        #endregion

        public ObservableCollection<Guess> Guesses { get; set; } = new ObservableCollection<Guess>();


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
            int[] checkedAnswer = new int[4];
            checkedAnswer = CheckAnswer.CheckValueAndPosition(PlayerGuess,CorrectAnswer);
            MessageBox.Show(checkedAnswer[0].ToString() + checkedAnswer[1].ToString() + checkedAnswer[2].ToString() + checkedAnswer[3].ToString());    
            Guesses.Add(new Guess()
            {
                FirstGuess = new SmallGuess { Number = Num1, CorrectType = CorrectType.CorrectNumber },
                SecondGuess = new SmallGuess { Number = Num2, CorrectType = CorrectType.CorrectNumberAndPlace },
                ThirdGuess = new SmallGuess { Number = Num3, CorrectType = CorrectType.Incorrect},
                FourthGuess = new SmallGuess { Number = Num4, CorrectType = CorrectType.CorrectNumberAndPlace }
            });

        }


    }

    public class Guess
    {
       
        public SmallGuess FirstGuess { get; set; }
        public SmallGuess SecondGuess {get; set; }
        public SmallGuess ThirdGuess {get; set; }
        public SmallGuess FourthGuess {get; set; }
    }
    public class SmallGuess
    {
        public int Number { get; set; }
        public CorrectType CorrectType { get; set; }
    }
    public enum CorrectType
    {
        CorrectNumberAndPlace,
        CorrectNumber,
        Incorrect
    }

    public class CorrectTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((CorrectType)value)
            {
                case CorrectType.CorrectNumberAndPlace:
                    return new SolidColorBrush(Colors.Green);
                case CorrectType.CorrectNumber:
                    return new SolidColorBrush(Colors.Yellow);
                case CorrectType.Incorrect:
                    return new SolidColorBrush(Colors.Transparent);

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
