using System;
using System.Threading.Tasks;
using CoreLocation;
using Xamarin.Forms;
using XFLocationApp.Helper;
using XFLocationApp.iOS.Helper;
using XFLocationApp.Model;

[assembly: Dependency(typeof(ReverseGeoCode))]
namespace XFLocationApp.iOS.Helper
{
    public class ReverseGeoCode : IReverseGeoCode
    {
        public async Task<LocationAddress> ReverseLocationAsync(double lat, double lng)
        {
            var geoCoder = new CLGeocoder();
            var location = new CLLocation(lat, lng);
            var placemarks = await geoCoder.ReverseGeocodeLocationAsync(location);
            var place = new LocationAddress();
            var pm = placemarks[0];
            place.City = pm.AdministrativeArea;
            return place;
        }

    }
}