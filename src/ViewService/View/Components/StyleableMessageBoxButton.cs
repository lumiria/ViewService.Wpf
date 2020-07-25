using System.Windows;

namespace ViewServices.View.Components
{
    public sealed class StyleableMessageBoxButton
    {
        public StyleableMessageBoxButton(
            string header,
            MessageBoxResult result,
            bool isDefault = false)
        {
            Header = header;
            Result = result;
            IsDefault = isDefault;
        }

        public string Header { get; }

        public MessageBoxResult Result { get; }

        public bool IsDefault { get; }
    }
}
