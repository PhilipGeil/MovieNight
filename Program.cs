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
                "Search for a movie based on genre",
                "Create a new actor",
                "Create a new movie",
                "Choose a genre for a movie",
                "Update an actor",
                "Update a movie",
                "Delete a movie",
                "Delete an actor",
            };
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, options[i]);
            }
        }
        /// <summary>
        /// Used for selection of which method is being tested
        /// </summary>
        /// <param name="choise"></param>
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
                case 6:
                    Console.Clear();
                    Console.WriteLine("Create new actor");
                    Console.WriteLine("First Name");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Last Name");
                    string lName = Console.ReadLine();
                    Actor a = new Actor(fName, lName);
                    a = MovieManager.InsertActor(a);
                    Console.WriteLine("{0} - {1} {2}", a.Id, a.FName, a.LName);
                    Console.ReadKey();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Create new movie");
                    Console.WriteLine("Title");
                    string title = Console.ReadLine();
                    Console.WriteLine("Year");
                    int year = int.Parse(Console.ReadLine());
                    Console.WriteLine("Description");
                    string desc = Console.ReadLine();
                    Movie m = new Movie(title, year, desc);
                    m = MovieManager.InsertMovie(m);
                    Console.WriteLine("{0} - {1} {2}", m.Id, m.Title, m.Year);
                    Console.ReadKey();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Choose new/another genre for a movie");
                    List<Movie> movies1 = MovieManager.GetMovies();
                    Console.WriteLine("Choose the movie");
                    for (int i = 0; i < movies1.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i+1, movies1[i].Title);
                    }
                    int idx = int.Parse(Console.ReadLine());
                    List<Genre> genres = MovieManager.GetGenres(movies1[idx - 1]);
                    Console.WriteLine("Choose genre");
                    for (int i = 0; i < genres.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i+1, genres[i].Type);
                    }
                    int index = int.Parse(Console.ReadLine());
                    MovieManager.AddGenre(movies1[idx-1], genres[index-1]);
                    Console.WriteLine("Allright the movie {0} is now in the genre {1}", movies1[idx-1].Title, genres[index-1].Type);
                    Console.ReadKey();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("Update an actor");
                    List<Actor> actors1 = MovieManager.GetActors();
                    Console.WriteLine("Choose the actor");
                    for (int i = 0; i < actors1.Count; i++)
                    {
                        Console.WriteLine("{0}: {1} {2}", i+1, actors1[i].FName, actors1[i].LName);
                    }
                    int index1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new first name");
                    string newFName = Console.ReadLine();
                    Console.WriteLine("Enter the new last name");
                    string newLName = Console.ReadLine();
                    Actor newActor = new Actor(actors1[index1-1].Id, newFName, newLName);
                    newActor = MovieManager.UpdateActor(newActor);
                    Console.WriteLine("The actor has been changed to:");
                    Console.WriteLine("{0} {1}", newActor.FName, newActor.LName);
                    Console.ReadKey();
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine("Update a movie");
                    List<Movie> movies2 = MovieManager.GetMovies();
                    Console.WriteLine("Choose the movie");
                    for (int i = 0; i < movies2.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i+1, movies2[i].Title);
                    }
                    int index2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Title");
                    string newTitle = Console.ReadLine();
                    Console.WriteLine("Year");
                    int newYear = int.Parse(Console.ReadLine());
                    Console.WriteLine("Description");
                    string newDes = Console.ReadLine();
                    Movie newMovie = new Movie(movies2[index2-1].Id, newTitle, newYear, newDes);
                    newMovie = MovieManager.UpdateMovie(newMovie);
                    Console.WriteLine("The movie has been changed to:");
                    Console.WriteLine("{0} {1}", newMovie.Title, newMovie.Year);
                    Console.WriteLine(newMovie.Description);
                    Console.ReadKey();
                    break;
                case 11:
                    Console.Clear();
                    Console.WriteLine("Delete a movie");
                    List<Movie> movies3 = MovieManager.GetMovies();
                    Console.WriteLine("Choose the movie");
                    for (int i = 0; i < movies3.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1, movies3[i].Title);
                    }
                    int index3 = int.Parse(Console.ReadLine());
                    MovieManager.DeleteMovie(movies3[index3-1]);
                    Console.WriteLine("The movie has been deleted");
                    Console.ReadKey();
                    break;
                case 12:
                    Console.Clear();
                    Console.WriteLine("Delete a movie");
                    List<Actor> actors3 = MovieManager.GetActors();
                    Console.WriteLine("Choose the movie");
                    for (int i = 0; i < actors3.Count; i++)
                    {
                        Console.WriteLine("{0}: {1} {2}", i + 1, actors3[i].FName, actors3[i].LName);
                    }
                    int idx3 = int.Parse(Console.ReadLine());
                    MovieManager.DeleteActor(actors3[idx3 - 1]);
                    Console.WriteLine("The actor has been deleted");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
