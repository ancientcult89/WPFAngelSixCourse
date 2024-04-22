using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfTreeview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get every logical drive
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //create  a new item for it
                var item = new TreeViewItem()
                {
                    //set the header and path
                    Header = drive,
                    //set the fullpath
                    Tag = drive,
                };

                item.Items.Add(null);

                //listen out for item being expanded
                item.Expanded += Folder_Expanded;

                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            //if the items only contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }

            //Clear dummy data
            item.Items.Clear();
            var fullpPath = (string)item.Tag;


            //create a blank list for directories
            var dirictories = new List<string>();

            //try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var dir = Directory.GetDirectories(fullpPath);

                if (dir.Length > 0)
                {
                    dirictories.AddRange(dir);
                }

            }
            catch //not best practice :P
            {

            }

            dirictories.ForEach(directoriePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoriePath),
                    Tag = directoriePath,
                };

                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });

            //create a blank list for directories
            var files = new List<string>();

            //try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullpPath);

                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }

            }
            catch //not best practice :P
            {

            }

            files.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),
                    Tag = filePath,
                };

                item.Items.Add(subItem);
            });

        }

        public static string GetFileFolderName(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                return string.Empty;
            }

            var normolizedPath = directoryPath.Replace('/', '\\');

            var lastIndex = normolizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
            {
                return directoryPath;
            }
            else
            {
                return normolizedPath.Substring(lastIndex + 1);
            }
        }
    }
}
