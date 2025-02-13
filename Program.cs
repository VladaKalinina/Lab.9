
internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Создать пустой пост");
            Console.WriteLine("2 - Создать пост с параметрами");
            Console.WriteLine("3 - Создать массив постов");
            Console.WriteLine("4 - Вычислить общий коэффициент вовлечённости");
            Console.WriteLine("5 - Выйти из программы");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Post emptyPost = MessageProcessing.CreateEmptyPost();
                    Console.WriteLine("Пустой пост создан:");
                    emptyPost.PrintInfo();
                    break;

                case "2":
                    Post customPost = MessageProcessing.CreatePostWithParameters();
                    Console.WriteLine("Пост создан:");
                    customPost.PrintInfo();
                    break;

                case "3":
                    Console.Write("Введите размер массива: ");
                    int size = int.Parse(Console.ReadLine());
                    PostArray array = MessageProcessing.CreatePostArray(size);
                    Console.WriteLine("Массив постов создан:");
                    array.DisplayPosts();
                    break;

                case "4":
                    Console.Write("Введите размер массива: ");
                    size = int.Parse(Console.ReadLine());
                    array = MessageProcessing.CreatePostArray(size);
                    double engagementRate = MessageProcessing.CalculateTotalEngagementRate(array);
                    Console.WriteLine($"Общий коэффициент вовлечённости: {engagementRate:F2}%");
                    break;

                case "5":
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}