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
    Fragment[] _fragments;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
      SetContentView(Resource.Layout.TechieActivity);

      _fragments = new Fragment[]
      {
        new AvailableWorkFragment(),
        new MyProfileFragment(),
        new MyWorkFragment()
      };

      AddTabToActionBar(Resource.String.tab_label_myprofile, Resource.Drawable.ic_action_whats_on);
      AddTabToActionBar(Resource.String.tab_label_mywork, Resource.Drawable.ic_action_speakers);
      AddTabToActionBar(Resource.String.tab_label_availablework, Resource.Drawable.ic_action_sessions);
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

  public class MyProfileFragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      View view = inflater.Inflate(Resource.Layout.myprofile_fragment, null);

      return view;
    }
  }

  public class MyWorkFragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      View view = inflater.Inflate(Resource.Layout.mywork_fragment, null);
      var list = view.FindViewById<ListView>(Resource.Id.listViewMyWork);

      // TODO: Fill in the list of available work
      return view;
    }
  }

  public class AvailableWorkFragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      View view = inflater.Inflate(Resource.Layout.availablework_fragment, null);
      var list = view.FindViewById<ListView>(Resource.Id.listViewAvailableWork);

      // TODO: Fill in the list of available work
      return view;
    }
  }
}
