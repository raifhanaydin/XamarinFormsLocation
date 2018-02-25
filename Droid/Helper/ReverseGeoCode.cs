using System;
using System.Linq;
using System.Threading.Tasks;
using Android.Locations;
using Java.Util;
using Xamarin.Forms;
using XFLocationApp.Droid.Helper;
using XFLocationApp.Helper;
using XFLocationApp.Model;

[assembly: Dependency(typeof(ReverseGeoCode))]
namespace XFLocationApp.Droid.Helper
{
    public class ReverseGeoCode : IReverseGeoCode
    {
        public async Task<LocationAddress> ReverseLocationAsync(double lat, double lng)
        {
            var geo = new Geocoder(Android.App.Application.Context,Locale.Default);
            var addresses = await geo.GetFromLocationAsync(lat, lng, 1);
            if (addresses.Any())
            {
                var place = new LocationAddress();
                var add = addresses[0];
                place.City = add.Locality;
                place.Province = add.AdminArea;
                return place;
            }
            return null;
        }
    }
}
