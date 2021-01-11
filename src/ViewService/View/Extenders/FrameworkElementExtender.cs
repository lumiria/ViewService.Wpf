using System.Windows;

namespace ViewServices.View.Extenders
{
    internal static class FrameworkElementExtender
    {
        #region Style Property
        /// <summary>
        /// Gets the style used by the target element when it is rendered.
        /// This property is bindable.
        /// </summary>
        /// <param name="obj">A target object.</param>
        /// <returns>A style used by the target element when it is rendered.</returns>
        public static Style GetStyle(DependencyObject obj) =>
            (Style)obj.GetValue(StyleProperty);
        /// <summary>
        /// Sets the style used by the target element when it is rendered.
        /// This property is bindable.
        /// </summary>
        /// <param name="obj">A target object.</param>
        /// <param name="value">A style used by the target element when it is rendered.</param>
        public static void SetStyle(DependencyObject obj, Style value) =>
            obj.SetValue(StyleProperty, value);
        /// <summary>Provides bindable Style property.</summary>
        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(Style), typeof(FrameworkElementExtender),
                new PropertyMetadata(null, (d, e) =>
                {
                    if (d is not FrameworkElement self || e.NewValue == null)
                        return;

                    self.Style = (Style)e.NewValue;
                }));
        #endregion Style Property
    }
}
