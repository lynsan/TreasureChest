using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Treasure.Chest.ViewModels;

namespace Treasure.Chest.Views
{
    /// <summary>
    /// Interaction logic for Winner.xaml
    /// </summary>
    public partial class Winner : Page
    {
        public Winner()
        {
            InitializeComponent();

            WinnerViewModel winner = new WinnerViewModel();
            DataContext = winner;
        }
    }
}
