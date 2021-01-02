using System.Windows;
using System.Windows.Data;

namespace ViewServices.View.Converters
{
    /// <summary>
    /// Represents the converter that converts Boolean values to and from <see cref="Visibility"/> enumeration values.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BooleanToVisibilityConverter : BooleanToAnyConverter<Visibility>
    {
        public BooleanToVisibilityConverter()
            : base(Visibility.Visible, Visibility.Collapsed)
        {
        }
    }
}
