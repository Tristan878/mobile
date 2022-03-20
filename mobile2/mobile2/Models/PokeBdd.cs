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
        public float Height { get; set; }
        public float Weight { get; set; }
        public int Hp { get; set; }
        public string Types { get; set; }
    }
}
