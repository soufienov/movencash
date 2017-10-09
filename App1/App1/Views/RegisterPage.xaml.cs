using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
          
           BindingContext = new RegisterViewModel();
            InitializeComponent();
        }
        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new LoginPage());
        }
    }
}