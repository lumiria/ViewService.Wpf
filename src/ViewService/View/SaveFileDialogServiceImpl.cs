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

        public string? Filter { get; set; }

        public int? FilderIndex { get; set; }

        public string? Title { get; set; }

        public string? DefaultExt { get; set; }

        public bool? AddExtension { get; set; }

        public bool? CheckFileExists { get; set; }

        public bool? CheckPathExists { get; set; }

        public bool? DereferenceLinks { get; set; }

        public bool? CreatePrompt { get; set; }

        public bool? OverwritePrompt { get; set; }

        public bool? ValidateNames { get; set; }

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
                initialDirectory,
                fileName,
                filter ?? Filter,
                filterIndex ?? FilderIndex,
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
