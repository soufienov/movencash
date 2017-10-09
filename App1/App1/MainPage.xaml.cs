using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
namespace App1
{
    public partial class MainPage : ContentPage
    {
        public string message="nknrk";
        public MainPage()
        {
            InitializeComponent();
        }
       public ICommand LoginCmd{
            get { return new Command(() => { this.message = "clicked"; }); }
        }
    }
}
