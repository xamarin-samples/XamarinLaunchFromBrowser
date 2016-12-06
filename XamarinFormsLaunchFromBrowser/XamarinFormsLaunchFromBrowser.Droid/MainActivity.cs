using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace XamarinFormsLaunchFromBrowser.Droid
{
    [Activity(Label = "XamarinFormsLaunchFromBrowser", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [
        // この IntentFilter 指定により、
        // "hogeapp://main?param1=aaa&param2=bbb" のような URI でアプリを開くことができるようになる.
        IntentFilter(
            new[] { Intent.ActionView },
            Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
            DataScheme = "hogeapp",
            DataHost = "main"
        )
    ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // 起動時パラメータ取得
            if (Intent.ActionView.Equals(Intent.Action))
            {
                Android.Net.Uri uri = Intent.Data;
                if (uri != null)
                {
                    string param1 = uri.GetQueryParameter("param1");
                    if (!string.IsNullOrEmpty(param1))
                    {
                        MainPage.LaunchParameterString = param1;
                    }
                }
            }

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

