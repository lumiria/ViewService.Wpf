#nullable enable

using System.Windows;
using Microsoft.Win32;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Represents a service that provides a common dialog that allows the user to specify a filename to save a file as.
    /// </summary>
    public sealed class SaveFileDialogService : FreezableViewService<ISaveFileDialogService>
    {
        private ISaveFileDialogService? _serviceImpl;

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns <see cref="SaveFileDialog"/>.
        /// </summary>
        public Window? Owner
        {
            get => (Window?)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog automatically adds an extension to a file name if the user omits an extension.
        /// </summary>
        public bool? AddExtension
        {
            get => (bool?)GetValue(AddExtensionProperty);
            set => SetValue(AddExtensionProperty, value);
        }
        /// <summary>AddExtension Dependency Property</summary>
        public static readonly DependencyProperty AddExtensionProperty =
            DependencyProperty.Register("AddExtension", typeof(bool), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog displays a warning if the user specifies a file name that does not exist.
        /// </summary>
        public bool? CheckFileExists
        {
            get => (bool?)GetValue(CheckFileExistsProperty);
            set => SetValue(CheckFileExistsProperty, value);
        }
        /// <summary>CheckFileExists Dependency Property</summary>
        public static readonly DependencyProperty CheckFileExistsProperty =
            DependencyProperty.Register("CheckFileExists", typeof(bool), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value that specifies whether warnings are displayed if the user types invalid paths and file names.
        /// </summary>
        public bool? CheckPathExists
        {
            get => (bool?)GetValue(CheckPathExistsProperty);
            set => SetValue(CheckPathExistsProperty, value);
        }
        /// <summary>CheckPathExists Dependency Property</summary>
        public static readonly DependencyProperty CheckPathExistsProperty =
            DependencyProperty.Register("CheckPathExists", typeof(bool), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="SaveFileDialog"/> prompts the user for permmission to create a file if the user specifies a file that does not exist.
        /// </summary>
        public bool? CreatePrompt
        {
            get => (bool?)GetValue(CreatePromptProperty);
            set => SetValue(CreatePromptProperty, value);
        }
        public static readonly DependencyProperty CreatePromptProperty =
            DependencyProperty.Register("CreatePrompt", typeof(bool?), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value that specifies the default extension string to use to filter the list of files that are displayed.
        /// </summary>
        public string? DefaultExt
        {
            get => (string?)GetValue(DefaultExtProperty);
            set => SetValue(DefaultExtProperty, value);
        }
        /// <summary>DefaultExt Dependency Property</summary>
        public static readonly DependencyProperty DefaultExtProperty =
            DependencyProperty.Register("DefaultExt", typeof(string), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shortcut file (.lnk).
        /// </summary>
        public bool? DereferenceLinks
        {
            get => (bool?)GetValue(DereferenceLinksProperty);
            set => SetValue(DereferenceLinksProperty, value);
        }
        /// <summary>DereferenceLinks Dependency Property</summary>
        public static readonly DependencyProperty DereferenceLinksProperty =
            DependencyProperty.Register("DereferenceLinks", typeof(bool), typeof(SaveFileDialogService), new PropertyMetadata(null));

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
        //    DependencyProperty.Register("FileName", typeof(string), typeof(SaveFileDialogService), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the filter string that determines what types of files are displayed from either the SaveFileDialog.
        /// </summary>
        public string? Filter
        {
            get => (string?)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }
        /// <summary>Filter Dependency Property</summary>
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(string), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the index of the filter currently selected in a file dialog.
        /// </summary>
        public int? FilterIndex
        {
            get => (int?)GetValue(FilterIndexProperty);
            set => SetValue(FilterIndexProperty, value);
        }
        /// <summary>FilterIndex Dependency Property</summary>
        public static readonly DependencyProperty FilterIndexProperty =
            DependencyProperty.Register("FilterIndex", typeof(int), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the initial directory that is displayed by a file dialog.
        /// </summary>
        public string? InitialDirectory
        {
            get => (string?)GetValue(InitialDirectoryProperty);
            set => SetValue(InitialDirectoryProperty, value);
        }
        /// <summary>InitialDirectory Dependency Property</summary>
        public static readonly DependencyProperty InitialDirectoryProperty =
            DependencyProperty.Register("InitialDirectory", typeof(string), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="SaveFileDialog"/> displays a warning if the user specifies the name of a file that already exists.
        /// </summary>
        public bool? OverwritePrompt
        {
            get => (bool?)GetValue(OverwritePromptProperty);
            set => SetValue(OverwritePromptProperty, value);
        }
        public static readonly DependencyProperty OverwritePromptProperty =
            DependencyProperty.Register("OverwritePrompt", typeof(bool?), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the text that appears in the bar of a file dialog.
        /// </summary>
        public string? Title
        {
            get => (string?)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SaveFileDialogService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value indicating whether the dialog accepts only valid Win32 file names.
        /// </summary>
        public bool? ValidateNames
        {
            get => (bool?)GetValue(ValidateNamesProperty);
            set => SetValue(ValidateNamesProperty, value);
        }
        public static readonly DependencyProperty ValidateNamesProperty =
            DependencyProperty.Register("ValidateNames", typeof(bool?), typeof(SaveFileDialogService), new PropertyMetadata(null));


        internal override IViewService GetService() =>
            _serviceImpl ??= new SaveFileDialogServiceImpl(Owner)
            {
                InitialDirectory = InitialDirectory,
                Filter = Filter,
                FilterIndex = FilterIndex,
                Title = Title,
                DefaultExt = DefaultExt,
                AddExtension = AddExtension,
                CheckFileExists = CheckFileExists,
                CheckPathExists = CheckPathExists,
                DereferenceLinks = DereferenceLinks,
                CreatePrompt = CreatePrompt,
                OverwritePrompt = OverwritePrompt,
                ValidateNames = ValidateNames
            };

        protected override Freezable CreateInstanceCore() =>
            new SaveFileDialogService();
    }
}
