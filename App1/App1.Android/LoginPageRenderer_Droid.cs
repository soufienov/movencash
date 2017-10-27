using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using App1.Controls;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using App1.Droid;
using App1.Views;
using Xamarin.Forms;
using Xamarin.Auth;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer_Droid))]
namespace App1.Droid
{
    public class LoginPageRenderer_Droid : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "396208700771880", // your OAuth2 client id
                scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri("http://m.facebook.com/dialog/oauth/"), // the auth URL for the service
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")); // the redirect URL for the service
   activity.StartActivity(auth.GetUI(activity));
            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    App.SuccessfulLoginAction.Invoke();
                    // Use eventArgs.Account to do wonderful things
                    string _token = eventArgs.Account.Properties["access_token"];
                    App.SaveToken(_token);
                }
                else
                {
                    // The user cancelled
                }
            };


         
        }
    }
}