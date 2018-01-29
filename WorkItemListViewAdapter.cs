using Android.App;
using Android.Views;
using Android.Widget;

namespace LongTech.Techie
{
  public class WorkItemListViewAdapter : BaseAdapter<string>
  {
    private WorkItem[] items;
    private Activity context;

    public WorkItemListViewAdapter(Activity context, WorkItem[] items) : base()
    {
      this.context = context;
      this.items = items;
    }
    public override long GetItemId(int position)
    {
      return position;
    }
    public override string this[int position]
    {
      get { return items[position].JobDescription; }
    }
    public override int Count
    {
      get { return items.Length; }
    }
    public override View GetView(int position, View convertView, ViewGroup parent)
    {
      var view = convertView; // re-use an existing view, if one is available
      if (view == null) // otherwise create a new one
        view = context.LayoutInflater.Inflate(Resource.Layout.work_item_listview_adapter, null);

      TextView textViewWorkItemJobDescription = view.FindViewById<TextView>(Resource.Id.textViewWorkItemJobDescription);
      TextView textViewWorkItemClientName = view.FindViewById<TextView>(Resource.Id.textViewWorkItemClientName);
      ImageButton imageButtonWorkItemJobStatus = view.FindViewById<ImageButton>(Resource.Id.imageButtonWorkItemJobStatus);

      WorkItem it = items[position];

      if (it != null)
      {
        // imageButtonWorkItemJobStatus.SetImageDrawable();
        textViewWorkItemJobDescription.Text = it.JobDescription;
        textViewWorkItemClientName.Text = it.ClientName;
      }
      else
      {
        // imageButtonWorkItemJobStatus.SetImageDrawable();
        textViewWorkItemJobDescription.Text = "UNKNOWN";
        textViewWorkItemClientName.Text = "UNKNOWN";
      }

      return view;
    }
  }
}
