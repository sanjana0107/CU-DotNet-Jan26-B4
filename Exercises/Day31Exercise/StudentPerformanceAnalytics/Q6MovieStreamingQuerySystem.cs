using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class Movie 
    { 
        public string Title; 
        public string Genre; 
        public double Rating; 
        public int Year; 
    }
    internal class Q6MovieStreamingQuerySystem
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            //filter movies with rating > 8
            var ratingMoreThan8 = movies.Where(m => m.Rating > 8);
            Console.WriteLine("Movies having rating greater than 8 :");
            foreach(var movie in movies)
            {
                Console.WriteLine($"Title - {movie.Title}, Rating - {movie.Title}");
            }
            Console.WriteLine(new string('-',60));



            //group movies by genre and get average rating
            var genreAvgRating = movies.GroupBy(g => g.Genre).Select(m => new { Genre = m.Key, AvgRating = m.Average(x => x.Rating) });
            Console.WriteLine("Average rating of Movies by Genre : ");
            foreach(var movie in genreAvgRating)
            {
                Console.WriteLine($"Genre - {movie.Genre}, Average Rating - {movie.AvgRating}");
            }
            Console.WriteLine(new string('-', 60));



            //latest movie per Genre
            var latestByGenre = movies.GroupBy(g => g.Genre).Select(m => new { Genre = m.Key, LatestMovie = m.OrderByDescending(x => x.Year).First() });
            Console.WriteLine("Latest movie per Genre : ");
            foreach(var movie in latestByGenre)
            {
                Console.WriteLine($"Genre - {movie.Genre}, Latest Movie - {movie.LatestMovie.Title}");
            }
            Console.WriteLine(new string('-', 60));


            //Get top5 highest rated movies
            var top5Movies = movies.OrderByDescending(m => m.Rating).Take(5);
            Console.WriteLine("Top 5 highest rated movies : ");
            foreach(var movie in top5Movies)
            {
                Console.WriteLine($"Title - {movie.Title}, Rating - {movie.Rating}");
            }
            Console.WriteLine(new string('-', 60));
        }
    }
}
