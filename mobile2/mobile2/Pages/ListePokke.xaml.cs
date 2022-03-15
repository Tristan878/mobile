using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobile2.Models;
using mobile2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace mobile2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListePokke : ContentPage
    {
        public ListePokke()
        {
            InitializeComponent();
            BindingContext = PokeViewModel.Instance;

        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Poke current = (e.CurrentSelection.FirstOrDefault() as Poke);

            if (current == null)
            {
                return;
            }

           (sender as CollectionView).SelectedItem = null;

            await Navigation.PushAsync(new DetailPokemon(current));
        }
    }
}