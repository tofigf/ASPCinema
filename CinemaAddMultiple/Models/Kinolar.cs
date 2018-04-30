using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaAddMultiple.Models;

namespace CinemaAddMultiple.Models
{
   
    public class Kinolar
    {
        public List<Film> Films { get; set; }
        public List<Country> Countries{ get; set; }
        public List<Genre> Genres { get; set; }
        public int[] Country { get; set; }
        public int[] Genre { get; set; }
    }
}