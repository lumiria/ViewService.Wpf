#nullable enable

using System.Windows;
using Microsoft.Win32;

namespace Lumiria.ViewServices.View
{
    internal sealed class SaveFileDialogServiceImpl : ISaveFileDialogService
    {
        private readonly Window? _owner;

        public SaveFileDialogServiceImpl(Window? owner)
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
            bool? createPrompt = null,
            bool? overwritePrompt = null,
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
                createPrompt,
                overwritePrompt,
                validateNames);

            var result = _owner == null
                ? dialog.ShowDialog()
                : dialog.ShowDialog(_owner);

            return (result ?? false, dialog.FileName, dialog.FileNames);
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
