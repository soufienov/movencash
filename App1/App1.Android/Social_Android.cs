using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Controls;
using Xamarin.Auth;
using Xamarin.Forms.Platform.Android;
using Newtonsoft.Json;
[assembly: Xamarin.Forms.Dependency(typeof(App1.Droid.Social_Android))]
namespace App1.Droid
{
    class Social_Android : PageRenderer, ISocial
    {
        public void FacebookLogin()
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "396208700771880", // your OAuth2 client id
                scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri("http://m.facebook.com/dialog/oauth/"), // the auth URL for the service
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")); // the redirect URL for the service
            activity.StartActivity(auth.GetUI(activity));
            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.Completed += completeHandler;


        }

        public void GoogleLogin()
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "974260906488-bja5aic7tj2j1smk7ikh1vj5u7dd27sh.apps.googleusercontent.com", // your OAuth2 client id
               clientSecret: "bbmCXsAliOAerniYBVVhYCJ1",
                scope: "openid",
                 accessTokenUrl: new Uri("https://accounts.google.com/o/oauth2/token"),
                authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"), // the auth URL for the service
                redirectUrl: new Uri("https://www.movencash.com/")); // the redirect URL for the service
            activity.StartActivity(auth.GetUI(activity));
            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.Completed += completeHandler;


        }

        private async void completeHandler(Object sender,AuthenticatorCompletedEventArgs eventArgs) {
            if (eventArgs.IsAuthenticated)
            {
                //App.SuccessfulLoginAction.Invoke();
                // Use eventArgs.Account to do wonderful things
                string _token = eventArgs.Account.Properties["access_token"];

                App.SaveToken(_token);
                var uri = new Uri("https://graph.facebook.com/me?fields=name,email");
                var request = new OAuth2Request("GET", uri, null, eventArgs.Account);
                var response = await request.GetResponseAsync();
                var fbuser = JsonConvert.SerializeObject(response.GetResponseText());
                App.SaveUser(fbuser);
            }
            else
            {
                // The user cancelled
            }
        }
    }
}