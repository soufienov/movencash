using App1.Controls;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage1 : ContentPage
    {
        public LoginPage1()
        {var vm= new LoginViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;

            InitializeComponent();
        }

        private void fblog(object sender, EventArgs e)
        {
            var profilePage = new ProfilePage();
            var device = Resolver.Resolve<IDevice>();

            ////RM: hack for working on windows phone? 
            var mp = DependencyService.Get<ISocial>();
            mp.FacebookLogin();
        }

        private void gllog(object sender, EventArgs e)
        {
            var profilePage = new ProfilePage();
            var device = Resolver.Resolve<IDevice>();

            ////RM: hack for working on windows phone? 
            var mp = DependencyService.Get<ISocial>();
            mp.GoogleLogin();
        }
    }
}