using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using mobile2.ViewModels;

namespace mobile2
{
    public partial class App : Application
    {
        private string dbPath = Path.Combine(FileSystem.AppDataDirectory, "pokebase.db3");
        public static PokeBddViewModel PokeBddViewModel { get; private set; }
        public App()
        {
            InitializeComponent();

            PokeBddViewModel = new PokeBddViewModel(dbPath);
            MainPage = new HomePage();

            /*Permet de mettre la barre d'état en argenté et le texte de celle-ci en noir*/
            MainPage.SetValue(property: HomePage.BackgroundColorProperty, Color.Silver);
            MainPage.SetValue(property: HomePage.TitleColorProperty, Color.Black);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
