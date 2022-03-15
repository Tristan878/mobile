using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobile2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPokemon : ContentPage
    {
        public DetailPokemon(Poke pokemon)
        {
            InitializeComponent();
            BindingContext = pokemon;
        }

       
        }
    }
