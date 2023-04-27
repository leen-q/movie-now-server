using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.DTO
{
    public partial class UserDTO
    {
        public UserDTO()
        {
            Followers = new HashSet<FollowerDTO>();
            ProfilePrivacySettings = new HashSet<ProfilePrivacySettingDTO>();
            Profiles = new HashSet<ProfileDTO>();
            Ratings = new HashSet<RatingDTO>();
            Reviews = new HashSet<ReviewDTO>();
            SystemMessages = new HashSet<SystemMessageDTO>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<FollowerDTO> Followers { get; set; }
        public virtual ICollection<ProfilePrivacySettingDTO> ProfilePrivacySettings { get; set; }
        public virtual ICollection<ProfileDTO> Profiles { get; set; }
        public virtual ICollection<RatingDTO> Ratings { get; set; }
        public virtual ICollection<ReviewDTO> Reviews { get; set; }
        public virtual ICollection<SystemMessageDTO> SystemMessages { get; set; }
    }
}
