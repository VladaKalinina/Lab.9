using System;

public class Post
{
    public int views;
    public int comments;
    public int reactions;

    public Post()
    {
        views = 0;
        comments = 0;
        reactions = 0;
    }

    public Post(int views, int comments, int reactions)
    {
        this.views = views;
        this.comments = comments;
        this.reactions = reactions;
    }

    public double CalculateEngagementRate()
    {
        if (views == 0) return 0; // Избегаем деления на ноль
        return ((double)(comments + reactions) / views) * 100;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Просмотры: {views}, Комментарии: {comments}, Реакции: {reactions}");
    }
}