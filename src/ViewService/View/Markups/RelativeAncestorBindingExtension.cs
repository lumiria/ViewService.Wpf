#nullable enable

using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ViewServices.View.Markups
{
    /// <summary>
    /// Provides a binding that has RelativeSource with FindAncestor specified.
    /// </summary>
    public class RelativeAncestorBindingExtension : MarkupExtension
    {
        /// <summary>
        /// Gets or sets the path to the binding source property.
        /// </summary>
        public PropertyPath Path { get; set; } =
            new PropertyPath(".");

        /// <summary>
        /// Gets or sets the type of ancestor to look for.
        /// </summary>
        public Type? Type { get; set; }

        /// <summary>
        /// Gets or sets the level of ancestor to look for, in <see cref="System.Windows.Data.RelativeSourceMode.FindAncestor" />  mode.
        /// Use 1 to indicate the one nearest to the binding target element.
        /// </summary>
        public int Level { get; set; } =
            1;

        /// <summary>
        ///  Returns an object that should be set on the property where this binding and extension are applied.
        /// </summary>
        /// <param name="serviceProvider">The object that can provide services for the markup extension.</param>
        /// <returns>The value to set on the binding target property.</returns>
        public override object? ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider.GetService(typeof(IProvideValueTarget)) is not IProvideValueTarget provider)
                return null;

            if (provider.TargetObject is not DependencyObject)
                return null;

            if (provider.TargetProperty is not DependencyProperty)
                return null;

            if (Type == null)
                return null;

            var binding = new Binding
            {
                RelativeSource = new RelativeSource(
                    RelativeSourceMode.FindAncestor,
                    Type,
                    Level)
            };
            //BindingOperations.SetBinding(target, property, binding);
            return binding.ProvideValue(serviceProvider);
        }
    }
}
