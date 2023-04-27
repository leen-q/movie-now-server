using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.DTO
{
    public partial class MovieDTO
    {
        public MovieDTO()
        {
            Links = new HashSet<LinkDTO>();
            Ratings = new HashSet<RatingDTO>();
            Reviews = new HashSet<ReviewDTO>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<LinkDTO> Links { get; set; }
        public virtual ICollection<RatingDTO> Ratings { get; set; }
        public virtual ICollection<ReviewDTO> Reviews { get; set; }
    }
}
