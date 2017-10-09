using Android.Content.Res;
using Android.Util;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
   public  class RegisterViewModel
    {
        UserService userservice = new UserService();
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Mid { get; set; }
        public string Password { get; set; }
        public RegisterViewModel() {
          
        }
        public ICommand RegisterCmd {
            get {
                return new Command(async
                    ()=> {
                      
                      

                    var resp= await userservice.Register(Name,Lname,Email,Password);
                        Log.Error("resp", resp);
                    });
            }
        }
       
    }
}
