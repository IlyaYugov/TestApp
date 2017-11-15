using System;
using System.Collections.Generic;
using System.Linq;
//using MonoTouch.Dialog;
using AppTest.Tables;
using UIKit;

namespace AppTest.ViewControllers
{
    class ExampleTableDVC : UITableViewController
    {

        private UIBarButtonItem _barButtonItemBack;

        private UIBarButtonItem _barButtonItemNext;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "UITable";

            _barButtonItemBack = new UIBarButtonItem
            {
                Title = "Назад"
            };

            _barButtonItemNext = new UIBarButtonItem
            {
                Title = "Вперед"
            };

            NavigationItem.LeftBarButtonItem = _barButtonItemBack;

            NavigationItem.RightBarButtonItem = _barButtonItemNext;

            View.BackgroundColor = UIColor.White;

            using (var connection = SQLLiteProvider.CreateConnection())
            {
                var users = connection.Table<User>().ToList();
            }


            //RefreshControl = new UIRefreshControl();

            //_distributorsSection = new Section("Дистрибьюторы");

            //Root = new RootElement(Title) 
            //{
            //    _distributorsSection
			//};
        }

        ~ExampleTableDVC()
        {
            Console.WriteLine("qwe12312321");
        }

        private void BarButtonItemBackOnClicked(object sender, EventArgs eventArgs)
        {
            NavigationController.PopViewController(true);
        }

        private void BarButtonItemNextOnClicked(object sender, EventArgs eventArgs)
        {
            //HelloViewController startView = new HelloViewController();
            NavigationController.PopToRootViewController(true);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _barButtonItemBack.Clicked += BarButtonItemBackOnClicked;

            _barButtonItemNext.Clicked += BarButtonItemNextOnClicked;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            _barButtonItemBack.Clicked -= BarButtonItemBackOnClicked;

            _barButtonItemNext.Clicked -= BarButtonItemNextOnClicked;
        }
    }
}
