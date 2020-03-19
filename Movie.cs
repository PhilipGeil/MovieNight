using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public List<string> Genres { get; set; }
        public Movie(string title, int year, string des)
        {
            Title = title;
            Year = year;
            Description = des;
        }
        public Movie(int id, string title, int year, string des) 
            :this(title, year, des)
        {
            Id = id;
        }
    }
}
