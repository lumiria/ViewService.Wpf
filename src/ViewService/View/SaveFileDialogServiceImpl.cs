#nullable enable

using System.Windows;
using Microsoft.Win32;

namespace ViewServices.View
{
    internal sealed class SaveFileDialogServiceImpl : ISaveFileDialogService
    {
        private readonly Window? _owner;

        public SaveFileDialogServiceImpl(Window? owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Gets or sets the initial directory that is displayed by a file dialog.
        /// </summary>
        public string? InitialDirectory { get; set; }

        /// <summary>
        /// Gets or sets the filter string that determines what types of files are displayed from either the OpenFileDialog.
        /// </summary>
        public string? Filter { get; set; }

        /// <summary>
        /// Gets or sets the index of the filter currently selected in a file dialog.
        /// </summary>
        public int? FilterIndex { get; set; }

        /// <summary>
        /// Gets or sets the text that appears in the bar of a file dialog.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the default extension string to use to filter the list of files that are displayed.
        /// </summary>
        public string? DefaultExt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog automatically adds an extension to a file name if the user omits an extension.
        /// </summary>
        public bool? AddExtension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog displays a warning if the user specifies a file name that does not exist.
        /// </summary>
        public bool? CheckFileExists { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies whether warnings are displayed if the user types invalid paths and file names.
        /// </summary>
        public bool? CheckPathExists { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shortcut file (.lnk).
        /// </summary>
        public bool? DereferenceLinks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="SaveFileDialog"/> prompts the user for permmission to create a file if the user specifies a file that does not exist.
        /// </summary>
        public bool? CreatePrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="SaveFileDialog"/> displays a warning if the user specifies the name of a file that already exists.
        /// </summary>
        public bool? OverwritePrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog accepts only valid Win32 file names.
        /// </summary>
        public bool? ValidateNames { get; set; }

        /// <summary>
        /// Displays a <see cref="SaveFileDialog"/>.
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
        /// <param name="createPrompt">A value indicating whether a file dialog prompts the user for permission to create a file if the user specifies a file that does not exists.<</param>
        /// <param name="overwritePrompt">A value indicating whether a file dialog displays a warning if the user specifies the name of a file that already exists.</param>
        /// <param name="validateNames">A value indicating whether the dialog accepts only valid Win32 file names.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise, false.</returns>
        public (bool result, string fileName) ShowDialog(
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
            bool? createPrompt = null,
            bool? overwritePrompt = null,
            bool? validateNames = null)
        {
            var dialog = CreateDialog(
                initialDirectory ?? InitialDirectory,
                fileName,
                filter ?? Filter,
                filterIndex ?? FilterIndex,
                title ?? Title,
                defaultExt ?? DefaultExt,
                addExtension ?? AddExtension,
                checkFileExists ?? CheckFileExists,
                checkPathExists ?? CheckPathExists,
                dereferenceLinks ?? DereferenceLinks,
                createPrompt ?? CreatePrompt,
                overwritePrompt ?? OverwritePrompt,
                validateNames ?? ValidateNames);

            var result = _owner == null
                ? dialog.ShowDialog()
                : dialog.ShowDialog(_owner);

            return (result ?? false, dialog.FileName);
        }

        private SaveFileDialog CreateDialog(
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
                bool? createPrompt = null,
                bool? overwritePrompt = null,
                bool? validateNames = null) =>
            new SaveFileDialog()
            {
                InitialDirectory = initialDirectory ?? string.Empty,
                FileName = fileName ?? string.Empty,
                Filter = filter ?? string.Empty,
                FilterIndex = filterIndex ?? 0,
                Title = title ?? string.Empty,
                DefaultExt = defaultExt ?? string.Empty,
                AddExtension = addExtension ?? true,
                CheckFileExists = checkFileExists ?? false,
                CheckPathExists = checkPathExists ?? true,
                DereferenceLinks = dereferenceLinks ?? false,
                CreatePrompt = createPrompt ?? false,
                OverwritePrompt = overwritePrompt ?? true,
                ValidateNames = validateNames ?? true
            };
    }
}
