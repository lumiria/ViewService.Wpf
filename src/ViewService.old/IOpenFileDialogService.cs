namespace Lumiria.ViewServices
{
    /// <summary>
    /// Represents a service that provides a common dialog box that allows a user to specify a filename for one or more files to open.
    /// </summary>
    public interface IOpenFileDialogService : IViewService
    {
        /// <summary>
        /// Displays a common dialog.
        /// </summary>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise, false.</returns>
        bool? ShowDialog();
    }
}
