using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WpfTreeview.Directory.Data;

namespace WpfTreeview.Directory
{
    /// <summary>
    /// a helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// gets all logical drive on a computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// gets the directories top-level content
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            //try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }

            }
            catch { }//not best practice :P


            //try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var fs = System.IO.Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath= file, Type = DirectoryItemType.File }));
                }

            }
            catch { }//not best practice :P

            return items;
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
