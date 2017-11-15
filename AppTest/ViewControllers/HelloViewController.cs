using System;
using System.Threading;
using CoreGraphics;
using CoreLocation;
using UIKit;

namespace AppTest.ViewControllers
{
    public class HelloViewController  : UIViewController
    {
        private UIButton _btn;
        private CLLocationManager mgr;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Start View";
            _btn = new UIButton()
            {
                Frame = new CGRect(0, View.Frame.Height/2.0-50, View.Frame.Width, 100),
                BackgroundColor = UIColor.Gray,
            };

            _btn.SetTitleColor(UIColor.Red, UIControlState.Normal);

            _btn.SetTitle("!!!!! Click Me !!!!!", UIControlState.Normal);
            _btn.AutoresizingMask = UIViewAutoresizing.All;
            _btn.AutosizesSubviews = true;
           
            View.AddSubview(_btn);

            View.BackgroundColor = UIColor.Green;

            mgr = new CLLocationManager();
            mgr.RequestAlwaysAuthorization();
            mgr.RequestWhenInUseAuthorization();

        }

        private void BtnOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            //var btn = (UIButton)sender;

            //btn.SetTitle("Button ck", UIControlState.Normal);
            mgr.StartUpdatingLocation();
            mgr.StopUpdatingLocation();

            //mgr.RequestAlwaysAuthorization(); //to access user's location in the background
            //mgr.RequestWhenInUseAuthorization(); //to access user's location when the app is in use.
            //mgr.StartMonitoringSignificantLocationChanges();
            //mgr.StopMonitoringSignificantLocationChanges();

            var location = mgr.Location;
            //mgr.AllowsBackgroundLocationUpdates = true;


            ExampleTableViewController viewController = new ExampleTableViewController();

            NavigationController.PushViewController(viewController,true);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _btn.TouchUpInside += BtnOnTouchUpInside;

            mgr.LocationsUpdated += (sender, e) =>
            {
                foreach (var loc in e.Locations)
                {
                    Console.WriteLine(loc);
                }
            };

            if (CLLocationManager.LocationServicesEnabled)
            {
                mgr.StartMonitoringSignificantLocationChanges();
            }
            else
            {
                Console.WriteLine("Location services not enabled, please enable this in your Settings");
            }

            mgr.StopMonitoringSignificantLocationChanges();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            _btn.TouchUpInside -= BtnOnTouchUpInside;
        }

    }
}
