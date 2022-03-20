using System;
using System.Collections.Generic;
using mobile2.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace mobile2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutPoke : ContentPage
    {
        readonly string[] types = { "Acier","Combat","Dragon",
                                    "Eau","Électrik","Fée","Feu",
                                    "Glace","Insecte","Normal",
                                    "Plante","Poison","Psy","Roche","Sol",
                                    "Spectre","Ténèbres","Vol" };
    public AjoutPoke()
        {
            InitializeComponent();
            foreach (string type in types)
            {
                NewType1.Items.Add(type);
                NewType2.Items.Add(type);
            }
        }
        /* private async void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            await App.PokeBddViewModel.AddNewPokeAsync(newPoke.Text);
            statusMessage.Text = App.PokeBddViewModel.StatusMessage;
        } */

        async void OnNewButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newNom.Text) && ImagePoke.Source != null && NewType1.SelectedIndex != -1)
            {
                PokeBdd pokemon = new PokeBdd
                {
                    Nom = newNom.Text,
                    Image = ImagePoke.Source.ToString().Split(' ')[1],
                    Height = (int)newTaille.Value,
                    Weight = (int)newPoids.Value,
                    Hp = (int)newHp.Value,
                    Type1 = NewType1.SelectedItem.ToString(),
                    Type2 = "",
                };

                if (NewType2.SelectedIndex != -1)
                    pokemon.Type2 = NewType2.SelectedItem.ToString();
                
                await App.PokeBddViewModel.SavePokeAsync(pokemon);

                newNom.Text = "";
                ImagePoke.Source = null;
                newTaille.Value = 1;
                newPoids.Value = 1;
                newHp.Value = 1;
                NewType1.SelectedIndex = -1;
                NewType2.SelectedItem = -1;
            } 
            else
            {
               await DisplayAlert("Champs obligatoires non remplis", "Le nom, l'image ou le type est manquant !", "J'ai compris");
            }
        }

        public void ValeurSlider(object sender, EventArgs e)
        {
            if (sender == newTaille)
                LabelTaille.Text = "Taille : " + ((int)newTaille.Value).ToString();

            if (sender == newPoids)
                LabelPoids.Text = "Poids : " + ((int)newPoids.Value).ToString();

            if (sender == newHp)
                LabelHp.Text = "Points de vie : " + ((int)newHp.Value).ToString();
        }


        async void AjoutImage(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Non supporté", "Votre telephone ne " +
                    "supporte pas cette fonctionnalitée", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full,
                CompressionQuality = 40


            };

            var imageSelectionee = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if (imageSelectionee != null)
            {
                ImagePoke.Source = ImageSource.FromFile(imageSelectionee.Path);
                BoutonImage.Text = "Changer l'Image";
            }
            
        }
    }
}