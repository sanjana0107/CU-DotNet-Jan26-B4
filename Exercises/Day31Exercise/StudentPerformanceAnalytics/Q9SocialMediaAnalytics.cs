using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class User
    {
        public int Id;
        public string Name;
        public string Country;
    }
    class Post
    {
        public int UserId;
        public int Likes;
    }

    internal class Q9SocialMediaAnalytics
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };

            //get top users by total likes
            var topUsersByLikes = users.GroupJoin(posts, u => u.Id, p => p.UserId, (u, p) => new {UserId =  u.Id, TotalLikes = p.Sum(x => x.Likes)}).OrderByDescending(p => p.TotalLikes);
            Console.WriteLine("Top users by total likes :");
            foreach (var item in topUsersByLikes)
            {
                Console.WriteLine($"UserId - {item.UserId}, Total Likes - {item.TotalLikes}");
            }
            Console.WriteLine(new string('-', 60));



            //group users by country
            var userByCountry = users.GroupBy(u => u.Country).Select(s => new { Country = s.Key, UserId = s.Select(u => u.Id)});
            Console.WriteLine("Group Users by Country: ");
            foreach(var item in userByCountry)
            {
                Console.WriteLine($"UserId - {string.Join(',',item.UserId)} Country - {item.Country}");
            }
            Console.WriteLine(new string('-', 60));

            //list of inactive users
            var inactiveUsers = users.GroupJoin(posts, u => u.Id, p => p.UserId, (u, s) => new 
            { u.Id, u.Country, u.Name, TotalLikes = s.Sum ( x=> x.Likes)}).Where(g => g.TotalLikes == 0);
            Console.WriteLine("List of inactive users: ");
            foreach(var item in inactiveUsers)
            {
                Console.WriteLine($"userID - {item.Id}, Name - {item.Name}, Country - {item.Country}, Name - {item.Name}, Likes - {item.TotalLikes}");
            }
            Console.WriteLine(new string('-', 60));
            //average likes per post
            var avgLikes = posts.Average(p => p.Likes);
            Console.WriteLine($"Average Likes - {avgLikes}");
        }
    }
}
