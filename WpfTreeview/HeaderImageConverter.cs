using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfTreeview.Directory;
using WpfTreeview.Directory.Data;

namespace WpfTreeview
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderImageConverter : IValueConverter
    {
        public static HeaderImageConverter Instance = new HeaderImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string image = "Images/DefaultIcon.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/HardDrive.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/ClosedFolder.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
