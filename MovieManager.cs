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
    }
}
