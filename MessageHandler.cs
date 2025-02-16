using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor._9
{
    internal class MessageHandler
    {
        public static int GetIntInput(string message)
        {
            int num;
            bool isValid;

            do
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out num);

                if (!isValid)
                {
                    Console.WriteLine("Некорректный ввод. Введите целое число.");
                }
            } while (!isValid);

            return num;
        }

        public static void CreateDefaultPost()
        {
            Post post = new Post();
            Console.WriteLine("Создан Post по умолчанию:");
            post.DisplayPostInfo();
        }

        public static Post CreatePostWithParams()
        {
            int views = GetIntInput("Введите количество просмотров:");
            int comments = GetIntInput("Введите количество комментариев:");
            int reactions = GetIntInput("Введите количество реакций:");
            Post post = new Post(views, comments, reactions);
            Console.WriteLine("Создан Post с параметрами:");
            return post;
        }

        public static void CopyPost()
        {
            Post post1 = new Post(100, 10, 5);
            Console.WriteLine("Исходный Post:");
            post1.DisplayPostInfo();

            Post post2 = new Post(post1);
            Console.WriteLine("Копия Post:");
            post2.DisplayPostInfo();
        }

        public static void DemonstrateStaticFunction()
        {
            Post post = CreatePostWithParams();
            double engagementRate = Post.CalculateEngagementRateStatic(post);
            Console.WriteLine($"Коэффициент вовлеченности (статическая функция): {engagementRate}%");
        }

        public static void DemonstrateClassMethod()
        {
            Post post = CreatePostWithParams();
            double engagementRate = post.CalculateEngagementRate();
            Console.WriteLine($"Коэффициент вовлеченности (метод класса): {engagementRate}%");
        }

        public static void DemonstrateOverloadedOperators()
        {
            Post post = new Post(50, 2, 1);
            Console.WriteLine("Исходный Post:");
            post.DisplayPostInfo();

            post = !post;
            Console.WriteLine("После !post (увеличение реакций):");
            post.DisplayPostInfo();

            ++post;
            Console.WriteLine("После ++post (увеличение просмотров):");
            post.DisplayPostInfo();

            bool hasEngagement = (bool)post;
            Console.WriteLine($"У поста есть вовлечение: {hasEngagement}");

            double engagementRate = (double)post;
            Console.WriteLine($"Коэффициент вовлеченности (double): {engagementRate}%");
        }

        public static void CreateEmptyPostArray()
        {
            PostArray array = new PostArray();
            Console.WriteLine("Создан пустой PostArray.");
        }

        public static PostArray CreateAutoPostArray()
        {
            int size = GetIntInput("Введите размер PostArray:");
            PostArray array = new PostArray(size);
            return array;
        }

        public static void DemonstrateIndexer()
        {
            PostArray array = CreateAutoPostArray();
            Console.WriteLine("Исходный PostArray:");
            array.DisplayArray();

            int index = GetIntInput("Введите индекс элемента для изменения:");
            try
            {
                Post newPost = CreatePostWithParams();
                array[index] = newPost;
                Console.WriteLine("PostArray после изменения элемента:");
                array.DisplayArray();

                Console.WriteLine("Элемент по указанному индексу: ");
                array[index].DisplayPostInfo();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void CalculateTotalEngagementRate(PostArray array)
        {
            double totalEngagementRate = array.CalculateTotalEngagementRate();
            Console.WriteLine($"Общий коэффициент вовлеченности для PostArray: {totalEngagementRate}%");
        }
    }
}