#nullable enable

using ViewServices.Components;

namespace ViewServices
{
    /// <summary>
    /// Provides a service of the <see cref="Components.FolderBrowserDialog"/>
    /// </summary>
    public interface IFolderBrowserDialogService : IViewService
    {
        /// <summary>
        /// Gets or sets the text that appears in the title bar of a folder browser dialog.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Opens a folder browser dialog and returns only when the newly opened window is closed.
        /// </summary>
        /// <param name="folderPath">The initial folder path.</param>
        /// <param name="title">The text that appears in the title bar of a folder browser dialog.</param>
        /// <returns>A <see cref="DialogResult"/> that is <see cref="DialogResult.OK"/> if the user click OK in the dialog; otherwise, <see cref="DialogResult.Cancel"/>.
        /// and a string that is selected folder path.</returns>
        public (DialogResult result, string? folderPath) ShowDialog(
            string? folderPath = null,
            string? title = null);
    }
}
