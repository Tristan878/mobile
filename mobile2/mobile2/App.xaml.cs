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
        public static UserViewModel UserViewModel { get; private set; }
        public App()
        {
            InitializeComponent();

            UserViewModel = new UserViewModel(dbPath);

            MainPage = new MainPage();
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
