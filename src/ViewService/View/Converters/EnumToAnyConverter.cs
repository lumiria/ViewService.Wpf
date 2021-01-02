#nullable enable

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace ViewServices.View.Converters
{
    /// <summary>
    /// Represents the converter that converts any enumeration values to and from any values.
    /// </summary>
    public abstract class EnumToAnyConverter<T> : IValueConverter
    {
        /// <summary>
        /// Gets or sets a value when that matches.
        /// </summary>
        public T WhenMatch { get; set; }

        /// <summary>
        /// Gets or sets a value when that no matches.
        /// </summary>
        public T WhenNoMatch { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="EnumToVisibilityConverter"/> class.
        ///// </summary>
        //public EnumToAnyConverter()
        //{
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumToVisibilityConverter"/> class.
        /// </summary>
        public EnumToAnyConverter(T matchValue, T noMatchValue)
        {
            WhenMatch = matchValue;
            WhenNoMatch = noMatchValue;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.
        /// If the method returns null, the valid null value is used/
        /// </returns>
        public object? Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter is not string paramString)
                return DependencyProperty.UnsetValue;

            if (!Enum.IsDefined(value.GetType(), value))
                return DependencyProperty.UnsetValue;

            var paramValue = Enum.Parse(value.GetType(), paramString);
            return paramValue.Equals(value)
                ? WhenMatch
                : WhenNoMatch;
        }


        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converter value.
        /// If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter is not string paramString)
                return DependencyProperty.UnsetValue;

            if (value is not T typeValue)
                return DependencyProperty.UnsetValue;

            if (!Enum.IsDefined(targetType, paramString))
                return DependencyProperty.UnsetValue;

            if (!EqualityComparer<T>.Default.Equals(typeValue, WhenMatch))
                return DependencyProperty.UnsetValue;

            return Enum.Parse(targetType, paramString);
        }
    }
}
