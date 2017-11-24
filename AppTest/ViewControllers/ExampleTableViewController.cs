using System;
using System.Collections.Generic;
using System.Linq;
using AppTest.Tables;
using CoreGraphics;
using UIKit;

namespace AppTest.ViewControllers
{
    class ExampleTableViewController : UIViewController
    {
        private UIBarButtonItem _barButtonItemBack;
        private UIBarButtonItem _barButtonItemNext;

        private TaskView _taskView;

        public override void ViewDidLoad()
        {
            //base.ViewDidLoad();

            Title = "UIViewController";

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

            var tasks = new List<TaskViewModel>();

            using (var connection = SQLLiteProvider.CreateConnection())
            {
                tasks = connection.Table<TaskTable>().Select(t => new TaskViewModel
                {
                    Date = t.Date,
                    Description =  t.Description,
                    ID = t.ID,
                    Name = t.Name
                }).ToList();
            }


            var searchFrame = new CGRect(0, 0, View.Frame.Width, InterfaceHelper.DefaultControlHeight);

            var tasksFrame = new CGRect(0,
                searchFrame.Height,
                View.Frame.Width,
                 UIScreen.MainScreen.ApplicationFrame.Height - NavigationController.NavigationBar.Frame.Height - searchFrame.Height);


            _taskView = new TaskView(tasksFrame, tasks);

            View.AddSubview(_taskView);

            base.ViewDidLoad();
        }

        private void BarButtonItemBackOnClicked(object sender, EventArgs eventArgs)
        {
            NavigationController.PopViewController(true);
        }

        private void BarButtonItemNextOnClicked(object sender, EventArgs eventArgs)
        {
            ExampleTableDVC tabledvc = new ExampleTableDVC();

            NavigationController.PushViewController(tabledvc,true);
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

        private void SearchRequestedHandler(object sender, EventArgs<string> args)
        {
            _taskView.PerformSearch(args.Content);
        }
    }
}
