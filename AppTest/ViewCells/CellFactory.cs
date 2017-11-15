using CoreGraphics;
using UIKit;

namespace AppTest
{
    public static class CellFactory
    {
        #region >>> Public Fields

        public const float SeparatorHeight = 0.5f;

        #endregion <<< Public Fields

        #region >>> Public Methods

        public static UIView CreateContainer(CGRect contentFrame)
        {
            float offset = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? 20 : 10;
            var containerFrame = new CGRect(offset, 0, contentFrame.Width - offset * 2, contentFrame.Height - SeparatorHeight);
            return new UIView(containerFrame);
        }

        public static UILabel CreateLabel(CGRect frame)
        {
            return new UILabel(frame)
            {
                Font = InterfaceHelper.MainFont
            };
        }

        public static UIView CreateSeparatorLine(CGRect contentFrame)
        {
            return new UIView(new CGRect(contentFrame.X, contentFrame.Bottom - SeparatorHeight, contentFrame.Width, SeparatorHeight))
            {
                BackgroundColor = UIColor.LightGray
            };
        }

        #endregion <<< Public Methods
    }
}
