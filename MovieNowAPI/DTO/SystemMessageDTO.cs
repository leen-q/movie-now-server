using System;
using System.Collections.Generic;

#nullable disable

namespace MovieNowAPI.DTO
{
    public partial class SystemMessageDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
