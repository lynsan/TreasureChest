using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Treasure.Chest.Models;




namespace Treasure.Chest.Repositories
{
    class PlayerRepository
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["sup_db8"].ConnectionString;

        // Hämta en specifik spelare (ett objekt av typen spelare)

        //public Player GetPlayer(string playerName, int score, int playTime, DateTime date)
        //{

        //}
    }
}
