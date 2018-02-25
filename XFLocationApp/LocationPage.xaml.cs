using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace XFLocationApp
{
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
        }


        void GetLocation_Clicked(object sender, System.EventArgs e)
        {
            Task.Run(async () =>
            {
                try
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 10000;
                    var position = await locator.GetPositionAsync(new TimeSpan(0, 0, 5));
                    var currentLat = position.Latitude;
                    var currentLong = position.Longitude;
                    var address = await DependencyService.Get<Helper.IReverseGeoCode>().ReverseLocationAsync(currentLat, currentLong);
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        lblLocation.Text = address.City;
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }
    }
}