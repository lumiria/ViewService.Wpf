#nullable enable

using Lumiria.ViewServices.View.Components;

namespace Lumiria.ViewServices
{
    public interface IFolderBrowserDialogService : IViewService
    {
        public (DialogResult result, string? folderPath) ShowDialog(
            string? folderPath = null,
            string? title = null);
    }
}
