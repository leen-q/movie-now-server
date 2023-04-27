using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.Entities
{
    public partial class Follower
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public virtual User User { get; set; }
    }
}
