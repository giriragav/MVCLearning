using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFlix.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleasedDate { get; set; }
        public byte NumberInStock { get; set; }
    }
}