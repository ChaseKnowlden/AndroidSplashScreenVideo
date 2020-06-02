using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Media.MediaPlayer;
using Android.Media;
using System.Threading.Tasks;
using Android.Content;

namespace AndroidSplashScreenVideo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnCompletionListener
    {
        VideoView videoView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var videoPath = $"android.resource://{PackageName}/raw/splash";

            videoView = FindViewById<VideoView>(Resource.Id.videoView);
            videoView.SetOnCompletionListener(this);
            videoView.SetVideoPath(videoPath);
            videoView.Start();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnCompletion(MediaPlayer mp)
        {
            Task.Delay(500)
                .ContinueWith(t =>
                {
                    StartActivity(new Intent(this, typeof(HomeActivity)));
                    Finish();
                });
        }
    }
}