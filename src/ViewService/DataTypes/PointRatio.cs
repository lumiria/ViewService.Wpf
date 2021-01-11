#nullable enable

using System;
using System.ComponentModel;
using System.Windows;

namespace ViewServices.DataTypes
{
    [TypeConverter(typeof(PointRatioConverter))]
    public struct PointRatio
    {
        public PointRatio(double horizontal, double vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public double Horizontal { get; }

        public double Vertical { get; }

        public static PointRatio Empty =>
            new PointRatio(double.NaN, double.NaN);

        public static bool IsEmpty(PointRatio value) =>
            double.IsNaN(value.Horizontal) && double.IsNaN(value.Vertical);

        public static bool TryParse(string s, out PointRatio result)
        {
            var converter = new PointConverter();
            try
            {
                var point = (Point)converter.ConvertFrom(s);
                result = new PointRatio(
                    point.X,
                    point.Y);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }

    public class PointRatioConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is PointRatio)
                return value;
            if (value is string stringValue
                && PointRatio.TryParse(stringValue, out var tmp))
                return tmp;
            return base.ConvertFrom(context, culture, value);
        }
    }
}
