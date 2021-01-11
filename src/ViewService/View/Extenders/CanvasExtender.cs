using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ViewServices.DataTypes;

namespace ViewServices.View.Extenders
{
    public static class CanvasExtender
    {
        public static PointRatio GetOffsetLocation(DependencyObject obj) =>
            (PointRatio)obj.GetValue(OffsetLocationProperty);
        public static void SetOffsetLocation(DependencyObject obj, PointRatio value) =>
            obj.SetValue(OffsetLocationProperty, value);
        /// <summary>Identifies the <see cref="FrameworkElementExtender.OffsetLocation"/> attached property.</summary>
        public static readonly DependencyProperty OffsetLocationProperty =
            DependencyProperty.RegisterAttached("OffsetLocation", typeof(PointRatio), typeof(CanvasExtender),
                new PropertyMetadata(new PointRatio(double.NaN, double.NaN), (d, e) =>
                {
                    if (d is not FrameworkElement element)
                        return;
                    if (e.NewValue is not PointRatio ratio
                        || e.OldValue is not PointRatio oldRatio)
                        return;

                    if (!PointRatio.IsEmpty(oldRatio))
                        UnregisterEventHandler(element);

                    if (PointRatio.IsEmpty(ratio))
                        return;

                    RegisterEventHandler(element);
                }));

        private static ConditionalWeakTable<DependencyObject, RefValue<Point>> _initialLocations
            = new ConditionalWeakTable<DependencyObject, RefValue<Point>>();

        private static void ChangeLocation(FrameworkElement element, PointRatio ratio)
        {
            var location = _initialLocations.GetOrCreateValue(element).Value;

            var offsetX = element.ActualWidth * ratio.Horizontal;
            var offsetY = element.ActualHeight * ratio.Vertical;

            UnregisterLocationChangedEventHandler(element);
            SetLeft(element, location.X - offsetX);
            SetTop(element, location.Y - offsetY);
            RegisterLocationChangedEventHandler(element);
        }

        private static void ChangeLeft(FrameworkElement element, double ratio)
        {
            var location = _initialLocations.GetOrCreateValue(element).Value;

            var offsetX = element.ActualWidth * ratio;

            UnregisterLeftChangedEventHandler(element);
            SetLeft(element, location.X - offsetX);
            RegisterLeftChangedEventHandler(element);
        }


        private static void ChangeTop(FrameworkElement element, double ratio)
        {
            var location = _initialLocations.GetOrCreateValue(element).Value;

            var offsetY = element.ActualHeight * ratio;

            UnregisterTopChangedEventHandler(element);
            SetTop(element, location.Y - offsetY);
            RegisterTopChangedEventHandler(element);
        }

        private static void SetLeft(UIElement target, double value)
        {
            if (BindingOperations.IsDataBound(target, Canvas.LeftProperty))
            {
                target.SetCurrentValue(Canvas.LeftProperty, value);
            }
            else
            {
                Canvas.SetLeft(target, value);
            }
        }

        private static void SetTop(UIElement target, double value)
        {
            if (BindingOperations.IsDataBound(target, Canvas.TopProperty))
            {
                target.SetCurrentValue(Canvas.TopProperty, value);
            }
            else
            {
                Canvas.SetTop(target, value);
            }
        }

        private static void RegisterEventHandler(FrameworkElement element)
        {
            RegisterLocationChangedEventHandler(element);

            element.SizeChanged += FrameworkElement_SizeChanged;
            element.Unloaded += FrameworkElement_Unloaded;

            _initialLocations.GetOrCreateValue(element).Value = new Point(
                Canvas.GetLeft(element),
                Canvas.GetTop(element));
        }

        private static void UnregisterEventHandler(FrameworkElement element)
        {
            UnregisterLocationChangedEventHandler(element);

            element.SizeChanged -= FrameworkElement_SizeChanged;
            element.Unloaded -= FrameworkElement_Unloaded;
        }

        private static void RegisterLeftChangedEventHandler(FrameworkElement element)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(Canvas.LeftProperty, element.GetType());
            desc.AddValueChanged(element, FrameworkElement_LeftChanged);
        }

        private static void RegisterTopChangedEventHandler(FrameworkElement element)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(Canvas.TopProperty, element.GetType());
            desc.AddValueChanged(element, FrameworkElement_TopChanged);
        }

        private static void RegisterLocationChangedEventHandler(FrameworkElement element)
        {
            RegisterLeftChangedEventHandler(element);
            RegisterTopChangedEventHandler(element);
        }

        private static void UnregisterLeftChangedEventHandler(FrameworkElement element)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(Canvas.LeftProperty, element.GetType());
            desc.RemoveValueChanged(element, FrameworkElement_LeftChanged);
        }

        private static void UnregisterTopChangedEventHandler(FrameworkElement element)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(Canvas.TopProperty, element.GetType());
            desc.RemoveValueChanged(element, FrameworkElement_TopChanged);
        }

        private static void UnregisterLocationChangedEventHandler(FrameworkElement element)
        {
            UnregisterLeftChangedEventHandler(element);
            UnregisterTopChangedEventHandler(element);
        }

        private static void FrameworkElement_LeftChanged(object sender, EventArgs _)
        {
            if (sender is not FrameworkElement element)
                return;

            var location = _initialLocations.GetOrCreateValue(element);

            var left = Canvas.GetLeft(element);
            location.Value = new Point(left, location.Value.Y);

            ChangeLeft(element, GetOffsetLocation(element).Horizontal);
        }

        private static void FrameworkElement_TopChanged(object sender, EventArgs _)
        {
            if (sender is not FrameworkElement element)
                return;

            var location = _initialLocations.GetOrCreateValue(element);

            var top = Canvas.GetTop(element);
            location.Value = new Point(location.Value.X, top);

            ChangeTop(element, GetOffsetLocation(element).Vertical);
        }

        private static void FrameworkElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is not FrameworkElement element)
                return;

            ChangeLocation(element, GetOffsetLocation(element));
        }

        private static void FrameworkElement_Unloaded(object sender, RoutedEventArgs e)
        {
            if (sender is not FrameworkElement element)
                return;

            UnregisterEventHandler(element);

            element.Loaded += FrameworkElement_Loaded;
        }

        private static void FrameworkElement_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is not FrameworkElement element
                || element.GetValue(OffsetLocationProperty) is not PointRatio ratio
                || PointRatio.IsEmpty(ratio))
                return;

            element.Loaded -= FrameworkElement_Loaded;
            RegisterEventHandler(element);
        }

        private class RefValue<T>
            where T : struct
        {
            public RefValue()
            {
            }

            public RefValue(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
        }

    }
}
