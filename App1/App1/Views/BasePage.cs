using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Views
{
    public class BasePage : ContentPage
    {
        protected override void OnAppearing() // It will start immediately after the screen is appeared
        {
            base.OnAppearing();

            if (!App.IsLoggedIn)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}
