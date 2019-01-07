using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ASP_CRUD.Models;

namespace ASP_CRUD
{
    public class ActivityRepository
    {
        public static string connectionString { get; set; }

        public static Activity GetActivityById(int id)
        {
            var conn = new MySqlConnection(connectionString);
            var a = new Activity();

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT creator, name FROM activities WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    a.Id = id;
                    a.Creator = (int)reader["creator"];
                    a.ActivityName = reader["name"].ToString();
                }

                return a;
            }
        }

        public static List<Activity> GetActivities()
        {
            var conn = new MySqlConnection(connectionString);
            var activities = new List<Activity>();

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, creator, name FROM activities ORDER BY name;";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var a = new Activity()
                    {
                        Id = (int)reader["id"],
                        Creator = (int)reader["creator"],
                        ActivityName = reader["name"].ToString()
                    };

                    activities.Add(a);
                }

                return activities;
            }
        }

        public static int CreateActivity(Activity a)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO activities (creator, name) " +
                    "VALUES (@creator, @name);";
                cmd.Parameters.AddWithValue("creator", a.Creator);
                cmd.Parameters.AddWithValue("name", a.ActivityName);

                return cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteActivity(int id)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM activities WHERE id = @id;";
                cmd.Parameters.AddWithValue("id", id);

                return cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateActivity(Activity a)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE activities SET creator = @creator, name = @name WHERE id = @id";
                cmd.Parameters.AddWithValue("creator", a.Creator);
                cmd.Parameters.AddWithValue("name", a.ActivityName);
                cmd.Parameters.AddWithValue("id", a.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
