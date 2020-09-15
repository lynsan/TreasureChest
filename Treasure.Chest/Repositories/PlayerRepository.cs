using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Treasure.Chest.Models;
using Npgsql;





namespace Treasure.Chest.Repositories
{
    class PlayerRepository
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["sup_db8"].ConnectionString;

        // Hämta en specifik spelare (ett objekt av typen spelare)

        public Player GetPlayer(string playerName, int score, int playTime)
        {
            string stmt = "playername, score, playtime";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Player player = null;  
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        player = new Player
                        {
                            Name = (string)reader["playername"],
                            Score = (int)reader["score"],
                            PlayTime = (int)reader["playtime"],
                        };
                    }
                }  
                return player;
            }
        }
    }
}
