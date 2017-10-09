using App1.Models;
using App1.Services;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnnoncePage : ContentPage
    {
        public AnnoncePage()
        {var vm = new AnnonceViewModel();
            BindingContext = vm;
            InitializeComponent();
           
        }
 private void SelectedAnnonce(Object sender, ItemTappedEventArgs e) {

            AnnonceService.annonce = e.Item as Annonce;
            Navigation.PushAsync(new ItemPage());

        }
     
        private void NouvelleAnnonce(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NouvelleAnnonce());

        }
    }
   
}