#nullable enable

using System;
using System.Windows.Data;

namespace ViewServices.View.Converters
{
    /// <summary>
    /// Represents the converter that converts any enumeration values to and from boolean values.
    /// </summary>
    [ValueConversion(typeof(Enum), typeof(bool))]
    public sealed class EnumToBooleanConverter : EnumToAnyConverter<bool>
    {
        public EnumToBooleanConverter()
            : base(true, false)
        {
        }
    }
}
