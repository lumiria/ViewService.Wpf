using System.Collections.Generic;
using System.Collections.ObjectModel;
using ViewServices.View.Components;

namespace ViewServices.Components
{
    public static class StyleableMessageBoxButtons
    {
        public static IEnumerable<StyleableMessageBoxButton> OK { get; } =
            new ObservableCollection<StyleableMessageBoxButton>(
                new[] { StyleableMessageBoxStandardButton.Ok })
            .ToReadOnly();

        public static IEnumerable<StyleableMessageBoxButton> OkCancel { get; } =
            new ObservableCollection<StyleableMessageBoxButton>(
                new[] { StyleableMessageBoxStandardButton.Ok,
                StyleableMessageBoxStandardButton.Cancel})
            .ToReadOnly();

        public static IEnumerable<StyleableMessageBoxButton> YesNo { get; } =
            new ObservableCollection<StyleableMessageBoxButton>(
                new[] { StyleableMessageBoxStandardButton.Yes,
                StyleableMessageBoxStandardButton.No})
            .ToReadOnly();

        public static IEnumerable<StyleableMessageBoxButton> YesNoCancel { get; } =
            new ObservableCollection<StyleableMessageBoxButton>(
                new[] { StyleableMessageBoxStandardButton.Yes,
                StyleableMessageBoxStandardButton.No,
                StyleableMessageBoxStandardButton.Cancel})
            .ToReadOnly();


    }

    internal static class ObservableCollectionExtensions
    {
        public static ReadOnlyObservableCollection<StyleableMessageBoxButton> ToReadOnly(
            this ObservableCollection<StyleableMessageBoxButton> self) =>
            new ReadOnlyObservableCollection<StyleableMessageBoxButton>(self);

    }

}
