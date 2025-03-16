using Npgsql;

namespace FullNameTracker
{
    public class Database
    {
        private const string ConnectionString = "Host=localhost;Port=5433;Database=NameRepository;Username=postgres;Password=12345";

        public static void ExecuteNonQuery(string sql, params object[] args)
        {
            using var connect = new NpgsqlConnection(ConnectionString);
            connect.Open();

            using var cmd = new NpgsqlCommand(sql, connect);
            for (int i = 0; i < args.Length; i++)
            {
                cmd.Parameters.AddWithValue($"@p{i}", args[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static List<(string Surname, string Name, string Patronymic)> ExecuteQuery(string sql, params object[] args)
        {
            using var connect = new NpgsqlConnection(ConnectionString);
            connect.Open();

            using var cmd = new NpgsqlCommand(sql, connect);
            for (int i = 0; i < args.Length; i++)
            {
                cmd.Parameters.AddWithValue($"@p{i}", args[i]);
            }

            using var read = cmd.ExecuteReader();
            var results = new List<(string, string, string)>();
            while (read.Read())
            {
                results.Add((read.GetString(0), read.GetString(1), read.GetString(2)));
            }
            return results;
        }
    }
}
