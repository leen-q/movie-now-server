using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.DTO
{
    public partial class FollowerDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
