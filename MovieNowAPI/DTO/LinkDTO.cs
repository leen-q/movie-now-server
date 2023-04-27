using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.DTO
{
    public partial class LinkDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ImdbId { get; set; }

        public virtual MovieDTO Movie { get; set; }
    }
}
