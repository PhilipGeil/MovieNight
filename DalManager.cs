using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public static class DalManager
    {
        static string cs = @"Data Source=ZBC-E-PHIL2643\SQLEXPRESS;Initial Catalog=Movies;Integrated Security = True";

        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select MovieID, MovieName, MovieYear, MovieDescription from Movies", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["MovieID"];
                    string title = (string)rdr["MovieName"];
                    int year = (int)rdr["MovieYear"];
                    string description = (string)rdr["MovieDescription"];

                    Movie m = new Movie(id, title, year, description);
                    movies.Add(m);
                }
            }
            return movies;
        }
        /// <summary>
        /// Gets all the actors
        /// </summary>
        /// <returns></returns>
        public static List<Actor> GetActors()
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Actor.ActorID, ActorFName.fName, ActorLName.lName from Actor inner join ActorFName on ActorFName.ActorID = Actor.ActorID inner join ActorLName on ActorLName.ActorID = Actor.ActorID", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ActorID"];
                    string fName = (string)rdr["fName"];
                    string lName = (string)rdr["lName"];

                    Actor a = new Actor(id, fName, lName);
                    actors.Add(a);
                }
            }
            return actors;
        }
        /// <summary>
        /// Gets the movies based on the search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Movie> SearchForMovies(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select MovieID, MovieName, MovieYear, MovieDescription from Movies where MovieName like @search", connection);

                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["MovieID"];
                    string title = (string)rdr["MovieName"];
                    int year = (int)rdr["MovieYear"];
                    string description = (string)rdr["MovieDescription"];

                    Movie m = new Movie(id, title, year, description);
                    movies.Add(m);
                }
            }
            return movies;
        }
        /// <summary>
        /// Gets the actors based on the search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Actor> SearchForActors(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Actor.ActorID, fName, lName from Actor inner join ActorFName on ActorFName.ActorID = Actor.ActorID inner join ActorLName on ActorLName.ActorID = Actor.ActorID where fName like @search or lName like @search", connection);

                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ActorID"];
                    string fName = (string)rdr["fName"];
                    string lName = (string)rdr["lName"];

                    Actor a = new Actor(id, fName, lName);
                    actors.Add(a);
                }
            }
            return actors;
        }
        /// <summary>
        /// Gets the movies based on the genre
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Movie> SearchByGenre(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Movies.MovieID, MovieName, MovieYear, MovieDescription from Movies inner join MovieGenre on MovieGenre.MovieID = Movies.MovieID inner join Genre on Genre.GenreID = MovieGenre.GenreID where Type like @search", connection);

                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["MovieID"];
                    string title = (string)rdr["MovieName"];
                    int year = (int)rdr["MovieYear"];
                    string description = (string)rdr["MovieDescription"];

                    Movie m = new Movie(id, title, year, description);
                    movies.Add(m);
                }
            }
            return movies;
        }

    }
}
