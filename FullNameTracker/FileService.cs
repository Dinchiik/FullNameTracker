namespace FullNameTracker
{
    public class FileService
    {
        private const string FileName = "txt.txt";

        public static List<(string Surname, string Name, string Patronymic)> LoadFromFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден.");
                return new List<(string, string, string)>();
            }

            var lines = File.ReadAllLines(filePath);
            var fioList = new List<(string, string, string)>();

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                if (parts.Length == 3)
                {
                    fioList.Add((parts[0], parts[1], parts[2]));
                }
            }

            return fioList;
        }
    }
}
