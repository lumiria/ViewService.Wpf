using System.Windows;
using System.Windows.Controls;

namespace ViewServices.View.Extenders
{
    internal static class ControlExtender
    {
        public static ControlTemplate GetTemplate(DependencyObject obj) =>
            (ControlTemplate)obj.GetValue(TemplateProperty);
        public static void SetTemplate(DependencyObject obj, int value)
        {
            obj.SetValue(TemplateProperty, value);
        }
        public static readonly DependencyProperty TemplateProperty =
            DependencyProperty.RegisterAttached("Template", typeof(ControlTemplate), typeof(ControlExtender),
                new PropertyMetadata(null, (d, e) =>
                {
                    var control = d as Control;
                    if (control == null || e.NewValue == null) return;

                    control.Template = (ControlTemplate)e.NewValue;
                }));

        public static Style GetStyle(DependencyObject obj) =>
            (Style)obj.GetValue(StyleProperty);
        public static void SetStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(StyleProperty, value);
        }
        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(Style), typeof(ControlExtender),
                new PropertyMetadata(null, (d, e) =>
                {
                    var control = d as Control;
                    if (control == null || e.NewValue == null) return;

                    control.Style = (Style)e.NewValue;
                }));
    }
}
