using System;

public class PostArray
{
    // Массив постов
    private Post[] posts;

    // Конструктор без параметров (пустой массив)
    public PostArray()
    {
        posts = new Post[0];
    }

    // Конструктор с размером массива
    public PostArray(int size)
    {
        posts = new Post[size];
        for (int i = 0; i < size; i++)
        {
            posts[i] = CreateRandomPost();
        }
    }

    // Создание случайного поста
    private Post CreateRandomPost()
    {
        Random random = new Random();
        return new Post(random.Next(100, 1000), random.Next(1, 100), random.Next(1, 100));
    }

    // Добавление поста в массив
    public void AddPost(Post post)
    {
        Array.Resize(ref posts, posts.Length + 1);
        posts[posts.Length - 1] = post;
    }

    // Вывод всех постов из массива
    public void DisplayPosts()
    {
        foreach (var post in posts)
        {
            post.PrintInfo();
        }
    }

    // Получение поста по индексу
    public Post GetPost(int index)
    {
        if (index < 0 || index >= posts.Length)
        {
            throw new IndexOutOfRangeException("Индекс вне диапазона.");
        }
        return posts[index];
    }

    // Замена поста по индексу
    public void ReplacePost(int index, Post newPost)
    {
        if (index < 0 || index >= posts.Length)
        {
            throw new IndexOutOfRangeException("Индекс вне диапазона.");
        }
        posts[index] = newPost;
    }

    // Получение длины массива
    public int GetLength()
    {
        return posts.Length;
    }
}