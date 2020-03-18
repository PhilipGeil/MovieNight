using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menu();
                MenuSelector(int.Parse(Console.ReadLine()));
            }
        }

        static void Menu()
        {
            List<string> options = new List<string>()
            {
                "See all the movies",
                "See all the actors",
                "Search for a movie",
                "Search for an actor",
                "Search for a movie based on genre"
            };
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, options[i]);
            }
        }

        static void MenuSelector(int choise)
        {
            switch (choise)
            {
                case 1:
                    Console.Clear();
                    List<Movie> movies = MovieManager.GetMovies();
                    foreach (Movie item in movies)
                    {
                        Console.WriteLine(item.Title);
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    List<Actor> actors = MovieManager.GetActors();
                    foreach (Actor item in actors)
                    {
                        Console.WriteLine(item.FName + ' ' + item.LName);
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Enter search word");
                    List<Movie> searchMovies = MovieManager.SearchForMovies(Console.ReadLine());
                    foreach (Movie item in searchMovies)
                    {
                        Console.WriteLine(item.Title + ' ' + item.Year);
                        Console.WriteLine(item.Description);
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Enter search word for actor");
                    List<Actor> searchActors = MovieManager.SearchForActors(Console.ReadLine());
                    foreach (Actor item in searchActors)
                    {
                        Console.WriteLine(item.FName + ' ' + item.LName);
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Search by genre");
                    List<Movie> searchMoviesGenre = MovieManager.SearchByGenre(Console.ReadLine());
                    foreach (Movie item in searchMoviesGenre)
                    {
                        Console.WriteLine(item.Title + ' ' + item.Year);
                        Console.WriteLine(item.Description);
                    }
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
