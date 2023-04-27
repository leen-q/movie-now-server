using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            Links = new HashSet<Link>();
            Ratings = new HashSet<Rating>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
