using System.Windows;

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
        /// <summary>
        /// Provides bindable Style property.
        /// </summary>
        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(Style), typeof(FrameworkElementExtender),
                new PropertyMetadata(null, (d, e) =>
                {
                    if (d is not FrameworkElement self || e.NewValue == null)
                        return;

                    self.Style = (Style)e.NewValue;
                }));
    }
}
