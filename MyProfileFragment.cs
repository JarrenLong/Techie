using Android.App;
using Android.OS;
using Android.Views;

namespace LongTech.Techie
{
  public class MyProfileFragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      var view = inflater.Inflate(Resource.Layout.myprofile_fragment, null);

      return view;
    }
  }
}
