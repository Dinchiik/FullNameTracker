namespace FullNameTracker
{
    public class FioService
    {
        public static void LoadDataToDb()
        {
            var fioList = FileService.LoadFromFile();
            foreach (var (surname, name, patronymic) in fioList)
            {
                Database.ExecuteNonQuery("INSERT INTO archive (surname, name, patronymic) VALUES (@p0, @p1, @p2) ON CONFLICT DO NOTHING",
                    surname, name, patronymic);
            }
        }

        public static List<(string, string, string)> FindFIO(string query)
        {
            return Database.ExecuteQuery("SELECT surname, name, patronymic FROM archive WHERE surname ILIKE @p0 OR name ILIKE @p0 OR patronymic ILIKE @p0", $"%{query}%");
        }

        public static void AddFIO(string input)
        {
            var parts = input.Split(' ');
            if (parts.Length != 3)
            {
                Console.WriteLine("Ошибка: ФИО должно состоять из 3 слов.");
                return;
            }

            var (surname, name, patronymic) = (parts[0], parts[1], parts[2]);
            Database.ExecuteNonQuery("INSERT INTO archive (surname, name, patronymic) VALUES (@p0, @p1, @p2)", surname, name, patronymic);
            Console.WriteLine($"Добавлено: {surname} {name} {patronymic}");
        }

        public static void DeleteFIO(string input)
        {
            var parts = input.Split(' ');
            if (parts.Length != 3)
            {
                Console.WriteLine("Ошибка: ФИО должно состоять из 3 слов.");
                return;
            }

            Database.ExecuteNonQuery("DELETE FROM archive WHERE surname = @p0 AND name = @p1 AND patronymic = @p2", parts[0], parts[1], parts[2]);
            Console.WriteLine($"Удалено: {input}");
        }
    }
}
