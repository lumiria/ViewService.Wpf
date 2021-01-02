using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ViewServices.View.Converters
{
    /// <summary>
    /// Represents the converter that converts Boolean values to and from any values.
    /// </summary>
    public sealed class BooleanToAnyConverter : BooleanToAnyConverter<object>
    {
        public BooleanToAnyConverter()
            : base(default, default)
        {
        }
    }

    /// <summary>
    /// Represents the converter that converts Boolean values to and from any values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BooleanToAnyConverter<T> : IValueConverter
    {
        ///// <summary>
        ///// Initializes a new instance of the <see cref="BooleanToAnyConverter"/> class.
        ///// </summary>
        //public BooleanToAnyConverter()
        //{
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanToAnyConverter"/> class.
        /// </summary>
        /// <param name="trueValue"> A value when true is passed in.</param>
        /// <param name="falseValue"> A value when false is passed in.</param>
        public BooleanToAnyConverter(T trueValue, T falseValue)
        {
            WhenTrue = trueValue;
            WhenFalse = falseValue;
        }

        /// <summary>
        /// Gets or sets a value when true is passed in.
        /// </summary>
        public T WhenTrue { get; set; }

        /// <summary>
        /// Gets or sets a value when false is passed in.
        /// </summary>
        public T WhenFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolValue)
                return DependencyProperty.UnsetValue;

            return boolValue ? WhenTrue : WhenFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not T)
                return DependencyProperty.UnsetValue;

            return EqualityComparer<T>.Default.Equals((T)value, WhenTrue);
        }
    }
}
