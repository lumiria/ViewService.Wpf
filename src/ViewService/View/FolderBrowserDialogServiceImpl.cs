#nullable enable

using System.Windows;
using ViewServices.Components;
using ViewServices.View.Components;

namespace ViewServices.View
{
    internal sealed class FolderBrowserDialogServiceImpl : IFolderBrowserDialogService
    {
        private readonly Window? _owner;

        public FolderBrowserDialogServiceImpl(Window? owner)
        {
            _owner = owner;
        }

        public string? Title { get; set; }

        public (DialogResult result, string? folderPath) ShowDialog(
            string? folderPath = null,
            string? title = null)
        {
            var dialog = new FolderBrowserDialog()
            {
                FolderPath = folderPath,
                Title = title ?? Title
            };


            var result = _owner == null
                ? dialog.ShowDialog()
                : dialog.ShowDialog(_owner);

            return (result, dialog.FolderPath);
        }
    }
}
