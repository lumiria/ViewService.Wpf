using System;
using System.Windows;
using System.Windows.Data;

namespace ViewServices.View.Converters
{
    /// <summary>
    /// Represents the converter that converts any enumeration values to and from <see cref="Visibility"/> enumeration values.
    /// </summary>
    [ValueConversion(typeof(Enum), typeof(Visibility))]
    public sealed class EnumToVisibilityConverter : EnumToAnyConverter<Visibility>
    {
        public EnumToVisibilityConverter()
            : base(Visibility.Visible, Visibility.Collapsed)
        {
        }
    }
}
