using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeview
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderImageConverter : IValueConverter
    {
        public static HeaderImageConverter Instance = new HeaderImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = (string)value;

            if(path == null)
                return null;

            var name = MainWindow.GetFileFolderName(path);

            string image = "Images/HardDrive.png";

            if (path.Length <= 4) //инкастыляция, по уроку сюда ничего не должно было падать и так определялся драйв...
                image = "Images/HardDrive.png";
            else if(new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/ClosedFolder.png";
            else
                image = "Images/DefaultIcon.png";

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
