# XamarinLaunchFromBrowser

※Xamarin.Forms 製のサンプルですが今のところ Android にしか対応していません。

## Screenshots

<img src="https://raw.githubusercontent.com/xamarin-samples/XamarinLaunchFromBrowser/master/screenshots/browser.png" width="200">  
　　↓  
　　↓ Link click   
　　↓  
<img src="https://raw.githubusercontent.com/xamarin-samples/XamarinLaunchFromBrowser/master/screenshots/app.png" width="200">  

## Pickuped code
### Droid: MainActivity.cs
```cs
....
using Android.OS;
using Android.Content;
....
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
        ....
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
```

## sample-page.html
```html
<a href="hogeapp://main">Launch hogeapp (no parameter)</a>
<a href="hogeapp://main?param1=🍣XYZ🍣">Launch hogeapp (param1 = 🍣XYZ🍣)</a>
```
