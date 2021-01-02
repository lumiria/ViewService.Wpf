#nullable enable

using System.Windows;

namespace ViewServices.View.Xaml
{
    public interface IOwnerRequirement
    {
        Window? Owner { get; set; }
    }
}
