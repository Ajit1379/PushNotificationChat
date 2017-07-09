using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Gms.Common;
using Android.Util;
using System.Threading.Tasks;
using Firebase.Iid;
using Firebase;

namespace PushNotificationChat.Droid
{
    [Activity(Label = "PushNotificationChat", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            IsPlayServicesAvailable();

            var options = new FirebaseOptions.Builder()
                          .SetApplicationId("com.pushnotificationchat.android")
                          .SetApiKey("AIzaSyAoDPF9Qc3fDwppH6-dvc8Acuacs1k5NIA")
                          .SetGcmSenderId("513989846715")
                          .Build();
            var firebaseApp = FirebaseApp.InitializeApp(this, options);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Info("Google Play Service",GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Log.Info("Google Play Service","This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                Log.Info("Google Service","Google Play Services is available.");
                return true;
            }
        }
    }
}

