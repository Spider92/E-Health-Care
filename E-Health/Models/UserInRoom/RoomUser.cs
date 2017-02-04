using E_Health.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Health.Models.UserInRoom
{
    public class RoomUser
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Time { get; set; }
        public string Department { get; set; }
        public string Busy { get; set; }
        public virtual Register Register { get; set; }

    }
}