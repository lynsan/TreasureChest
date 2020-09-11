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
    class StartViewModel 
    {
        

        //public int Numbers { get; set; }
        public ICommand PlayCommand { get; set; }
        
        public static int[] correctAnswer = new int[4];

        public StartViewModel()
        {
            PlayCommand = new RelayCommand(GetNumbers);
        }
       
        public void GetNumbers()
        {

            RandomNumbers numbers = new RandomNumbers();
            //Visar siffrorna i en messagebox för att testa att det funkar
            MessageBox.Show(numbers.Numbers[0].ToString() + numbers.Numbers[1].ToString() + numbers.Numbers[2].ToString() + numbers.Numbers[3].ToString());
            correctAnswer = numbers.Numbers;
            //correctAnswer[0] = numbers.Numbers[0];
            //correctAnswer[1] = numbers.Numbers[1];
            //correctAnswer[2] = numbers.Numbers[2];
            //correctAnswer[3] = numbers.Numbers[3];
            
            MainWindow.GoToPage(new Game());
        }

        public static int[] SendNumbers()
        {
            return correctAnswer;
        }

    }
}
