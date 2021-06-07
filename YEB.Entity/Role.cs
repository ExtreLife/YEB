using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YEB.Entity
{
    public class Role
    {
        public Role()
        {
            Functions = new List<Function>();
            Users = new List<User>();
        }

        [Column(TypeName = "varchar(30)")]
        public string Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        public List<Function> Functions { get; set; }
        public List<User> Users { get; set; }
    }
}
