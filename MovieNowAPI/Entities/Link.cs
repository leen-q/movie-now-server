using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.Entities
{
    public partial class Link
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ImdbId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
