using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;

using Android.Content;
using Java.Interop;
using Android.Provider;

namespace WebView_Demo
{
    [Activity(Label = "WebView_Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            WebView wv1 = FindViewById<WebView>(Resource.Id.webView1);
            string fileUrl = "file:///android_asset/HTML5_Demo.html";
            wv1.Settings.JavaScriptEnabled = true;
            wv1.AddJavascriptInterface(new MyJSInterface(this), "wx");
            // Need to accept permissions to use the camera


            wv1.LoadUrl(fileUrl);
            

        }


        class MyJSInterface : Java.Lang.Object
        {
            Context context;

            public MyJSInterface(Context context)
            {
                this.context = context;
            }
            [Export]
            [JavascriptInterface]
            public void CallCamera()
            {
                Toast.MakeText(context, "Hello from C#", ToastLength.Short).Show();
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                context.StartActivity(intent);
            }
        }
    }
}

