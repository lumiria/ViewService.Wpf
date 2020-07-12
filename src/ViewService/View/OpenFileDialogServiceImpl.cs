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
                multiselect,
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
                bool? multiselect = null,
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
                Multiselect = multiselect ?? false,
                ReadOnlyChecked = readOnlyChecked ?? false,
                ShowReadOnly = showReadOnly ?? false,
                ValidateNames = validateNames ?? true
            };
    }
}
