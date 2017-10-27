using App1.Controls;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Images : ContentPage
    {
        private ICommand cmd;

        public Images()
        {cmd = new Command(() => Navigation.PopAsync());
            BindingContext = new ImagesViewModel();
            InitializeComponent();
            image0.GestureRecognizers.Add(new TapGestureRecognizer{ Command=cmd});
            
        }
      

        private void opengallery(object sender, EventArgs e)
        {
 DependencyService.Get<IMediaService>().OpenGallery() ;
        }
    }
}