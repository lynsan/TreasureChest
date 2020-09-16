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
            string stmt = "INSERT INTO player(playername, score, playtime) values (@playername, @score, @playtime returning score)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                using (var reader = command.ExecuteReader())
                {
                    command.Parameters.AddWithValue("playername", player.Name);
                    command.Parameters.AddWithValue("score", player.Score);
                    command.Parameters.AddWithValue("playtime", player.PlayTime);
                    command.Parameters.AddWithValue("player_id", player.id);
                    command.ExecuteScalar();
                    int scoreValue = (int)command.ExecuteScalar();
                    return scoreValue;
                }
            }
        }

                    #endregion
                    #region READ
                    // Hämta en specifik spelare (ett objekt av typen spelare)

                    public Player GetPlayer(string playerName, int score, int playTime)
        {
            string stmt = "select playername, score, playtime from players where score=@score";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Player player = null;  
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                using (var reader = command.ExecuteReader())
                {
                    command.Parameters.AddWithValue("playername", playerName);
                    command.Parameters.AddWithValue("score", score);
                    command.Parameters.AddWithValue("playtime", playTime);

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
        public static IEnumerable<Player> GetPlayers(string playerName, int score, int playTime)
        {
            string stmt = "select playername, score, playtime from players";

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
                                PlayTime = (int)reader["playtime"],
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

