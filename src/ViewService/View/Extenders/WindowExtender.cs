using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ViewServices.View.Extenders
{
    internal static class WindowExtender
    {
        private const int GWL_EXSTYLE = -20;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_FRAMECHANGED = 0x0020;
        private const int WS_EX_DLGMODALFRAME = 0x0001;
        private const uint WM_SECTION = 0x0080;

        public static bool GetShowIcon(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowIconProperty);
        }

        public static void SetShowIcon(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowIconProperty, value);
        }

        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.RegisterAttached("ShowIcon", typeof(bool), typeof(WindowExtender),
                new PropertyMetadata(true, (d, e) =>
                {
                    var window = d as Window;
                    if (window == null) return;

                    RemoveIcon(window);
                }));

        public static void RemoveIcon(Window window)
        {
            window.SourceInitialized += (_, __) =>
            {
                var hwnd = new WindowInteropHelper(window).Handle;
                int extendedStyle = NativeMethods.GetWindowLong(hwnd, GWL_EXSTYLE);
                NativeMethods.SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_DLGMODALFRAME);


                NativeMethods.SendMessage(hwnd, WM_SECTION, (IntPtr)0, IntPtr.Zero);
                NativeMethods.SendMessage(hwnd, WM_SECTION, (IntPtr)1, IntPtr.Zero);

                NativeMethods.SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0,
                    SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            };
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern int GetWindowLong(IntPtr hwnd, int index);

            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hwnd, uint msg,
              IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
              int x, int y, int width, int height, uint flags);
        }
    }
}
