using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YEB.Entity
{
    public class Function
    {
        public Function()
        {
            Roles = new List<Role>();
        }

        [Column(TypeName = "varchar(30)")]
        public string Id { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Path { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Component { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Icon { get; set; }
        public bool KeepAlive { get; set; }
        public int OrderBy { get; set; }
        public int Disabled { get; set; }
        [Required]
        public Menu Menu { get; set; }
        public List<Role> Roles { get; set; }
    }
}
