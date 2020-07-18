#nullable enable

using System.Windows;
using Lumiria.ViewServices.View.Components;

namespace Lumiria.ViewServices.View
{
    internal sealed class FolderBrowserDialogImpl
    {
        private readonly Window? _owner;

        public FolderBrowserDialogImpl(Window? owner)
        {
            _owner = owner;
        }

        public (DialogResult result, string folderPath) ShowDialog()
        {
            var dialog = new FolderBrowserDialog();

            var result = _owner == null
                ? dialog.ShowDialog()
                : dialog.ShowDialog(_owner);

            return (result, dialog.SelectedPath);
        }
    }
}
