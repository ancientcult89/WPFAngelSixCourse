using System.Collections.ObjectModel;
using WpfTreeview.Directory.Data;
using System.Linq;
using System;
using System.Windows.Input;

namespace WpfTreeview.Directory.ViewModels
{
    public class DirectoryItemViewModel : BaseViewModel
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

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; }}
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                    Expand();
                else
                    this.ClearChildren();
            }
        }

        #region public Commands

        public ICommand ExpandCommand { get; set; }

        #endregion

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            //add dummy to show expand arrow
            if(this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;

            this.ClearChildren();
        }

        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);

            this.Children = new ObservableCollection<DirectoryItemViewModel>(children
                .Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
