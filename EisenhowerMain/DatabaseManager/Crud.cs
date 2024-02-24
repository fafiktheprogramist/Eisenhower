using System;
using System.Security.Cryptography;
using Npgsql;
namespace EisenhowerCore {
    public class DatabaseCrud {
        public static void GetTasksFromDatabase(TodoQuarter quarter) {
            const string GetAllTasksCommand = "SELECT id, title, deadline, isdone FROM {0}";
            try {
                // ukryc connection stringa bo "fired asap"
                string connectionString = "Host=localhost;Username=rafal;Password=glowacz1;Database=eisenhower";
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();

                string insertQuery = string.Format(GetAllTasksCommand);
                using var cmd = new NpgsqlCommand(insertQuery, conn);
                using var reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    int TaskID = reader.GetInt32(reader.GetOrdinal("id"));
                    string Title = reader.GetString(reader.GetOrdinal("title"));
                    DateTime DeadLine = reader.GetDateTime(reader.GetOrdinal("deadline"));
                    bool IsDone = reader.GetBoolean(reader.GetOrdinal("isDone"));

                    //downloadedTask = new TodoItem(int TaskID);
                }
                cmd.ExecuteNonQuery();
            } catch (NpgsqlException ex) {
                throw new NpgsqlException("Couldnt Get any tasks");
            }
           
        }
        public static void AddTaskToDatabase(string quarter, string title, DateTime deadline, bool isDone = false) {
            const string AddTaskCommand = "INSERT INTO {0}(title, deadline, isDone) VALUES(@title, @deadline, @isDone)";
            try {
                string connectionString = "Host=localhost;Username=rafal;Password=glowacz1;Database=eisenhower";
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                
                string insertQuery = string.Format(AddTaskCommand, quarter);
                using var cmd = new NpgsqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("title", title);
                cmd.Parameters.AddWithValue("deadline", deadline);
                cmd.Parameters.AddWithValue("isDone", isDone);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Pomyślnie dodano taska do bazy danych! <3");
            } catch (NpgsqlException ex) {
                Console.WriteLine("Error: " + ex);
            }
        }
        public void RemoveTaskFromDatabse() {
            const string AddTaskCommand = "INSERT INTO {0}(title, deadline, isDone) VALUES(@title, @deadline, @isDone)";
        }
    }
}