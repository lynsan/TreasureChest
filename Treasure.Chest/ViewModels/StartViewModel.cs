using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Treasure.Chest.Models;
using Treasure.Chest.ViewModels.Base;

namespace Treasure.Chest.ViewModels
{
    class StartViewModel
    {
        public ICommand PlayCommand { get; set; }

        public StartViewModel()
        {
            PlayCommand = new RelayCommand(GetNumbers);
        }

        public void GetNumbers()
        {
            RandomNumbers numbers = new RandomNumbers();

            //Visar siffrorna i en messagebox för att testa att det funkar
            MessageBox.Show(numbers.Numbers[0].ToString() + numbers.Numbers[1].ToString() + numbers.Numbers[2].ToString() + numbers.Numbers[3].ToString());
        }
    }
}
