using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            Ratings = new HashSet<Rating>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Poster { get; set; }
        public string Year { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
