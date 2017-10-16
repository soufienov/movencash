using App1.Controls;
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
    public partial class Images : ContentPage
    {
        public Images()
        {
            BindingContext = new ImagesViewModel();
            InitializeComponent();
           
        }
      

        private void opengallery(object sender, EventArgs e)
        {
 DependencyService.Get<IMediaService>().OpenGallery() ;
        }
    }
}