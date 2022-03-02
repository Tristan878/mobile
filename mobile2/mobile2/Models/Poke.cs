using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace mobile2.Models
{
    public class Poke : ContentView
    {
        public string nom { get; set; }
        public string element { get; set; }
        public int pv { get; set; }
    }
}
