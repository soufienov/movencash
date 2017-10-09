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
    public partial class NouveauItem : ContentPage
    {
        public NouveauItem()
        {
            var vm = new ItemViewModel();
            BindingContext = vm;
            InitializeComponent();
        }
    }
}