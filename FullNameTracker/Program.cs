using FullNameTracker;

class Program
{
    static void Main()
    {
        Console.WriteLine("Загрузка данных из файла...");
        FioService.LoadDataToDb();
        Console.WriteLine("Данные загружены в базу данных!");

        while (true)
        {
            Console.WriteLine("\nВведите команду (find, add, delete, exit): ");
            var cmd = Console.ReadLine();
            if (cmd == "exit") break;

            else if (cmd == "find")
            {
                Console.Write("Введите полное ФИО или его часть (например, первые буквы): ");
                string query = Console.ReadLine();
                var results = FioService.FindFIO(query);

                if (results.Count == 0)
                {
                    Console.WriteLine("Ничего не найдено.");
                }
                else
                {
                    Console.WriteLine("Результаты:");
                    foreach (var (surname, name, patronymic) in results)
                    {
                        Console.WriteLine($"{surname} {name} {patronymic}");
                    }
                }
            }
            else if (cmd == "add")
            {
                Console.Write("Введите ФИО: ");
                FioService.AddFIO(Console.ReadLine());
            }
            else if (cmd == "delete")
            {
                Console.Write("Введите ФИО для удаления: ");
                FioService.DeleteFIO(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Неизвестная команда.");
            }
        }
    }
}
