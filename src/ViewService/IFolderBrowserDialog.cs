#nullable enable

using ViewServices.Components;

namespace ViewServices
{
    public interface IFolderBrowserDialogService : IViewService
    {
        public string? Title { get; set; }

        public (DialogResult result, string? folderPath) ShowDialog(
            string? folderPath = null,
            string? title = null);
    }
}
