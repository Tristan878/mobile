using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;

namespace mobile2.Models
{
    public class Poke : ContentView
    {
        [PrimaryKey, AutoIncrement]
        public new int Id { get; set; }
        public string Nom { get; set; }
        public new float Height { get; set; }
        public float Weight { get; set; }
        public string Pictures { get; set; } 
        public int Hp { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
    }
}
