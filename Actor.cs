using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public class Actor
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }


        public Actor(string fName, string lName)
        {
            FName = fName;
            LName = lName;
        }
        public Actor(int id, string fName, string lName) 
            :this(fName, lName)
        {
            Id = id;
        }
    }
}
