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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();

            GameViewModel game = new GameViewModel();
            DataContext = game;

        }

        // Event för när texten ändras i textboxarna som autotabbar.

        private void Guess_TextChanged(object sender, TextChangedEventArgs e)
        {

            if ((sender as TextBox).MaxLength == (sender as TextBox).Text.Length)
            {
                var ue = e.OriginalSource as FrameworkElement;
                e.Handled = true;
                ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}
