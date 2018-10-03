
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace testapp
{
    [Activity(Label = "second", Theme = "@android:style/Theme.NoTitleBar", ConfigurationChanges = ConfigChanges.Locale | ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SecondActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            //StartActivity(new Intent(this, typeof(MainActivity)));   //Start Activity
            //SetContentView(Resource.Layout.faq);


            //var questionlayout_btn = (LinearLayout)questionlayout.GetChildAt(0);
            //var questionlayout_btn_text = ((TextView)(questionlayout_btn).GetChildAt(0));
            //var questionlayout_answer = ((TextView)questionlayout.GetChildAt(1));
            //questionlayout_btn.Click += faqonclick;

            #region faqlayout
            

            #endregion
            SetContentView(Resource.Layout.podderjkaforma);




            //var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            //SupportActionBar.SetDisplayShowTitleEnabled(false);
            //SupportActionBar.SetHomeButtonEnabled(true);
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.navigation);
            //drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            //navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
        }

        public int ConvertToDp(int px)
        {
            return (int)(px * Resources.DisplayMetrics.Density + 0.5f);
        }
        public void faqonclick(object o, EventArgs e)
        {
            var faqlayout_btn = o as LinearLayout;
            var faqlayout = faqlayout_btn.Parent as LinearLayout;
            var faqlayout_text = (TextView)faqlayout.GetChildAt(1);
            switch (faqlayout_text.Visibility)
            {
                case ViewStates.Gone:
                    faqlayout_text.Visibility = ViewStates.Visible;
                    faqlayout_text.Animate().SetDuration(400).Alpha(1.0f);
                    break;
                case ViewStates.Visible:
                    faqlayout_text.Alpha = 0;
                    faqlayout_text.Visibility = ViewStates.Gone;
                    break;
            }

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        
    }
}