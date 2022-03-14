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
        public int Id { get; set; }
        public string Nom { get; set; }
        public float height { get; set; }
        public float Weight { get; set; }
        public string Image { get; set; }

    }
}
