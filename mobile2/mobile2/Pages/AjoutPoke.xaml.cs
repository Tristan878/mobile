using System;
using System.Collections.Generic;
using mobile2.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutPoke : ContentPage
    {
        public AjoutPoke()
        {
            InitializeComponent();
        }
        private async void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            await App.UserViewModel.AddNewUserAsync(newUser.Text);
            statusMessage.Text = App.UserViewModel.StatusMessage;
        }

        private async void OnGetButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            List<User> users = await App.UserViewModel.GetUsersAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Nom}");

                statusMessage.Text = App.UserViewModel.StatusMessage;
            }
        }
    }
}