using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Java.Interop;
using System;

namespace testapp
{
    [Activity(Label = "testapp", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, ConfigurationChanges = ConfigChanges.Locale | ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        EditText passwordField;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.profile);
            Button showSignIn = FindViewById<Button>(Resource.Id.showSignInView);
            var adapter = FindViewById<Spinner>(Resource.Id.spinner1);

            //adapter.ItemSelected += onItemSelected;
            //showSignIn.Click += ShowSignInLayout;
            //BaseContext.Resources.Configuration.Locale = new Java.Util.Locale("es");
            //var t = Resources.Configuration.Locale;
            //EditText loginField = FindViewById<EditText>(Resource.Id.loginfield);
            //passwordField = FindViewById<EditText>(Resource.Id.passwordfield);
            //passwordField.EditorAction += EditorAction;
            //Button RegisterBtn = FindViewById<Button>(Resource.Id.signup);
            //RegisterBtn.Click += (o, e) => SetContentView(Resource.Layout.Register);
        }

        public void onItemSelected(object o, AdapterView.ItemSelectedEventArgs e)
        {
            var t = (AdapterView)o;
            ((TextView)t.GetChildAt(0)).SetTextColor(new Color(156, 156, 156));
            ((TextView)t.GetChildAt(0)).TextSize = 15;

        }


        public void EditorAction(object o, TextView.EditorActionEventArgs e)
        {
            // Click on signIn
        }
        public void ShowSignInLayout(object o, EventArgs e)
        {
            LinearLayout linearlayout = FindViewById<LinearLayout>(Resource.Id.signin_layout);
            linearlayout.Visibility = ViewStates.Visible;
        }
        [Export("clicking")]
        public void clicking(View v)
        {
            LinearLayout linearlayout = FindViewById<LinearLayout>(Resource.Id.signin_layout);
            linearlayout.Visibility = ViewStates.Visible;
        }
        [Export("CloseWindow")]
        public void CloseWindow(View v)
        {
            LinearLayout linearlayout = FindViewById<LinearLayout>(Resource.Id.signin_layout);
            linearlayout.Visibility = ViewStates.Invisible;
        }

    }
}

