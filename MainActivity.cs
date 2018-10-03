using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;

namespace testapp
{
    [Activity(Label = "testapp", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, ConfigurationChanges = ConfigChanges.Locale | ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.MainApp);
            Button showSignIn = FindViewById<Button>(Resource.Id.showSignInView);
            //var adapter = FindViewById<Spinner>(Resource.Id.spinner1);
            
            init_MainTabs();
            init_BuySellTabs();

            var adapter = FindViewById<Spinner>(Resource.Id.spinner1);

            adapter.TextAlignment = TextAlignment.Inherit;
            var y = adapter.TextAlignment;
            adapter.SetSelection(0);          

            adapter.ItemSelected += onItemSelected_lang;
            //showSignIn.Click += ShowSignInLayout;
            //BaseContext.Resources.Configuration.Locale = new Java.Util.Locale("es");
            //var t = Resources.Configuration.Locale;
            //EditText loginField = FindViewById<EditText>(Resource.Id.loginfield);
            //passwordField = FindViewById<EditText>(Resource.Id.passwordfield);
            //passwordField.EditorAction += EditorAction;
            //Button RegisterBtn = FindViewById<Button>(Resource.Id.signup);
            //RegisterBtn.Click += (o, e) => SetContentView(Resource.Layout.Register);
        }

        //public void onItemSelected(object o, AdapterView.ItemSelectedEventArgs e)
        //{
        //    var t = (AdapterView)o;
        //    ((TextView)t.GetChildAt(0)).SetTextColor(new Color(156, 156, 156));
        //    ((TextView)t.GetChildAt(0)).TextSize = ConvertToDp(10);

        //}
        public void onItemSelected_lang(object o, AdapterView.ItemSelectedEventArgs e)
        {
            var t = (AdapterView)o;
            ((TextView)t.GetChildAt(0)).Gravity = GravityFlags.Center;
            //((TextView)t.GetChildAt(0)).TextSize = ConvertToDp(10);

        }

        //public void faqOnclick(View v)
        //{

        //}
        private void init_MainTabs()
        {
            TabHost tabHost = (TabHost)FindViewById(Resource.Id.MainTabHost);
            // инициализация
            tabHost.Setup();
            TabHost.TabSpec tabSpec;
            //tabHost.SetBackgroundColor(new Color(245, 245, 245));

            tabSpec = tabHost.NewTabSpec(Resources.GetString(Resource.String.Main_Tab1));
            tabSpec.SetIndicator(Resources.GetString(Resource.String.Main_Tab1));
            tabSpec.SetContent(Resource.Id.Main_Tab1);
            tabHost.AddTab(tabSpec);

            CreateOperations();
            tabSpec = tabHost.NewTabSpec(Resources.GetString(Resource.String.Main_Tab2));
            tabSpec.SetIndicator(Resources.GetString(Resource.String.Main_Tab2));
            tabSpec.SetContent(Resource.Id.Main_Tab2);
            tabHost.AddTab(tabSpec);

            
            tabSpec = tabHost.NewTabSpec(Resources.GetString(Resource.String.Main_Tab3));
            tabSpec.SetIndicator(Resources.GetString(Resource.String.Main_Tab3));
            tabSpec.SetContent(Resource.Id.Main_Tab3);
            tabHost.AddTab(tabSpec);

            init_faqlayout(FindViewById<FrameLayout>(Resource.Id.Main_Tab4));
            tabSpec = tabHost.NewTabSpec(Resources.GetString(Resource.String.Main_Tab4));
            tabSpec.SetIndicator(Resources.GetString(Resource.String.Main_Tab4));
            tabSpec.SetContent(Resource.Id.Main_Tab4);
            tabHost.AddTab(tabSpec);

            tabHost.TabWidget.StripEnabled = false;
            //tabHost.TabWidget.GetChildAt(tabHost.CurrentTab).Background.SetColorFilter(Color.Red, PorterDuff.Mode.Multiply);
            for (int i = 0; i < tabHost.TabWidget.ChildCount; i++)
            {
                View v = tabHost.TabWidget.GetChildAt(i);

                //ImageView ll = new ImageView(this);
                //LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(10, 10);
                //lp.Gravity = GravityFlags.Bottom;
                //ll.LayoutParameters = lp;
                //ll.SetBackgroundResource(Resource.Drawable.green2px);
                

                
                //tabHost.TabWidget.GetChildAt(i).
                RelativeLayout rl = (RelativeLayout)tabHost.TabWidget.GetChildAt(i);
                rl.SetBackgroundResource(Resource.Drawable.MainTabSelector);
                rl.SetGravity(GravityFlags.CenterVertical);

                TextView textView = (TextView)rl.GetChildAt(1);
                textView.SetMaxHeight(100);
                textView.Gravity = GravityFlags.Center;
                var xyi = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
                textView.LayoutParameters = xyi;
                var rlcustom = new LinearLayout.LayoutParams(0, RelativeLayout.LayoutParams.WrapContent, 3);
                rl.LayoutParameters = rlcustom;
                textView.SetTextColor(Resources.GetColor(Resource.Color.TabTextColor));
            }



            // tabHost.TabWidget.SetRightStripDrawable(Resource.Drawable.MainTabGreenLine);
            //tabHost.TabWidget.SetLeftStripDrawable(Resource.Drawable.MainTabGreenLine);
            //for (int i = 0; i < tabHost.TabWidget.ChildCount; i++)
            //{
            //    View v = tabHost.TabWidget.GetChildAt(i);
            //    v.SetBackgroundResource(Resource.Drawable.TabSelector);
            //    RelativeLayout rl = (RelativeLayout)tabHost.TabWidget.GetChildAt(i);
            //    rl.SetGravity(GravityFlags.CenterVertical);

            //    TextView textView = (TextView)rl.GetChildAt(1);
            //    textView.SetTextColor(Resources.GetColorStateList(Resource.Drawable.TabTextColorLogic));
            //    textView.SetMaxHeight(100);
            //    var xyi = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);

            //    textView.LayoutParameters = xyi;

            //    textView.SetTypeface(null, TypefaceStyle.Bold);
            //    textView.Gravity = GravityFlags.Center;
            //    textView.SetTextSize(Android.Util.ComplexUnitType.Dip, 20);
            //    //tabHost.TabWidget.GetChildAt(i).LayoutParameters.Height = 120;
            //}
        }
        private void CreateOperations()
        {
            for (int i = 0; i < 12; i++)
            {
                addToFeed();
            }
        }
        private void addToFeed()
        {
            LinearLayout OperationFeed = (LinearLayout)FindViewById(Resource.Id.OperationFeed);

            LinearLayout.LayoutParams Prms = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            LinearLayout ll1 = new LinearLayout(this);
            ll1.LayoutParameters = Prms;
            ll1.SetBackgroundDrawable(GetDrawable(Resource.Drawable.BottomBorder));
            ll1.Orientation = Android.Widget.Orientation.Horizontal;
            ll1.SetPadding(0, 0, (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 3, Resources.DisplayMetrics), 0);
            Prms = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent, 25);

            LinearLayout ll2 = new LinearLayout(this);
            ll2.LayoutParameters = Prms;
            ll2.Orientation = Android.Widget.Orientation.Vertical;

            Prms = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 0, 1);
            Prms.Gravity = GravityFlags.CenterVertical;
            TextView tw1 = new TextView(this);
            tw1.SetTextColor(Resources.GetColor(Resource.Color.TextColor));
            tw1.SetPadding((int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.DisplayMetrics), 0, 0, 0);
            tw1.Text = "USD";
            tw1.Gravity = GravityFlags.CenterVertical;
            tw1.LayoutParameters = Prms;

            TextView tw2 = new TextView(this);
            tw2.SetPadding((int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.DisplayMetrics), 0, 0, 0);
            tw2.Text = "USD1";
            tw2.SetTextColor(Resources.GetColor(Resource.Color.TextColor));
            tw2.Gravity = GravityFlags.CenterVertical;
            tw2.LayoutParameters = Prms;

            ll1.AddView(ll2);
            ll2.AddView(tw1);
            ll2.AddView(tw2);


            Prms = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent, 25);

            LinearLayout ll4 = new LinearLayout(this);
            ll4.LayoutParameters = Prms;
            ll4.Orientation = Android.Widget.Orientation.Vertical;

            Prms = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 0, 1);
            Prms.Gravity = GravityFlags.CenterVertical;
            TextView tw3 = new TextView(this);
            tw3.SetTextColor(Resources.GetColor(Resource.Color.TextColor));
            tw3.SetPadding(0, 0, (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.DisplayMetrics), 0);

            tw3.Gravity = GravityFlags.CenterVertical | GravityFlags.Right;
            tw3.Text = "USD";
            tw3.LayoutParameters = Prms;

            TextView tw4 = new TextView(this);
            tw4.SetTextColor(Resources.GetColor(Resource.Color.TextColor));
            tw4.SetPadding(0, 0, (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.DisplayMetrics), 0);
            tw4.Text = "USD1";
            tw4.Gravity = GravityFlags.CenterVertical | GravityFlags.Right;
            tw4.LayoutParameters = Prms;

            ll1.AddView(ll4);
            ll4.AddView(tw3);
            ll4.AddView(tw4);

            Prms = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent, 30);

            LinearLayout ll5 = new LinearLayout(this);
            ll5.LayoutParameters = Prms;
            ll5.Orientation = Android.Widget.Orientation.Vertical;

            Prms = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 0, 1);
            Prms.Gravity = GravityFlags.CenterVertical;
            TextView tw5 = new TextView(this);
            tw5.SetTextColor(Resources.GetColor(Resource.Color.TextColor));
            tw5.SetPadding((int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.DisplayMetrics), 0, 0, 0);
            tw5.Text = "USD";
            tw5.Gravity = GravityFlags.CenterVertical;
            tw5.LayoutParameters = Prms;

            TextView tw6 = new TextView(this);
            tw6.SetTextColor(Resources.GetColor(Resource.Color.TextColor));
            tw6.SetPadding((int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.DisplayMetrics), 0, 0, 0);
            tw6.Text = "USD1";
            tw6.Gravity = GravityFlags.CenterVertical;
            tw6.LayoutParameters = Prms;

            ll1.AddView(ll5);
            ll5.AddView(tw5);
            ll5.AddView(tw6);

            Prms = new LinearLayout.LayoutParams(0, (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 63, Resources.DisplayMetrics), 14);
            ImageView iw = new ImageView(this);
            iw.LayoutParameters = Prms;

            iw.SetPadding(0, 0, 0, (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 0, Resources.DisplayMetrics));
            iw.SetImageResource(Resource.Drawable.StatusOk);
            ll1.AddView(iw);

            OperationFeed.AddView(ll1);
        }
        private void init_BuySellTabs()
        {
            TabHost tabHost = (TabHost)FindViewById(Resource.Id.BuySellTabHost);
            // инициализация
            tabHost.Setup();
            TabHost.TabSpec tabSpec;
            //tabHost.SetBackgroundColor(new Color(240, 221, 52));
            tabSpec = tabHost.NewTabSpec(Resources.GetString(Resource.String.BuySellTab1));
            tabSpec.SetIndicator(Resources.GetString(Resource.String.BuySellTab1));
            tabSpec.SetContent(Resource.Id.BuySellTab1);
            tabHost.AddTab(tabSpec);
            tabSpec = tabHost.NewTabSpec(Resources.GetString(Resource.String.BuySellTab2));
            tabSpec.SetIndicator(Resources.GetString(Resource.String.BuySellTab2));
            tabSpec.SetContent(Resource.Id.BuySellTab2);
            tabHost.AddTab(tabSpec);
            //tabHost.TabWidget.SetBackgroundDrawable(GetDrawable(Resource.Drawable.TabSelector));
            tabHost.TabWidget.StripEnabled = false;

            for (int i = 0; i < tabHost.TabWidget.ChildCount; i++)
            {
                View v = tabHost.TabWidget.GetChildAt(i);
                v.SetBackgroundResource(Resource.Drawable.TabSelector);
                RelativeLayout rl = (RelativeLayout)tabHost.TabWidget.GetChildAt(i);
                rl.SetGravity(GravityFlags.CenterVertical);

                TextView textView = (TextView)rl.GetChildAt(1);
                textView.SetTextColor(Resources.GetColorStateList(Resource.Drawable.TabTextColorLogic));
                textView.SetMaxHeight(100);
                var xyi = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);

                textView.LayoutParameters = xyi;

                textView.SetTypeface(null, TypefaceStyle.Bold);
                textView.Gravity = GravityFlags.Center;
                textView.SetTextSize(Android.Util.ComplexUnitType.Dip, 20);
                //tabHost.TabWidget.GetChildAt(i).LayoutParameters.Height = 120;
            }
        }
        private void init_faqlayout(FrameLayout maintab3)
        {
            ScrollView faq_scroll_layout = new ScrollView(this)
            {
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            };
            LinearLayout questions_main_layout = new LinearLayout(this)
            {
                Orientation = Orientation.Vertical,
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };
            faq_scroll_layout.SetBackgroundColor(new Color(227, 221, 224));
            var faq_questions = Resources.GetStringArray(Resource.Array.faq);
            foreach (var question in faq_questions)
            {
                var texts = question.Split(':');

                LinearLayout questions_layout = new LinearLayout(this);
                questions_layout.Orientation = Orientation.Vertical;
                var question_layout_params = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                question_layout_params.SetMargins(0, ConvertToDp(5), 0, 0);
                questions_layout.LayoutParameters = question_layout_params;



                LinearLayout question_btn_layout = new LinearLayout(this);
                question_btn_layout.Orientation = Orientation.Horizontal;
                question_btn_layout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                question_btn_layout.Click += faqonclick;
                question_btn_layout.SetBackgroundColor(new Color(86, 214, 124));


                TextView question_btn_layout_text = new TextView(this);
                question_btn_layout_text.LayoutParameters = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WrapContent, 7);
                question_btn_layout_text.Text = texts[0];
                question_btn_layout_text.SetTextSize(Android.Util.ComplexUnitType.Dip, 15);
                question_btn_layout_text.SetPadding(ConvertToDp(15), ConvertToDp(15), ConvertToDp(15), ConvertToDp(15));
                question_btn_layout_text.SetBackgroundColor(new Color(255, 255, 255, 1));
                question_btn_layout_text.SetTextColor(new Color(245, 245, 245));


                LinearLayout question_btn_layout_arrow_layout = new LinearLayout(this);
                var question_btn_layout_arrow_params = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WrapContent, 3);
                question_btn_layout_arrow_layout.SetPadding(ConvertToDp(20), ConvertToDp(20), ConvertToDp(20), ConvertToDp(20));
                question_btn_layout_arrow_layout.SetGravity(GravityFlags.Center);


                ImageView question_btn_layout_arrow_layout_image = new ImageView(this);
                question_btn_layout_arrow_layout_image.LayoutParameters = new LinearLayout.LayoutParams(ConvertToDp(20), ConvertToDp(20));
                question_btn_layout_arrow_layout_image.Background = GetDrawable(Resource.Drawable.downarrow);

                TextView question_text = new TextView(this);
                var question_text_params = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                question_text.LayoutParameters = question_text_params;
                question_text.Text = texts[1];
                question_text.SetBackgroundColor(new Color(245, 245, 245));
                question_text.SetTextColor(new Color(156, 156, 156));
                question_text.SetTextSize(Android.Util.ComplexUnitType.Dip, 13);
                question_text.SetPadding(ConvertToDp(35), ConvertToDp(15), ConvertToDp(35), ConvertToDp(15));
                question_text.Alpha = 0.0f;
                question_text.Visibility = ViewStates.Gone;


                question_btn_layout.AddView(question_btn_layout_text);
                question_btn_layout_arrow_layout.AddView(question_btn_layout_arrow_layout_image);
                question_btn_layout.AddView(question_btn_layout_arrow_layout);
                questions_layout.AddView(question_btn_layout);
                questions_layout.AddView(question_text);
                questions_main_layout.AddView(questions_layout);
            }
            faq_scroll_layout.AddView(questions_main_layout);
            maintab3.AddView(faq_scroll_layout);
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
        public int ConvertToDp(int px)
        {
            return (int)(px * Resources.DisplayMetrics.Density + 0.5f);
        }
        
        public void EditorAction(object o, TextView.EditorActionEventArgs e)
        {
            // Click on signIn
        }
        public void ShowSignInLayout(object o, EventArgs e)
        {
            LinearLayout linearlayout = FindViewById<LinearLayout>(Resource.Id.signin);
            linearlayout.Visibility = ViewStates.Visible;
        }
        [Export("clicking")]
        public void clicking(View v)
        {
            LinearLayout linearlayout = FindViewById<LinearLayout>(Resource.Id.signin);
            linearlayout.Visibility = ViewStates.Visible;
        }
        [Export("CloseWindow")]
        public void CloseWindow(View v)
        {
            LinearLayout linearlayout = FindViewById<LinearLayout>(Resource.Id.signin);
            linearlayout.Visibility = ViewStates.Invisible;
        }

    }

}

