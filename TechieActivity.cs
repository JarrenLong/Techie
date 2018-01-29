using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace LongTech.Techie
{
  [Activity(Theme = "@style/TechieTheme", Label = "Techie", Icon = "@mipmap/icon")]
  public class TechieActivity : Activity
  {
    Fragment[] _fragments;
    public static WorkItem[] testWorkItems = new WorkItem[] {
      new WorkItem(){ Id=0,JobId="1",JobStatus = 0,JobPays=45, JobDescription="Computer Tune-up", ClientId="1",ClientName="Books N' Bytes, Inc.",ClientAddress="428 E. Wellesley Ave., Spokane, WA 99207",ClientEmail="info@booksnbytes.net",ClientPhone="(509)863-3316" },
      new WorkItem(){ Id=1,JobId="2",JobStatus = 1,JobPays=25, JobDescription="Computer Setup", ClientId="2",ClientName="Long Technical",ClientAddress="428 E. Wellesley Ave., Spokane, WA 99207",ClientEmail="info@booksnbytes.net",ClientPhone="(509)863-3316" },
      new WorkItem(){ Id=2,JobId="3",JobStatus = 2,JobPays=25, JobDescription="IT Support", ClientId="3",ClientName="Trillium IT",ClientAddress="428 E. Wellesley Ave., Spokane, WA 99207",ClientEmail="info@booksnbytes.net",ClientPhone="(509)863-3316" }
    };

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
      SetContentView(Resource.Layout.TechieActivity);

      _fragments = new Fragment[]
      {
        new MyProfileFragment(),
        new MyWorkFragment(),
        new AvailableWorkFragment()
      };

      AddTabToActionBar(Resource.String.tab_label_myprofile, Resource.Drawable.ic_action_whats_on);
      AddTabToActionBar(Resource.String.tab_label_mywork, Resource.Drawable.ic_action_speakers);
      AddTabToActionBar(Resource.String.tab_label_availablework, Resource.Drawable.ic_action_sessions);
    }

    private void AddTabToActionBar(int labelResourceId, int iconResourceId)
    {
      var tab = ActionBar.NewTab()
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
      var view = inflater.Inflate(Resource.Layout.myprofile_fragment, null);

      return view;
    }
  }

  public class MyWorkFragment : Fragment
  {
    private WorkItem[] itemList;
    private WorkItem selectedObject;
    private WorkItemListViewAdapter adapter;

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      var view = inflater.Inflate(Resource.Layout.mywork_fragment, null);

      // TODO: Fill in the list of available work
      itemList = TechieActivity.testWorkItems;
      //string[] parts = savedInstanceState.GetStringArray("Parts");
      //// Inflate the list of objects passed in
      //var partList = new List<object>();
      //foreach (var p in parts)
      //  partList.Add(InventoryObject.FromSerializedString(p));

      var list = view.FindViewById<ListView>(Resource.Id.listViewMyWork);
      if (list != null)
      {
        // Fill in the ListView
        adapter = new WorkItemListViewAdapter(Activity, itemList);

        list.Adapter = adapter;
        list.ItemClick += List_ItemClick;
      }
      return view;
    }

    private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
      selectedObject = null;
      if (e.Position >= 0 && e.Position < itemList.Length)
        selectedObject = itemList[e.Position];
    }
  }

  public class AvailableWorkFragment : Fragment
  {
    private WorkItem[] itemList;
    private WorkItem selectedObject;
    private WorkItemListViewAdapter adapter;

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      var view = inflater.Inflate(Resource.Layout.availablework_fragment, null);

      // TODO: Fill in the list of available work
      itemList = TechieActivity.testWorkItems;
      //string[] parts = savedInstanceState.GetStringArray("Parts");
      //// Inflate the list of objects passed in
      //var partList = new List<object>();
      //foreach (var p in parts)
      //  partList.Add(InventoryObject.FromSerializedString(p));

      var list = view.FindViewById<ListView>(Resource.Id.listViewAvailableWork);
      if (list != null)
      {
        // Fill in the ListView
        adapter = new WorkItemListViewAdapter(Activity, itemList);

        list.Adapter = adapter;
        list.ItemClick += List_ItemClick;
      }
      return view;
    }

    private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
      selectedObject = null;
      if (e.Position >= 0 && e.Position < itemList.Length)
        selectedObject = itemList[e.Position];
    }
  }
}
