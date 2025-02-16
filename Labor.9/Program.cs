using System;
namespace Labor._9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string msg = "";
            while (msg != "11")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Создание Post по умолчанию");
                Console.WriteLine("2 - Создание Post с параметрами");
                Console.WriteLine("3 - Создание копии Post");
                Console.WriteLine("4 - Демонстрация статической функции");
                Console.WriteLine("5 - Демонстрация метода класса");
                Console.WriteLine("6 - Демонстрация перегруженных операций");
                Console.WriteLine("7 - Создание пустого массива PostArray");
                Console.WriteLine("8 - Автоматическое создание массива PostArray");
                Console.WriteLine("9 - Демонстрация индексатора PostArray");
                Console.WriteLine("10 - Вычисление общего коэффициента вовлеченности");
                Console.WriteLine("11 - Завершить выполнение программы");

                msg = Console.ReadLine();

                switch (msg)
                {
                    case "1":
                        MessageHandler.CreateDefaultPost();
                        Console.ReadLine();
                        break;
                    case "2":
                        Post postWithParams = MessageHandler.CreatePostWithParams();
                        postWithParams.DisplayPostInfo();
                        Console.ReadLine();
                        break;
                    case "3":
                        MessageHandler.CopyPost();
                        Console.ReadLine();
                        break;
                    case "4":
                        MessageHandler.DemonstrateStaticFunction();
                        Console.ReadLine();
                        break;
                    case "5":
                        MessageHandler.DemonstrateClassMethod();
                        Console.ReadLine();
                        break;
                    case "6":
                        MessageHandler.DemonstrateOverloadedOperators();
                        Console.ReadLine();
                        break;
                    case "7":
                        MessageHandler.CreateEmptyPostArray();
                        Console.ReadLine();
                        break;
                    case "8":
                        PostArray autoArray = MessageHandler.CreateAutoPostArray();
                        autoArray.DisplayArray();
                        Console.ReadLine();
                        break;
                    case "9":
                        MessageHandler.DemonstrateIndexer();
                        Console.ReadLine();
                        break;
                    case "10":
                        PostArray engagementArray = MessageHandler.CreateAutoPostArray();
                        MessageHandler.CalculateTotalEngagementRate(engagementArray);
                        Console.ReadLine();
                        break;
                    case "11":
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("Программа завершена.");
        }
    }
}
