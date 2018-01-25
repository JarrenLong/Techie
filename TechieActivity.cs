using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LongTech.Techie
{
  [Activity(Theme = "@style/TechieTheme", Label = "Techie", Icon = "@mipmap/icon")]
  public class TechieActivity : Activity
  {
    static readonly string Tag = "ActionBarTabsSupport";

    Fragment[] _fragments;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
      SetContentView(Resource.Layout.TechieActivity);

      _fragments = new Fragment[]
      {
        new WhatsOnFragment(),
        new SpeakersFragment(),
        new SessionsFragment()
      };

      AddTabToActionBar(Resource.String.whatson_tab_label, Resource.Drawable.ic_action_whats_on);
      AddTabToActionBar(Resource.String.speakers_tab_label, Resource.Drawable.ic_action_speakers);
      AddTabToActionBar(Resource.String.sessions_tab_label, Resource.Drawable.ic_action_sessions);
    }

    private void AddTabToActionBar(int labelResourceId, int iconResourceId)
    {
      ActionBar.Tab tab = ActionBar.NewTab()
        .SetText(labelResourceId)
        .SetIcon(iconResourceId);
      tab.TabSelected += TabOnTabSelected;
      ActionBar.AddTab(tab);
    }

    private void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
    {
      tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayoutTechie, _fragments[((ActionBar.Tab)sender).Position]);
    }
  }

  public class SpeakersFragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      View view = inflater.Inflate(Resource.Layout.simple_fragment, null);
      view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.speakers_tab_label);
      view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.ic_action_speakers);
      return view;
    }
  }

  public class SessionsFragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      View view = inflater.Inflate(Resource.Layout.simple_fragment, null);
      view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.sessions_tab_label);
      view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.ic_action_sessions);
      return view;
    }
  }

  public class WhatsOnFragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      View view = inflater.Inflate(Resource.Layout.simple_fragment, null);
      view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.whatson_tab_label);
      view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.ic_action_whats_on);
      return view;
    }
  }
}
