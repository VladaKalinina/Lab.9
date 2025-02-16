using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor._9
{
    public class PostArray
    {
        private Post[] arr;

        public PostArray()
        {
            arr = new Post[0];
        }

        public PostArray(int size)
        {
            arr = new Post[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = new Post(random.Next(0, 1000), random.Next(0, 100), random.Next(0, 50));
            }
        }

        public PostArray(PostArray other)
        {
            arr = new Post[other.arr.Length];
            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i] = new Post(other.arr[i]); // Глубокое копирование
            }
        }

        public int Length
        {
            get { return arr.Length; }
        }

        public Post this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне границ массива.");
                }
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне границ массива.");
                }
                arr[index] = value;
            }
        }

        public void DisplayArray()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                arr[i].DisplayPostInfo();
            }
        }

        public double CalculateTotalEngagementRate()
        {
            if (arr.Length == 0) return 0;

            double totalEngagementRate = 0;
            foreach (Post post in arr)
            {
                totalEngagementRate += (double)post; // Использование неявного приведения к double
            }
            return Math.Round(totalEngagementRate / arr.Length, 2);
        }

    }
}