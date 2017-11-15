using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AppTest
{
    public class TaskCell : UITableViewCell
    {
        #region >>> Static Members

        public static NSString CellId = new NSString(typeof(TaskCell).Name);

        #endregion <<< Static Members

        #region >>> Constructors

        [Export("initWithFrame:")]
        public TaskCell()
        {
            Initialize();
        }

        public TaskCell(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        private void Initialize()
        {
            var contentFrame = ContentView.Frame;
            ContainerView = CellFactory.CreateContainer(contentFrame);
            var containerFrame = ContainerView.Frame;

            var leftLblFrame = new CGRect(0, 0, containerFrame.Width - containerFrame.Width / 3, containerFrame.Height / 3);
            LeftLabel = CellFactory.CreateLabel(leftLblFrame);
            ContainerView.AddSubview(LeftLabel);

            var rightLblFrame = new CGRect(containerFrame.Width - containerFrame.Width / 3, 0,
                containerFrame.Width / 3, containerFrame.Height / 3);
            RightLabel = CellFactory.CreateLabel(rightLblFrame);
            RightLabel.TextColor = UIColor.Blue;
            RightLabel.TextAlignment = UITextAlignment.Right;
            ContainerView.AddSubview(RightLabel);

            var middLeLblFrame = new CGRect(0, containerFrame.Height / 3, containerFrame.Width, containerFrame.Height / 3);
            MiddleLabel = CellFactory.CreateLabel(middLeLblFrame);
            MiddleLabel.Lines = 2;
            ContainerView.AddSubview(MiddleLabel);

            var bottomLblFrame = new CGRect(0, containerFrame.Height - containerFrame.Height / 3, containerFrame.Width,
                containerFrame.Height / 3);
            BottomLabel = CellFactory.CreateLabel(bottomLblFrame);
            BottomLabel.Lines = 2;
            ContainerView.AddSubview(BottomLabel);

            SeparatorView = CellFactory.CreateSeparatorLine(contentFrame);

            IndicatorView = new UIView(new CGRect(contentFrame.X, contentFrame.Y, 4, contentFrame.Bottom - 1))
            {
                BackgroundColor = UIColor.Green,
                Hidden = true
            };

            ContentView.AddSubview(ContainerView);
            ContentView.AddSubview(SeparatorView);
            ContentView.AddSubview(IndicatorView);
        }

        #endregion <<< Constructors

        #region >>> Public Properties

        public UILabel LeftLabel { get; set; }

        public UILabel RightLabel { get; set; }

        public UILabel MiddleLabel { get; set; }

        public UILabel BottomLabel { get; set; }

        public UIView SeparatorView { get; set; }

        public UIView IndicatorView { get; set; }

        public UIView ContainerView { get; set; }

        #endregion <<< Public Properties
    }
}
