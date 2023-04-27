using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.Entities
{
    public partial class User
    {
        public User()
        {
            Followers = new HashSet<Follower>();
            ProfilePrivacySettings = new HashSet<ProfilePrivacySetting>();
            Profiles = new HashSet<Profile>();
            Ratings = new HashSet<Rating>();
            Reviews = new HashSet<Review>();
            SystemMessages = new HashSet<SystemMessage>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Follower> Followers { get; set; }
        public virtual ICollection<ProfilePrivacySetting> ProfilePrivacySettings { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<SystemMessage> SystemMessages { get; set; }
    }
}
