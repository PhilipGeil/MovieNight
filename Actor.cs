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

        public Actor(int id, string fName, string lName) 
        {
            Id = id;
            FName = fName;
            LName = lName;
        }
    }
}
