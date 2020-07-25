namespace ViewServices.Components
{
    public enum DialogResult : int
    {
        /// <summary>
        /// The dialog returns no results.
        /// </summary>
        None = 0,
        /// <summary>
        /// The result value of the dialog is OK.
        /// </summary>
        OK,
        /// <summary>
        /// The result value of the dialog is Cancel.
        /// </summary>
        Cancel,
        /// <summary>
        /// The result value of the dialog is Abort.
        /// </summary>
        Abort,
        /// <summary>
        /// The result value of the dialog is Retry.
        /// </summary>
        Retry,
        /// <summary>
        /// The result value of the dialog is Ignore.
        /// </summary>
        Ignore,
        /// <summary>
        /// The result value of the dialog is Yes.
        /// </summary>
        Yes,
        /// <summary>
        /// The result value of the dialog is No.
        /// </summary>
        No
    }
}
