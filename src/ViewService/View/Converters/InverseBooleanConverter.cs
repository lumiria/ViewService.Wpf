using System;
using System.Windows.Data;

namespace ViewServices.View.Converters
{

    /// <summary>
    /// Represents the converter that converts Boolean values to and from inverse Boolean values.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public sealed class InverseBooleanConverter : BooleanToAnyConverter<bool>
    {
        public InverseBooleanConverter()
            : base(false, true)
        {
        }

        [Obsolete]
        private new bool WhenTrue { get; set; }

        [Obsolete]
        private new bool WhenFalse { get; set; }
    }
}
