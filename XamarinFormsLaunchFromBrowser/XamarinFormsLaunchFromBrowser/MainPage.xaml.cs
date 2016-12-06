using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsLaunchFromBrowser
{
    public partial class MainPage : ContentPage
    {
        public static string LaunchParameterString = "NO PARAMETER";

        public MainPage()
        {
            InitializeComponent();

            MainLabel.Text = LaunchParameterString;
        }
    }
}
