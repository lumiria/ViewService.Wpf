#nullable enable

using System;
using System.Windows;
using System.Windows.Controls;

namespace ViewServices.View
{
    public static class ViewServiceFactory
    {
        public static IWindowActionService CreateWindowAction(Window target) =>
            new WindowActionServiceImpl(target);

        public static IWindowService CreateWindow(Type windowType, Window? owner = null) =>
            new WindowServiceImpl(windowType, owner);

        public static IMessageBoxService CreateMessageBox(Window? owner = null) =>
            new MessageBoxServiceImpl(owner);

        public static IOpenFileDialogService CreateOpenFileDialog(Window? owner = null) =>
            new OpenFileDialogServiceImpl(owner);
        public static ISaveFileDialogService CreateSaveFileDialog(Window? owner = null) =>
            new SaveFileDialogServiceImpl(owner);

        public static IFolderBrowserDialogService CreateFolderBrowserDialog(Window? owner = null) =>
            new FolderBrowserDialogServiceImpl(owner);

        public static IStyleableMessageBoxService CreateStyleableMessageBox(
            Window? owner = null,
            WindowStartupLocation startupLocation = WindowStartupLocation.CenterScreen,
            Style? windowStyle = null,
            Style? instructionTextStyle = null,
            ControlTemplate? textTemplate = null,
            Style? textStyle = null,
            ControlTemplate? buttonTemplate = null,
            Style? buttonStyle = null) =>
            new StyleableMessageBoxServiceImpl(
                owner,
                startupLocation,
                windowStyle,
                instructionTextStyle,
                textTemplate,
                textStyle,
                buttonTemplate,
                buttonStyle);
    }
}
