using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ASP_CRUD.Models;

namespace ASP_CRUD
{
    public class RoutineRepository
    {
        public static string connectionString { get; set; }

        public static Routine GetRoutineById(int id)
        {
            var conn = new MySqlConnection(connectionString);
            var r = new Routine();

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT creator, name, activities FROM routines WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    r.Id = id;
                    r.Creator = (int)reader["creator"];
                    r.RoutineName = reader["name"].ToString();
                    r.Activities = reader["activities"].ToString();
                }

                return r;
            }
        }

        public static List<Routine> GetRoutines()
        {
            var conn = new MySqlConnection(connectionString);
            var routines = new List<Routine>();

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, creator, name, activities FROM routines ORDER BY name;";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var r = new Routine()
                    {
                        Id = (int)reader["id"],
                        Creator = (int)reader["creator"],
                        RoutineName = reader["name"].ToString(),
                        Activities = reader["activities"].ToString()
                    };

                    routines.Add(r);
                }

                return routines;
            }
        }

        public static int CreateRoutine(Routine r)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO routines (creator, name, activities) " +
                    "VALUES (@creator, @name, @activities);";
                cmd.Parameters.AddWithValue("creator", r.Creator);
                cmd.Parameters.AddWithValue("name", r.RoutineName);
                cmd.Parameters.AddWithValue("activities", r.Activities);

                return cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteRoutine(int id)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM routines WHERE id = @id;";
                cmd.Parameters.AddWithValue("id", id);

                return cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateRoutine(Routine r)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE routines SET creator = @creator, name = @name, activities = @activities " +
                    "WHERE id = @id";
                cmd.Parameters.AddWithValue("creator", r.Creator);
                cmd.Parameters.AddWithValue("name", r.RoutineName);
                cmd.Parameters.AddWithValue("activities", r.Activities);
                cmd.Parameters.AddWithValue("id", r.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
