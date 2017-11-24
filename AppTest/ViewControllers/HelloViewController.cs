using System;
using CoreGraphics;
using CoreLocation;
using UIKit;

namespace AppTest.ViewControllers
{
    public class HelloViewController  : UIViewController
    {
        private UIButton _btn;
        private LocationManager mgr;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "StartTimerForLocationTracking View";
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
        }

        private void BtnOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            LocationManager.StartGeolocationUpdate();
            TrackingTimer timer = new TrackingTimer();
            timer.StartTimerForLocationTracking();

            LocationManager.LocationTracked += (d, d1, arg3) =>
            {
                timer.Stop();
                if (d != 0 && d1 != 0)
                {
                    InsertToDataBase();
                }
            };

            //mgr.StartMonitoring();
            //if (!mgr.IsActiveStatus())
            //{
            //    Title = "Включить геолокацию";
            //    return;
            //}          
            //_btn.SetTitle(mgr.Time.ToString(),UIControlState.Normal);
            //Title = mgr.Coordinate.ToString();

            //var t = mgr.Coordinate.Latitude;
            //var t = mgr.Coordinate.Longitude;

            //ExampleTableViewController viewController = new ExampleTableViewController();
            //NavigationController.PushViewController(viewController,true);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _btn.TouchUpInside += BtnOnTouchUpInside;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            _btn.TouchUpInside -= BtnOnTouchUpInside;
        }

        private void InsertToDataBase()
        {
            
        }

    }
}
