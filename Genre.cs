using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public class Genre
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public Genre(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
