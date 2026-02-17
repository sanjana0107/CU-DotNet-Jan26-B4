using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31Solution
{
    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public int Year;
        public double Price;
    }
    internal class Q4LibraryManagementSystem
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400},
                new Book{Title="History", Author="Raj", Genre="History", Year=2018, Price=400}
            };
            //books published after 2015
            books.Where(b => b.Year > 2015).ToList().ForEach(b => Console.WriteLine($"Title - {b.Title}, Author - {b.Author}, Genre - {b.Genre}, Year - {b.Year}"));
            Console.WriteLine(new string('-', 80));


            //group by Genre and count books
            var grpByGenre = books.GroupBy(b => b.Genre).Select(s => new { Genre = s.Key, Count = s.Count() });
            foreach (var book in grpByGenre)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine(new string('-', 80));

            //most expensive book per Genre
            var expensivePerGenre = books.GroupBy(b => b.Genre).Select(s => new { Genre = s.Key, Price = s.Max(b => b.Price) });
            foreach (var book in expensivePerGenre)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine(new string('-', 80));

            //distinct author list
            var distinctAuthor = books.GroupBy(b => b.Author).Select(s => s.Key );
            foreach (var author in distinctAuthor)
            {
                Console.WriteLine($"Author - {author}");
            }
            Console.WriteLine(new string('-',80));



        }
    }
}
