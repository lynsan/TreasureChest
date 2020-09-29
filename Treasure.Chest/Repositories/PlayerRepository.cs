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

        #region Create
        public static int AddPlayer(Player player)
        {
            string stmt = "INSERT INTO players (playername, score, playtime) values(@playername, @score, @playtime) returning id";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
               
                {
                    command.Parameters.AddWithValue("playername", player.Name);
                    command.Parameters.AddWithValue("score", player.Score);
                    command.Parameters.AddWithValue("playtime", player.PlayTime);
                    int id = (int)command.ExecuteScalar();
                    player.Id = id;
                    return id;
                }
            }
        }

        #endregion
        #region READ
       
        public static IEnumerable<Player> GetPlayers(string stmt)
        {

            using(var conn = new NpgsqlConnection(connectionString))
            {
                 Player player = null; 
                 List<Player> players = new List<Player>();
                 conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player = new Player
                            {
                                Name = (string)reader["playername"],
                                Score = (int)reader["score"],
                                PlayTime = (string)reader["playtime"],
                            };
                            players.Add(player);
                        }
                    }
                    return players;
                }
            }
        }
      
        
        #endregion
    }
}

