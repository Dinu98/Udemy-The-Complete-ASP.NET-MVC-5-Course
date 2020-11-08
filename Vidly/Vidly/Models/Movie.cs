using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public String Name { get; set; }
        public Genre Genre { get; set; }
        [Required, Display(Name = "Category")]
        public byte GenreId { get; set; }
        [Required,Range(1, int.MaxValue, ErrorMessage = "This number should be greater than 0")]
        public int? Stock { get; set; }
    }
}