namespace ViewServices.View.Components
{
    public static class StyleableMessageBoxStandardButton
    {
        public static StyleableMessageBoxButton Ok { get; } =
            new StyleableMessageBoxButton("OK", System.Windows.MessageBoxResult.OK);

        public static StyleableMessageBoxButton Cancel { get; } =
            new StyleableMessageBoxButton("Cacel", System.Windows.MessageBoxResult.Cancel);

        public static StyleableMessageBoxButton Yes { get; } =
            new StyleableMessageBoxButton("Yes", System.Windows.MessageBoxResult.Yes);

        public static StyleableMessageBoxButton No { get; } =
            new StyleableMessageBoxButton("No", System.Windows.MessageBoxResult.No);

        public static StyleableMessageBoxButton Close { get; } =
            new StyleableMessageBoxButton("Close", System.Windows.MessageBoxResult.None);
    }
}
