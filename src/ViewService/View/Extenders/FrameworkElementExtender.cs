using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ViewServices.View.Extenders
{
    public static class FrameworkElementExtender
    {
        public static Style GetStyle(DependencyObject obj) =>
            (Style)obj.GetValue(StyleProperty);
        public static void SetStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(StyleProperty, value);
        }
        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(Style), typeof(FrameworkElementExtender),
                new PropertyMetadata(null, (d, e) =>
                {
                    var control = d as FrameworkElement;
                    if (control == null || e.NewValue == null) return;

                    control.Style = (Style)e.NewValue;
                }));
    }
}
