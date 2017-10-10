using App1.Services;
using App1.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class LoginViewModel
    {
        UserService userservice = new UserService();
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Mid { get; set; }
        public string Password { get; set; }
        public INavigation Navigation;
        public LoginViewModel()
        {

        }
        public ICommand LoginCmd
        {
            get
            {
                return new Command(async
                    () => {



                        var resp = await userservice.Login( Email, Password);
                        if (Application.Current.Properties.ContainsKey("user"))
                        {
                            dynamic user =Application.Current.Properties["user"] ;
                            string id = user.mid;
                            if (id.Length > 0) {
                                await Navigation.PushAsync(new AnnoncePage());
                            }
                        }
                        
                    });
            }
        }
        public ICommand testLoginCmd
        {
            get
            {
                return new Command(async
                    () => {



                        var resp = await userservice.Login("go@go.tn", "123456");
                        if (Application.Current.Properties.ContainsKey("user"))
                        {
                            dynamic user = Application.Current.Properties["user"];
                            string id = user.mid;
                            if (id.Length > 0)
                            {
                                await Navigation.PushAsync(new AnnoncePage());
                            }
                        }

                    });
            }
        }
    }
}
