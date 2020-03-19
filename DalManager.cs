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
                SqlCommand cmd = new SqlCommand("select ActorID, FirstName, LastName from Actor", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ActorID"];
                    string fName = (string)rdr["FirstName"];
                    string lName = (string)rdr["LastName"];

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
                SqlCommand cmd = new SqlCommand("select ActorID, FirstName, LastName from Actor where FirstName like @search or LastName like @search", connection);

                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ActorID"];
                    string fName = (string)rdr["FirstName"];
                    string lName = (string)rdr["LastName"];

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
        /// <summary>
        /// Create's a new actor 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Actor InsertActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Actor(FirstName, LastName) OUTPUT INSERTED.ActorID values(@fn, @ln)", connection);
                cmd.Parameters.Add(new SqlParameter("@fn", a.FName));
                cmd.Parameters.Add(new SqlParameter("@ln", a.LName));
                int newId = (Int32)cmd.ExecuteScalar();
                a.Id = newId;
            }
            return a;
        } 
        /// <summary>
        /// Create's a new movie
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Movie InsertMovie(Movie m)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Movies (MovieName, MovieYear, MovieDescription) OUTPUT INSERTED.MovieID values (@mn, @my, @md)", connection);
                cmd.Parameters.Add(new SqlParameter("@mn", m.Title));
                cmd.Parameters.Add(new SqlParameter("@my", m.Year));
                cmd.Parameters.Add(new SqlParameter("@md", m.Description));
                int newID = (int)cmd.ExecuteScalar();
                m.Id = newID;
            }
            return m;
        }
        /// <summary>
        /// Retrieves all the genres in which the selected movie is not related to
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public static List<Genre> GetGenres(Movie movie)
        {
            List<Genre> genres = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Genre.GenreID, Genre.Type from Genre where GenreID not in (select GenreID from MovieGenre where MovieID = @m)", connection);
                cmd.Parameters.Add(new SqlParameter("@m", movie.Id));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["GenreID"];
                    string type = (string)rdr["Type"];
                    Genre g = new Genre(id, type);
                    genres.Add(g);
                }
            }
            return genres;
        }
        /// <summary>
        /// Add's a genre to a movie
        /// </summary>
        /// <param name="m"></param>
        /// <param name="g"></param>
        public static void AddGenre(Movie m, Genre g)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into MovieGenre values (@mid, @gid)", connection);
                cmd.Parameters.Add(new SqlParameter("@mid", m.Id));
                cmd.Parameters.Add(new SqlParameter("@gid", g.Id));
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Update's the credentials for an actor
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Actor UpdateActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update Actor set FirstName=@fn, LastName=@ln where ActorID=@id", connection);
                cmd.Parameters.Add(new SqlParameter("@fn", a.FName));
                cmd.Parameters.Add(new SqlParameter("@ln", a.LName));
                cmd.Parameters.Add(new SqlParameter("@id", a.Id));
                cmd.ExecuteNonQuery();
            }
            return a;
        }
        /// <summary>
        /// Update's the credentials for a movie
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Movie UpdateMovie(Movie m)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update Movies set MovieName=@mn, MovieYear=@my, MovieDescription=@md where MovieID=@id", connection);
                cmd.Parameters.Add(new SqlParameter("@mn", m.Title));
                cmd.Parameters.Add(new SqlParameter("@my", m.Year));
                cmd.Parameters.Add(new SqlParameter("@md", m.Description));
                cmd.Parameters.Add(new SqlParameter("@id", m.Id));
                cmd.ExecuteNonQuery();
            }
            return m;
        }
        /// <summary>
        /// Deletes a movie
        /// </summary>
        /// <param name="m"></param>
        public static void DeleteMovie(Movie m)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("delete from MovieGenre where MovieID = @id", connection);
                SqlCommand cmd1 = new SqlCommand("delete from MovieCast where MovieID = @id", connection);
                SqlCommand cmd2 = new SqlCommand("delete from Movies where MovieID = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@id", m.Id));
                cmd1.Parameters.Add(new SqlParameter("@id", m.Id));
                cmd2.Parameters.Add(new SqlParameter("@id", m.Id));
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Delete's an actor
        /// </summary>
        /// <param name="a"></param>
        public static void DeleteActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("delete from MovieCast where ActorID = @id", connection);
                SqlCommand cmd1 = new SqlCommand("delete from Actor where ActorID = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@id", a.Id));
                cmd1.Parameters.Add(new SqlParameter("@id", a.Id));
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
            }
        }

    }
}
