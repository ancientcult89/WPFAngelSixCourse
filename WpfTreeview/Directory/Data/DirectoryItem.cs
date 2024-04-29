namespace WpfTreeview.Directory.Data
{
    /// <summary>
    /// Information about a directory item such as a drive a file or a folder
    /// </summary>
    public class DirectoryItem
    { 
        /// <summary>
        /// type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// the absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// the name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }
    }
}
