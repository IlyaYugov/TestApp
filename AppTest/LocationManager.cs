using System;
using CoreLocation;
using Foundation;
using UIKit;

namespace AppTest
{
    public class LocationManager
    {
        public static Action<double,double,DateTime> LocationTracked;
        private static CLLocationManager _locMgr;

        private LocationManager()
        {
        }

        public static void StartMonitoring()
        {
            if (CLLocationManager.Status == CLAuthorizationStatus.NotDetermined)
            {
                _locMgr.RequestAlwaysAuthorization();
            }
            if (CLLocationManager.Status == CLAuthorizationStatus.Denied)
            {
                Console.WriteLine("Включите геолокацию вручную");
            }

            _locMgr.StartUpdatingLocation();
        }

        public static void StartGeolocationUpdate()
        {
            if (_locMgr == null)
            {
                _locMgr = new CLLocationManager
                {
                    PausesLocationUpdatesAutomatically = false,
                    AllowsBackgroundLocationUpdates = true
                };
            }

            _locMgr.LocationsUpdated += (sender, args) =>
            {
                _locMgr.StopUpdatingLocation();
                LocationTracked(_locMgr.Location.Coordinate.Longitude, _locMgr.Location.Coordinate.Latitude, (DateTime)_locMgr.Location.Timestamp);
            };

            _locMgr.AuthorizationChanged += (sender, args) =>
            {
                if (CLLocationManager.Status != CLAuthorizationStatus.AuthorizedAlways)
                {
                    Console.WriteLine("Включите геолокацию вручную");
                }
            };
            StartMonitoring();

        }
    }
}
