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
        public NouvelleAnnonce()
        {
            
                var vm = new AnnonceViewModel();
                BindingContext = vm;
                InitializeComponent();
            
        }

        private void NouveauTitre(object sender, EventArgs e)
        {

        }

        private void NouveauLocal(object sender, EventArgs e)
        {

        }

        private void NouveauMotif(object sender, EventArgs e)
        {

        }
    }
}