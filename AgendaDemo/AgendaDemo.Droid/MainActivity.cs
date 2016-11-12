using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using AgendaDemo;

namespace AgendaDemo.Droid
{
    [Activity(Label = "AgendaDemo", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity,Login
    {
        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient(Conexion.conexion);
        public async Task<bool>Authentication ()
        {
            var succes = false;
            try
            {
                user = await client.LoginAsync(this, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
                if (user != null)
                {
                    succes = true;
                }
            }
            catch (Exception ex )
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetMessage(ex.Message);
                builder.SetTitle("sing-in result");
                builder.Create().Show();
            }
            return succes;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

