using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace testapp
{
    [Activity(Label = "testapp", MainLauncher = true, ConfigurationChanges = ConfigChanges.Locale | ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        EditText passwordField;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
            SetContentView(Resource.Layout.Main);
            //BaseContext.Resources.Configuration.Locale = new Java.Util.Locale("es");
            //var t = Resources.Configuration.Locale;
            //EditText loginField = FindViewById<EditText>(Resource.Id.loginfield);
            //passwordField = FindViewById<EditText>(Resource.Id.passwordfield);
            //passwordField.EditorAction += EditorAction;
            Button RegisterBtn = FindViewById<Button>(Resource.Id.signup);
            RegisterBtn.Click += (o, e) => SetContentView(Resource.Layout.Register);
        }
        public void EditorAction(object o, TextView.EditorActionEventArgs e)
        {
            // Click on signIn
        }
        
    }
}

