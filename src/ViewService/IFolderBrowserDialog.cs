#nullable enable

using System.Windows;
using Lumiria.ViewServices.View.Components;

namespace Lumiria.ViewServices
{
    public interface IFolderBrowserDialogService : IViewService
    {
        public DialogResult ShowDialog(Window? owner);
    }
}
