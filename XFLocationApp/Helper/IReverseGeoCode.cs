using System;
using System.Threading.Tasks;
using XFLocationApp.Model;

namespace XFLocationApp.Helper
{
    public interface IReverseGeoCode
    {
        Task<LocationAddress> ReverseLocationAsync(double lat, double lng);
    }
}