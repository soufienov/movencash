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
    public partial class NouvelleAnnonce : ContentPage
    {
        public Annonce Ann;
        public NouvelleAnnonce()
        {

            BindingContext = this;
           Ann = new Annonce();
                InitializeComponent();
            
        }

        private void NouveauTitre(object sender, TextChangedEventArgs e)
        {
            Ann.titre = e.NewTextValue;
        }

        private void NouvelleDesc(object sender, TextChangedEventArgs e)
        {
            Ann.titredesc = e.NewTextValue;
        }

       

        private void SetMotif(object sender, SelectedItemChangedEventArgs e)
        {
             Ann.motif = motifPicker.Items[motifPicker.SelectedIndex]; 
        }

        private void SetCategorie(object sender, SelectedItemChangedEventArgs e)
        {
            Ann.categorie = categoPicker.Items[categoPicker.SelectedIndex];
        }

        private void SetLocal(object sender, SelectedItemChangedEventArgs e)
        {
            Ann.local = localPicker.Items[localPicker.SelectedIndex];
        }

       

        private void Next(object sender, EventArgs e)
        {
            AnnonceService.annonce = Ann;
            Navigation.PushAsync(new Images());
        }

        private void NouveauAcces(object sender, TextChangedEventArgs e)
        {
            Ann.acces = e.NewTextValue;
        }

        private void SetPayement(object sender, SelectedItemChangedEventArgs e)
        {
            Ann.payement = payPicker.Items[payPicker.SelectedIndex];
        }

        private void publier_CheckedChanged(object sender, bool e)
        {
            if (e) Ann.publish = 1;
            else Ann.publish = 0;
        }
    }
}