using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.Entities
{
    public partial class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }

        public virtual User User { get; set; }
    }
}
