using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.DTO
{
    public partial class ProfilePrivacySettingDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Private { get; set; }
        public bool FollowersOnly { get; set; }
        public bool Public { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
