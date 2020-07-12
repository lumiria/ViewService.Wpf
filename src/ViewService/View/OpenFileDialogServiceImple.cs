#nullable enable

using System.Windows;
using Microsoft.Win32;

namespace Lumiria.ViewServices.View
{
    internal sealed class OpenFileDialogServiceImpl : IOpenFileDialogService
    {
        private readonly Window? _owner;

        public OpenFileDialogServiceImpl(Window? owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Displays a common dialog.
        /// </summary>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise, false.</returns>
        public bool? ShowDialog()
        {
            var dialog = new OpenFileDialog();

            return _owner == null
                ? dialog.ShowDialog()
                : dialog.ShowDialog(_owner);
        }

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
            bool? readOnlyChecked = null,
            bool? showReadOnly = null,
            bool? validateNames = null)
        {
            var dialog = CreateDialog(
                initialDirectory,
                fileName,
                filter,
                filterIndex,
                title,
                defaultExt,
                addExtension,
                checkFileExists,
                checkPathExists,
                dereferenceLinks,
                readOnlyChecked,
                showReadOnly,
                validateNames);

            var result = _owner == null
                ? dialog.ShowDialog()
                : dialog.ShowDialog(_owner);

            return (result ?? false, dialog.FileName, dialog.FileNames);
        }

        private OpenFileDialog CreateDialog(
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
                bool? readOnlyChecked = null,
                bool? showReadOnly = null,
                bool? validateNames = null) =>
            new OpenFileDialog()
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
                ReadOnlyChecked = readOnlyChecked ?? false,
                ShowReadOnly = showReadOnly ?? false,
                ValidateNames = validateNames ?? true
            };

        private OpenFileDialog CreateDialog(
        string[] fileNames,
        string? initialDirectory = null,
        string? filter = null,
        int? filterIndex = null,
        string? title = null,
        string? defaultExt = null,
        bool? addExtension = null,
        bool? checkFileExists = null,
        bool? checkPathExists = null,
        bool? dereferenceLinks = null,
        bool? readOnlyChecked = null,
        bool? showReadOnly = null,
        bool? validateNames = null) =>
    new OpenFileDialog()
    {
        InitialDirectory = initialDirectory ?? string.Empty,
        Filter = filter ?? string.Empty,
        FilterIndex = filterIndex ?? 0,
        Title = title ?? string.Empty,
        DefaultExt = defaultExt ?? string.Empty,
        AddExtension = addExtension ?? true,
        CheckFileExists = checkFileExists ?? false,
        CheckPathExists = checkPathExists ?? true,
        DereferenceLinks = dereferenceLinks ?? false,
        ReadOnlyChecked = readOnlyChecked ?? false,
        ShowReadOnly = showReadOnly ?? false,
        ValidateNames = validateNames ?? true
    };
    }
}
