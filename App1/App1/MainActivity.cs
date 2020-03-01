using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private int n = 0;
        private TextView t1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);           
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            t1=FindViewById<TextView>(Resource.Id.textView1);
            Button b1=FindViewById<Button>(Resource.Id.button1);
            b1.Click += B1_Click;
            b1.Click += B2_Click;
        }

        private void B1_Click(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
            n++;
            t1.Text = n.ToString();
        }

        private void B2_Click(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
            n++; n++; n--;
            t1.Text = n.ToString();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}