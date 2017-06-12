using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFlix.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Movie name is required")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please select Genre a for this movie")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Date added is required")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleasedDate { get; set; }

        [Required(ErrorMessage = "Number is stock is required")]
        [Range(1,20,ErrorMessage = "The stock should be between 1 and 20")]
        public byte NumberInStock { get; set; }
    }
}