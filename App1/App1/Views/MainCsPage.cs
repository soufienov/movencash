﻿using GoogleLogin.Views;
using System;
using Xamarin.Forms;

namespace App1.Views
{
    public class MainCsPage : ContentPage
    {

        public MainCsPage()
        {
            Title = "Google Login";
            BackgroundColor = Color.White;

            var loginButton = new Button
            {
                Text = "Login with Google",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#db4437"),
                Font = Font.BoldSystemFontOfSize(26),
                FontSize = 26
            };

            loginButton.Clicked += LoginWithFacebook_Clicked;

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Label
                    {
                        Text = "Login with Google API",
                        FontSize = 66,
                        TextColor = Color.Black
                    },
                    loginButton
                }
            };
        }

        private async void LoginWithFacebook_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GoogleProfileCsPage());
        }
    }
}
// To use XAML pages, use the following code:
//
//<? xml version="1.0" encoding="utf-8" ?>
//<ContentPage xmlns = "http://xamarin.com/schemas/2014/forms"
//             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
//             x:Class="FacebookLogin.Views.MainPage"
//             Title="Facebook Login"
//             BackgroundColor="White">

//  <StackLayout Orientation = "Vertical" >

//    < Label Text="Login with Facebook API"
//           FontSize="60"
//           TextColor="Black"/>

//    <Button Text = "Login with Facebook"
//            TextColor="White" 
//            BackgroundColor="#01579B"
//            Font="Bold"
//            FontSize="26"
//            Clicked="LoginWithFacebook_Clicked"/>

//  </StackLayout>
///////////////////////////////////////////////////////////////////////////////////////////////////
// and the following for xaml.cs
//
//using System;
//using Xamarin.Forms;

//namespace FacebookLogin.Views
//{
//    public partial class MainPage : ContentPage
//    {
//        public MainPage()
//        {
//            InitializeComponent();
//        }

//        private async void LoginWithFacebook_Clicked(object sender, EventArgs e)
//        {
//            await Navigation.PushAsync(new FacebookProfilePage());
//        }
//    }
//}


