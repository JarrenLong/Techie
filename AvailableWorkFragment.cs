using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace LongTech.Techie
{
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
