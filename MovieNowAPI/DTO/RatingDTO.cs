using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.DTO
{
    public partial class RatingDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int? RatingNumber { get; set; }

        public virtual MovieDTO Movie { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
