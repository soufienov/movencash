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
    public partial class ItemPage : ContentPage
    {
        public ItemPage()
        {
          var  vm = new ItemViewModel();
            BindingContext = vm;
            InitializeComponent();
        }
        private void SelectedItem(Object sender, ItemTappedEventArgs e)
        {

            ItemService.item = e.Item as Item;
            //Navigation.PushAsync(new ItemPage());

        }

        private void NouveauElement(object sender, EventArgs e)
        {

        }
    }
}