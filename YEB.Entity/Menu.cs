using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YEB.Entity
{
    public class Menu
    {
        public Menu()
        {
            Functions = new List<Function>();
        }

        [Column(TypeName = "varchar(30)")]
        public string Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Icon { get; set; }
        public int OrderBy { get; set; }
        public bool Disabled { get; set; }
        public List<Function> Functions { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string ParentMenuId { get; set; }
    }
}
