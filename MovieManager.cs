using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public static class MovieManager
    {
        public static List<Movie> GetMovies() 
        {
            return DalManager.GetMovies();
        }

        public static List<Actor> GetActors ()
        {
            return DalManager.GetActors();
        }

        public static List<Movie> SearchForMovies(string search)
        {
            return DalManager.SearchForMovies(search);
        }

        public static List<Actor> SearchForActors(string search)
        {
            return DalManager.SearchForActors(search);
        }

        public static List<Movie> SearchByGenre(string search)
        {
            return DalManager.SearchByGenre(search);
        }

        public static Actor InsertActor(Actor a)
        {
            return DalManager.InsertActor(a);
        }

        public static Movie InsertMovie(Movie m)
        {
            return DalManager.InsertMovie(m);
        }

        public static List<Genre> GetGenres(Movie movie)
        {
            return DalManager.GetGenres(movie);
        }
        public static void AddGenre(Movie m, Genre g)
        {
            DalManager.AddGenre(m, g);
        }
        public static Actor UpdateActor(Actor a)
        {
            return DalManager.UpdateActor(a);
        }

        public static Movie UpdateMovie(Movie m)
        {
            return DalManager.UpdateMovie(m);
        }

        public static void DeleteMovie(Movie m)
        {
            DalManager.DeleteMovie(m);
        }
        public static void DeleteActor(Actor a)
        {
            DalManager.DeleteActor(a);
        }
    }
}
