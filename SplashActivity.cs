using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using System.Threading.Tasks;

namespace LongTech.Techie
{
  [Activity(Theme = "@style/TechieTheme.Splash", Icon = "@mipmap/icon", MainLauncher = true, NoHistory = true)]
  public class SplashActivity : Activity
  {
    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
      base.OnCreate(savedInstanceState, persistentState);

      Window.AddFlags(WindowManagerFlags.DismissKeyguard);
    }

    protected override void OnResume()
    {
      base.OnResume();
      Task startupWork = new Task(() => { LoadApp(); });
      startupWork.Start();
    }

    public override void OnBackPressed() { }

    public override void OnWindowFocusChanged(bool hasFocus)
    {
      base.OnWindowFocusChanged(hasFocus);

      if (!hasFocus)
      {
        var closeDialog = new Intent(Intent.ActionCloseSystemDialogs);
        SendBroadcast(closeDialog);
      }
    }

    async void LoadApp()
    {
      // Do initialization work here ...
      System.Threading.Thread.Sleep(3000);

      StartActivity(new Intent(Application.Context, typeof(TechieActivity)));
    }
  }
}
