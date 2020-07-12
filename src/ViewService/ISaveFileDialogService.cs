#nullable enable

namespace Lumiria.ViewServices
{
    /// <summary>
    /// Represents a view service that provides a <see cref="SaveFileDialog"/>.
    /// </summary>
    public interface ISaveFileDialogService : IViewService
    {
        /// <summary>
        /// Displays a <see cref="SaveFileDialog"/>.
        /// </summary>
        /// <param name="initialDirectory">The initial directory that is displayed by a file dialog.</param>
        /// <param name="fileName">A string containing the full path of the file selected in a file dialog.</param>
        /// <param name="filter">The filter string that determines what types of files are displayed from either the file dialog.</param>
        /// <param name="filterIndex">The index of the filter currently selected in a file dialog.</param>
        /// <param name="title">The text that appears in the title bar of a file dialog.</param>
        /// <param name="defaultExt">A value that specifies the default extension string to use to filter the list of files that are displayed.</param>
        /// <param name="addExtension">A value indicating whether a file dialog automatically adds an extension to a file name if the user omits an extension.</param>
        /// <param name="checkFileExists">A value indicating wheter a file dialog displayes a warning if the use specifies a file name that does not exist.</param>
        /// <param name="checkPathExists">A value that specified whether warnings are displayed if the user types invalid paths and file names.</param>
        /// <param name="dereferenceLinks">A value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shorcut file (.lnk).</param>
        /// <param name="createPrompt">A value indicating whether a file dialog prompts the user for permission to create a file if the user specifies a file that does not exists.<</param>
        /// <param name="overwritePrompt">A value indicating whether a file dialog displays a warning if the user specifies the name of a file that already exists.</param>
        /// <param name="validateNames">A value indicating whether the dialog accepts only valid Win32 file names.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise, false.</returns>
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
            bool? validateNames = null);
    }
}
