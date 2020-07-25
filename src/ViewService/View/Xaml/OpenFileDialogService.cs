#nullable enable

using System.Windows;
using Microsoft.Win32;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Represents a service that provides a common dialog box that allows a user to specify a filename for one or more files to open.
    /// </summary>
    public sealed class OpenFileDialogService : FreezableViewService<IOpenFileDialogService>
    {
        private IOpenFileDialogService? _serviceImpl;

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns <see cref="OpenFileDialog"/>.
        /// </summary>
        public Window? Owner
        {
            get => (Window?)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(OpenFileDialogService), new PropertyMetadata(null));

        ///// <summary>
        ///// Gets or sets a value indicating whether a file dialog automatically adds an extension to a file name if the user omits an extension.
        ///// </summary>
        //public bool AddExtension
        //{
        //    get => (bool)GetValue(AddExtensionProperty);
        //    set => SetValue(AddExtensionProperty, value);
        //}
        ///// <summary>AddExtension Dependency Property</summary>
        //public static readonly DependencyProperty AddExtensionProperty =
        //    DependencyProperty.Register("AddExtension", typeof(bool), typeof(OpenFileDialogService), new PropertyMetadata(true));

        ///// <summary>
        ///// Gets or sets a value indicating whether a file dialog displays a warning if the user specifies a file name that does not exist.
        ///// </summary>
        //public bool CheckFileExists
        //{
        //    get => (bool)GetValue(CheckFileExistsProperty);
        //    set => SetValue(CheckFileExistsProperty, value);
        //}
        ///// <summary>CheckFileExists Dependency Property</summary>
        //public static readonly DependencyProperty CheckFileExistsProperty =
        //    DependencyProperty.Register("CheckFileExists", typeof(bool), typeof(OpenFileDialogService), new PropertyMetadata(false));

        ///// <summary>
        ///// Gets or sets a value that specifies whether warnings are displayed if the user types invalid paths and file names.
        ///// </summary>
        //public bool CheckPathExists
        //{
        //    get => (bool)GetValue(CheckPathExistsProperty);
        //    set => SetValue(CheckPathExistsProperty, value);
        //}
        ///// <summary>CheckPathExists Dependency Property</summary>
        //public static readonly DependencyProperty CheckPathExistsProperty =
        //    DependencyProperty.Register("CheckPathExists", typeof(bool), typeof(OpenFileDialogService), new PropertyMetadata(false));


        /////// <summary>
        /////// Gets or sets the list of custom places for file dialog boxes.
        /////// </summary>
        ////public IList<FileDialogCustomPlace> CustomPlaces
        ////{
        ////    get => (IList<FileDialogCustomPlace>)GetValue(CustomPlacesProperty);
        ////    set => SetValue(CustomPlacesProperty, value);
        ////}
        /////// <summary>CustomPlaces Dependency Property</summary>
        ////public static readonly DependencyProperty CustomPlacesProperty =
        ////    DependencyProperty.Register("CustomPlaces", typeof(IList<FileDialogCustomPlace>), typeof(OpenFileDialogService), new PropertyMetadata(null));

        ///// <summary>
        ///// Gets or sets a value that specifies the default extension string to use to filter the list of files that are displayed.
        ///// </summary>
        //public string DefaultExt
        //{
        //    get => (string)GetValue(DefaultExtProperty);
        //    set => SetValue(DefaultExtProperty, value);
        //}
        ///// <summary>DefaultExt Dependency Property</summary>
        //public static readonly DependencyProperty DefaultExtProperty =
        //    DependencyProperty.Register("DefaultExt", typeof(string), typeof(OpenFileDialogService), new PropertyMetadata(string.Empty));

        ///// <summary>
        ///// Gets or sets a value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shortcut file (.lnk).
        ///// </summary>
        //public bool DereferenceLinks
        //{
        //    get => (bool)GetValue(DereferenceLinksProperty);
        //    set => SetValue(DereferenceLinksProperty, value);
        //}
        ///// <summary>DereferenceLinks Dependency Property</summary>
        //public static readonly DependencyProperty DereferenceLinksProperty =
        //    DependencyProperty.Register("DereferenceLinks", typeof(bool), typeof(OpenFileDialog), new PropertyMetadata(false));

        ///// <summary>
        ///// Gets or sets a string containing the full path of the file selected in a file dialog.
        ///// </summary>
        //public string FileName
        //{
        //    get => (string)GetValue(FileNameProperty);
        //    set => SetValue(FileNameProperty, value);
        //}
        ///// <summary>FileName Dependency Property</summary>
        //public static readonly DependencyProperty FileNameProperty =
        //    DependencyProperty.Register("FileName", typeof(string), typeof(OpenFileDialogService), new PropertyMetadata(string.Empty));

        ///// <summary>
        ///// Gets or sets the filter string that determines what types of files are displayed from either the OpenFileDialog or SaveFileDialog.
        ///// </summary>
        //public string Filter
        //{
        //    get => (string)GetValue(FilterProperty);
        //    set => SetValue(FilterProperty, value);
        //}
        ///// <summary>Filter Dependency Property</summary>
        //public static readonly DependencyProperty FilterProperty =
        //    DependencyProperty.Register("Filter", typeof(string), typeof(OpenFileDialogService), new PropertyMetadata(string.Empty));

        ///// <summary>
        ///// Gets or sets the index of the filter currently selected in a file dialog.
        ///// </summary>
        //public int FilterIndex
        //{
        //    get => (int)GetValue(FilterIndexProperty);
        //    set => SetValue(FilterIndexProperty, value);
        //}
        ///// <summary>FilterIndex Dependency Property</summary>
        //public static readonly DependencyProperty FilterIndexProperty =
        //    DependencyProperty.Register("FilterIndex", typeof(int), typeof(OpenFileDialogService), new PropertyMetadata(0));

        ///// <summary>
        ///// Gets or sets the initial directory that is displayed by a file dialog.
        ///// </summary>
        //public string InitialDirectory
        //{
        //    get => (string)GetValue(InitialDirectoryProperty);
        //    set => SetValue(InitialDirectoryProperty, value);
        //}
        ///// <summary>InitialDirectory Dependency Property</summary>
        //public static readonly DependencyProperty InitialDirectoryProperty =
        //    DependencyProperty.Register("InitialDirectory", typeof(string), typeof(OpenFileDialogService), new PropertyMetadata(string.Empty));

        internal override IViewService GetService() =>
            _serviceImpl ??= new OpenFileDialogServiceImpl(Owner);

        protected override Freezable CreateInstanceCore() =>
            new OpenFileDialogService();
    }
}
