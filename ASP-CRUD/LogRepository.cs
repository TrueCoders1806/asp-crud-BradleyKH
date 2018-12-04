using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ASP_CRUD.Models;

namespace ASP_CRUD
{
    public class LogRepository
    {
        public static string connectionString { get; set; }

        public static List<Log> GetLogs()
        {
            var conn = new MySqlConnection(connectionString);
            var logs = new List<Log>();

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, creator, date, activity, amount FROM logs;";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var l = new Log()
                    {
                        Id = (int)reader["id"],
                        Creator = (int)reader["creator"],
                        Date = Convert.ToDateTime(reader["date"]),
                        Activity = (int)reader["activity"],
                        Amount = (int)reader["amount"]
                    };

                    logs.Add(l);
                }

                return logs;
            }
        }

        public static int CreateLog(Log l)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO logs (creator, date, activity, amount) " +
                    "VALUES (@creator, @date, @activity, @amount);";
                cmd.Parameters.AddWithValue("creator", l.Creator);
                cmd.Parameters.AddWithValue("date", l.Date);
                cmd.Parameters.AddWithValue("activity", l.Activity);
                cmd.Parameters.AddWithValue("amount", l.Amount);

                return cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteLog(int id)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM logs WHERE id = @id;";
                cmd.Parameters.AddWithValue("id", id);

                return cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateLog(Log l)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE logs SET creator = @creator, date = @date, activity = @activity, " +
                    "amount = @amount WHERE id = @id";
                cmd.Parameters.AddWithValue("creator", l.Creator);
                cmd.Parameters.AddWithValue("date", l.Date);
                cmd.Parameters.AddWithValue("activity", l.Activity);
                cmd.Parameters.AddWithValue("amount", l.Amount);
                cmd.Parameters.AddWithValue("id", l.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
