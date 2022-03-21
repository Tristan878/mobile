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
        /* tableau des différents types pouvant être selectioné par un utilisateurs*/ 
        readonly string[] types = { "Acier","Combat","Dragon",
                                    "Eau","Électrik","Fée","Feu",
                                    "Glace","Insecte","Normal",
                                    "Plante","Poison","Psy","Roche","Sol",
                                    "Spectre","Ténèbres","Vol" };
    public AjoutPoke()
        {
            InitializeComponent();
            /*Pour rajouter le tableau des différents types possible dans les choix du picker*/
            foreach (string type in types)
            {
                NewType1.Items.Add(type);
                NewType2.Items.Add(type);
            }
        }
        

        /*methode permetant de créer un pokemon en bdd lorsque les champs sont bien remplis et que l'on clique sur un bouton ajouté*/
        async void OnNewButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewName.Text) && ImagePoke.Source != null && NewType1.SelectedIndex != -1)
            {
                /*On créer un nouveau pokemon en récupérant les informations rentrés dans la page AjoutPoke.xaml rentré par l'utilisateur.*/
                PokeBdd pokemon = new PokeBdd
                {
                    Name = NewName.Text,
                    Picture = ImagePoke.Source.ToString().Split(' ')[1],
                    Height = (int)NewHeight.Value,
                    Weight = (int)NewWeight.Value,
                    Hp = (int)NewHp.Value,
                    Type1 = NewType1.SelectedItem.ToString(),
                    Type2 = "",
                };

                /*Condistion pour savoir si un pokemon à un deuxième type (si oui il est récupéré).*/
                if (NewType2.SelectedIndex != -1)
                    pokemon.Type2 = NewType2.SelectedItem.ToString();
                
                /*Permet de sauvegarder notre pokemon dans notre bdd grace à la fonction SavePokeAsync*/
                await App.PokeBddViewModel.SavePokeAsync(pokemon);

                /*Les champs sont remis par défaut (du formulaire d'ajout).*/
                NewName.Text = "";
                ImagePoke.Source = null;
                NewHeight.Value = 1;
                NewWeight.Value = 1;
                NewHp.Value = 1;
                NewType1.SelectedIndex = -1;
                NewType2.SelectedItem = -1;
            } 
            else
            {
               await DisplayAlert("Champs obligatoires non remplis", "Le nom, l'image ou le type est manquant !", "J'ai compris");
            }
        }

        /*Permeet d'afficher l'entier choisie par l'utilisateur pour les 3 sliders du formulaire.*/
        public void ValeurSlider(object sender, EventArgs e)
        {
            if (sender == NewHeight)
                LabelHeight.Text = "Taille : " + ((int)NewHeight.Value).ToString();

            if (sender == NewWeight)
                LabelWeight.Text = "Poids : " + ((int)NewWeight.Value).ToString();

            if (sender == NewHp)
                LabelHp.Text = "Points de vie : " + ((int)NewHp.Value).ToString();
        }


        async void AjoutImage(object sender, EventArgs e)
        {
            /*Initialisation du nugget CrossMedia*/
            await CrossMedia.Current.Initialize();

            /*On véréfie si le téléphone supporte l'ajout d'image*/
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Non supporté", "Votre telephone ne " +
                    "supporte pas cette fonctionnalitée", "Ok");
                return;
            }

            /*Permet d'optimiser la taille et la qualité de la photo séléctionné*/
            var mediaOptions = new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full,
                CompressionQuality = 40
            };

            
            var imageSelectionee = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            /*Permet de changer le texte du bouton "Ajouter une image"*/
            if (imageSelectionee != null)
            {
                ImagePoke.Source = ImageSource.FromFile(imageSelectionee.Path);
                ImageBoutton.Text = "Changer l'Image";
            }
            
        }
    }
}