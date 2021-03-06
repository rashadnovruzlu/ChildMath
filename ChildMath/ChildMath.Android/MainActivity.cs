﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace ChildMath.Droid
{
    [Activity(Label = "ChildMath", ScreenOrientation =ScreenOrientation.Landscape, Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);             

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            
        }


    }
}

