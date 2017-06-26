using Android;
using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Pirana.Droid
{
    [Activity(
		Label = "Test Project"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Pirana.Droid.Resource.Layout.SplashScreen)
        {
        }
    }
}