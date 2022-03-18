using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace mobile2.Models
{
    [Table("")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50), Unique]
        public string Nom { get; set; }
    }
}
