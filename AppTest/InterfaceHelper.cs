using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace AppTest
{
    public static class InterfaceHelper
    {
        #region >>> Private Fields

        private static bool? _isIphoneFourFamily;

        #endregion <<< Private Fields

        #region >>> Public Constants

        public const string YesButtonTitle = "Да";
        public const string NoButtonTitle = "Нет";

        #endregion <<< Public Constants

        #region >>> Public Properties

        public static bool IsIphone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public static bool IsIphoneFourFamily
        {
            get
            {
                if (_isIphoneFourFamily.HasValue) return _isIphoneFourFamily.Value;

                float screenWidth = 0;
                var nsObj = new NSObject();
                nsObj.InvokeOnMainThread(() =>
                {
                    screenWidth = (float)UIScreen.MainScreen.Bounds.Width;
                });

                _isIphoneFourFamily = DeviceHardware.Model == IosDeviceModels.iPhone4CDMA
                                      || DeviceHardware.Model == IosDeviceModels.iPhone4GSM
                                      || DeviceHardware.Model == IosDeviceModels.iPhone4S
                                      || (DeviceHardware.Model == IosDeviceModels.Simulator && screenWidth.Equals(320));

                return _isIphoneFourFamily.Value;
            }
        }

        public static UIFont MainFont
        {
            get { return UIFont.ItalicSystemFontOfSize(GetSmallFontSize()); }
        }

        public static UIFont BoldFont
        {
            get { return UIFont.ItalicSystemFontOfSize(GetMediumFontSize()); }
        }

        public static UIFont BoldMediumFont
        {
            get { return UIFont.BoldSystemFontOfSize(GetMediumFontSize()); }
        }

        public static UIFont BoldLargeFont
        {
            get { return UIFont.BoldSystemFontOfSize(GetLargeFontSize()); }
        }

        public static UIFont TextAreaFont
        {
            get { return UIFont.ItalicSystemFontOfSize(GetSmallFontSize()); }
        }

        public static UIFont ValueFont
        {
            get { return UIFont.ItalicSystemFontOfSize(GetMediumFontSize()); }
        }

        public static UIFont SubtitleFont
        {
            get { return UIFont.ItalicSystemFontOfSize(GetSmallFontSize()); }
        }

        public static UIFont TitleFont
        {
            get { return UIFont.SystemFontOfSize(18); }
        }

        public static UIFont ButtonFont
        {
            get { return UIFont.BoldSystemFontOfSize(GetLargeFontSize()); }
        }

        public static UIColor CellBackgroundColor
        {
            get { return UIColor.White; }
        }

        public static UIColor VeryLightGrayColor
        {
            get { return UIColor.FromRGB(239, 239, 244); }
        }

        public static UIColor SeparatorLineColor
        {
            get { return UIColor.FromRGB(200, 199, 204); }
        }

        public static UIColor SectionHeaderTextColor
        {
            get { return UIColor.FromRGB(109, 109, 114); }
        }

        public static UIColor QuestionInfoBackgroundColor
        {
            get { return UIColor.FromRGB(240, 239, 245); }
        }

        public static UIColor TitleTextColor
        {
            get { return UIColor.FromRGB(0, 122, 255); }
        }

        public static UIColor PremiumSkuColor
        {
            get { return UIColor.FromRGB(255, 232, 192); }
        }

        public static UIColor NonPremiumSkuColor
        {
            get { return UIColor.FromRGB(198, 241, 190); }
        }

        public static UIColor TopSkuColor
        {
            get { return UIColor.FromRGB(198, 241, 190); }
        }

        public static string BackButtonTitle
        {
            get { return "< Назад"; }
        }

        public static string NextButtonTitle
        {
            get { return "Вперед >"; }
        }

        public static string SaveButtonTitle
        {
            get { return "Сохранить"; }
        }

        public static string OkButtonTitle
        {
            get { return "Ок"; }
        }

        public static string CancelButtonTitle
        {
            get { return "Отмена"; }
        }

        public static string CloseButtonTitle
        {
            get { return "Закрыть"; }
        }

        public static int CommonStringElementTextLength
        {
            get { return 31; }
        }

        public static int DefaultCaptionMaxLength
        {
            get { return IsIphoneFourFamily ? 22 : IsIphone ? 26 : 46; }
        }

        public static int SubtitleCaptionLength
        {
            get { return IsIphone ? 30 : 65; }
        }

        public static int SubtitleValueLength
        {
            get { return IsIphone ? 90 : 180; }
        }

        public static nfloat GetHeightForRow
        {
            get { return IsIphone ? 45 : 50; }
        }

        #endregion <<< Public Properties

        #region >>> Private Methods

        private static float GetSmallFontSize()
        {
            return IsIphoneFourFamily ? 10 : IsIphone ? 12 : 15;
        }

        private static float GetMediumFontSize()
        {
            return IsIphoneFourFamily ? 12 : IsIphone ? 14 : 17;
        }

        private static float GetLargeFontSize()
        {
            return IsIphoneFourFamily ? 14 : IsIphone ? 16 : 18;
        }

        #endregion <<< Private Methods

        #region >>> UiComponent Options

        public static float DefaultControlHeight
        {
            get { return IsIphone ? 40 : 50; }
        }

        public static float LargeControlHeight
        {
            get { return IsIphone ? 50 : 60; }
        }

        public static float SalePointControlHeight
        {
            get { return IsIphone ? 55 : 75; }
        }

        public static float FridgeRequestControlHeight
        {
            get { return IsIphone ? 80 : 110; }
        }

        public static float ExtraLargeControlHeight
        {
            get { return IsIphone ? 65 : 85; }
        }

        #endregion <<< UiComponent Options
    }
}
