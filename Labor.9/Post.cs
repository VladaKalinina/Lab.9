using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor._9
{
    public class Post
    {
        private int numViews;
        private int numComments;
        private int numReactions;
        private static int postCount = 0;

        public Post() : this(0, 0, 0) { }

        public Post(int views, int comments, int reactions)
        {
            NumViews = views;
            NumComments = comments;
            NumReactions = reactions;
            postCount++;
        }

        public Post(Post other)
        {
            NumViews = other.NumViews;
            NumComments = other.NumComments;
            NumReactions = other.NumReactions;
            postCount++;
        }

        public int NumViews
        {
            get { return numViews; }
            set { numViews = value >= 0 ? value : 0; }
        }

        public int NumComments
        {
            get { return numComments; }
            set { numComments = value >= 0 ? value : 0; }
        }

        public int NumReactions
        {
            get { return numReactions; }
            set { numReactions = value >= 0 ? value : 0; }
        }

        public static int PostCount
        {
            get { return postCount; }
        }

        public void DisplayPostInfo()
        {
            Console.WriteLine($"Просмотры: {NumViews}, Комментарии: {NumComments}, Реакции: {NumReactions}");
        }

        // Статическая функция
        public static double CalculateEngagementRateStatic(Post post)
        {
            const int totalSubscribers = 1000;
            if (totalSubscribers == 0) return 0;
            return Math.Round((double)post.NumViews / totalSubscribers * 100, 2);
        }

        // Метод класса
        public double CalculateEngagementRate()
        {
            const int totalSubscribers = 1000;
            if (totalSubscribers == 0) return 0;
            return Math.Round((double)NumViews / totalSubscribers * 100, 2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Post other = (Post)obj;
            return NumViews == other.NumViews &&
                   NumComments == other.NumComments &&
                   NumReactions == other.NumReactions;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NumViews, NumComments, NumReactions);
        }

        // Унарные операции
        public static Post operator !(Post post)
        {
            post.NumReactions++;
            return post;
        }

        public static Post operator ++(Post post)
        {
            post.NumViews++;
            return post;
        }

        // Операции приведения типа
        public static explicit operator bool(Post post)
        {
            return post.NumComments > 0 || post.NumReactions > 0 && post.NumViews > 0;
        }

        public static implicit operator double(Post post)
        {
            const int totalSubscribers = 1000;
            if (totalSubscribers == 0) return 0;
            return Math.Round((double)post.NumViews / totalSubscribers * 100, 2);
        }

        // Бинарные операции
        public static bool operator ==(Post p1, Post p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (p1 is null || p2 is null)
            {
                return false;
            }

            return p1.NumViews == p2.NumViews &&
                   p1.NumComments == p2.NumComments &&
                   p1.NumReactions == p2.NumReactions;
        }

        public static bool operator !=(Post p1, Post p2)
        {
            return !(p1 == p2);
        }
    }
}