using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace mobile2.Models
{
    [Table("")]
    public class PokeBdd
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50), Unique]
        public string Nom { get; set; }
        public string Image { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Hp { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
    }
}
