// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainActivity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    
using XLabs.Forms;

namespace App1.Droid
{

    /// <summary>
    /// Defines the MainActivity type.
    /// </summary>
    [Activity(Label = "App1", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}
