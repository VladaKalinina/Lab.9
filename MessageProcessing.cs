
public static class MessageProcessing
{
    // Создание пустого поста
    public static Post CreateEmptyPost()
    {
        return new Post();
    }

    // Создание поста с параметрами
    public static Post CreatePostWithParameters()
    {
        Console.Write("Введите количество просмотров: ");
        int views = int.Parse(Console.ReadLine());
        Console.Write("Введите количество комментариев: ");
        int comments = int.Parse(Console.ReadLine());
        Console.Write("Введите количество реакций: ");
        int reactions = int.Parse(Console.ReadLine());
        return new Post(views, comments, reactions);
    }

    // Создание массива постов заданного размера
    public static PostArray CreatePostArray(int size)
    {
        PostArray array = new PostArray(size);
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Пост #{i + 1}:");
            array.AddPost(CreatePostWithParameters());
        }
        return array;
    }

    // Вычисление общего коэффициента вовлечённости для массива
    public static double CalculateTotalEngagementRate(PostArray array)
    {
        double totalEngagement = 0;
        int length = array.GetLength();
        for (int i = 0; i < length; i++)
        {
            totalEngagement += array.GetPost(i).CalculateEngagementRate();
        }
        return totalEngagement / length;
    }
}