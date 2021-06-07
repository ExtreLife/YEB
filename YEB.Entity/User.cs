using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YEB.Entity
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        [Key]
        [Column(TypeName = "varchar(30)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string PortraitUrl { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        [Column(TypeName = "varchar(11)")]
        public string Contact { get; set; }
        public List<Role> Roles { get; set; }
    }
}
