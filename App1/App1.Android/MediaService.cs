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
using Xamarin.Forms;
using App1.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MediaService))]
namespace App1.Droid
{
    class MediaService : Java.Lang.Object, IMediaService
    {
        public MediaService()
        {
        }

        public void OpenGallery()
        {

            Toast.MakeText(Xamarin.Forms.Forms.Context, "Select max 20 images", ToastLength.Long).Show();
            var imageIntent = new Intent(
                Intent.ActionPick);
            imageIntent.SetType("image/*");
            imageIntent.PutExtra(Intent.ExtraAllowMultiple, true);
            imageIntent.SetAction(Intent.ActionGetContent);
            ((Activity)Forms.Context).StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 0);



        }

    }
}