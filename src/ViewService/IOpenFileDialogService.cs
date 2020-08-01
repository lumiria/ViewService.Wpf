#nullable enable

namespace ViewServices
{
    /// <summary>
    /// Represents a view service that provides a <see cref="OpenFileDialog"/>.
    /// </summary>
    public interface IOpenFileDialogService : IViewService
    {
        /// <summary>
        /// Gets or sets the initial directory that is displayed by a file dialog.
        /// </summary>
        string? InitialDirectory { get; set; }

        /// <summary>
        /// Gets or sets the filter string that determines what types of files are displayed form either the OpenFileDialog.
        /// </summary>
        string? Filter { get; set; }

        /// <summary>
        /// Gets or sets the index of the filter currencly selected in a file dialog.
        /// </summary>
        int? FilterIndex { get; set; }

        /// <summary>
        /// Gets or sets the text that apperars in the title bar of a file dialog.
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the default extension string to use to filter the list of files that are displayed.
        /// </summary>
        string? DefaultExt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog automatically adds an extension to a file name if the user omits an extension.
        /// </summary>
        bool? AddExtension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog displays a warning if the user specifies a file name that does not exist.
        /// </summary>
        bool? CheckFileExists { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies whether warnings are displayed if the user types invalid paths and file names.
        /// </summary>
        bool? CheckPathExists { get; set; }

        /// <summary>
        /// GEts or sets a value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shortcut file (.lnk).
        /// </summary>
        bool? DereferenceLinks { get; set; }

        /// <summary>
        /// Gets or sets an option indicating whether <see cref="Microsoft.Win32.OpenFileDialog"/> allows users to select multiple files.
        /// </summary>
        bool? Multiselect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the read-only check box displayed by <see cref="Microsoft.Win32.OpenFileDialog"/> is selected.
        /// </summary>
        bool? ReadOnlyChecked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="OpenFileDialog"/> contains a read-only check box.
        /// </summary>
        bool? ShowReadOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog accepts only valid Win32 file names.
        /// </summary>
        public bool? ValidateNames { get; set; }

        /// <summary>
        /// Displays a <see cref="OpenFiledialog"/>.
        /// </summary>
        /// <param name="initialDirectory">The initial directory that is displayed by a file dialog.</param>
        /// <param name="fileName">A string containing the full path of the file selected in a file dialog.</param>
        /// <param name="filter">The filter string that determines what types of files are displayed from either the file dialog.</param>
        /// <param name="filterIndex">The index of the filter currently selected in a file dialog.</param>
        /// <param name="title">The text that appears in the title bar of a file dialog.</param>
        /// <param name="defaultExt">A value that specifies the default extension string to use to filter the list of files that are displayed.</param>
        /// <param name="addExtension">A value indicating whether a file dialog automatically adds an extension to a file name if the user omits an extension.</param>
        /// <param name="checkFileExists">A value indicating wheter a file dialog displayes a warning if the use specifies a file name that does not exist.</param>
        /// <param name="checkPathExists">A value that specified whether warnings are displayed if the user types invalid paths and file names.</param>
        /// <param name="dereferenceLinks">A value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shorcut file (.lnk).</param>
        /// <param name="multiSelect">an option indicating whether a file dialog allows users to select multiple files.</param>
        /// <param name="readOnlyChecked">A value indicating whether the read-only check box displayed by a file dialog is selected.</param>
        /// <param name="showReadOnly">A value indicating whether a file dialog contains a read-onlu check box.</param>
        /// <param name="validateNames">A value indicating whether the dialog accepts only valid Win32 file names.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise, false.</returns>
        public (bool result, string fileName, string[] fileNames) ShowDialog(
            string? initialDirectory = null,
            string? fileName = null,
            string? filter = null,
            int? filterIndex = null,
            string? title = null,
            string? defaultExt = null,
            bool? addExtension = null,
            bool? checkFileExists = null,
            bool? checkPathExists = null,
            bool? dereferenceLinks = null,
            bool? multiselect = null,
            bool? readOnlyChecked = null,
            bool? showReadOnly = null,
            bool? validateNames = null);
    }
}
