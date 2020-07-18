using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

// This code refers to the code of the following URL.
// https://github.com/sh1ch/Samples/blob/master/FileOpenDialogSample/FileOpenDialogSample/Dialogs/FolderBrowserDialog.cs

namespace Lumiria.ViewServices.View.Components
{
    public sealed class FolderBrowserDialog
    {
        public string SelectedPath { get; set; }

        public string Title { get; set; }

        public DialogResult ShowDialog() =>
            ShowDialog(IntPtr.Zero);

        public DialogResult ShowDialog(Window owner)
        {
            var handle = new WindowInteropHelper(owner).Handle;
            return ShowDialog(handle);
        }

        private DialogResult ShowDialog(IntPtr owner)
        {
            var dialog = new FilleOpenDialogInternal() as IFileOpenDialog;

            try
            {
                dialog.SetOptions(_FILEOPENDIALOGOPTIONS.FOS_PICKFOLDERS | _FILEOPENDIALOGOPTIONS.FOS_FORCEFILESYSTEM);
                if (!string.IsNullOrEmpty(SelectedPath))
                {
                    SetFolder(dialog, SelectedPath);
                }
                if (!string.IsNullOrEmpty(Title))
                {
                    dialog.SetTitle(Title);
                }

                var hr = dialog.Show(owner);

                if (hr == ERROR_CANCELLED) return DialogResult.Cancel;
                if (hr != 0) return DialogResult.Abort;

                dialog.GetResult(out var item);
                if (item == null) return DialogResult.Abort;

                item.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out var path);
                SelectedPath = path;

                return DialogResult.OK;
            }
            finally
            {
                Marshal.FinalReleaseComObject(dialog);
            }
        }

        private void SetFolder(IFileOpenDialog dialog, string path)
        {
            uint attributes = 0;
            if (NativeMethods.SHICreateFromPath(path, out var idl, ref attributes) != 0)
                return;

            if (NativeMethods.SHCreateShellItem(IntPtr.Zero, IntPtr.Zero, idl, out var item) == 0)
            {
                dialog.SetFolder(item);
            }

            if (idl != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(idl);
            }
        }

        #region

        [ComImport]
        [Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
        private class FilleOpenDialogInternal { }

        [ComImport]
        [Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItem
        {
            void BindToHandler();
            void GetParent();
            void GetDisplayName([In] SIGDN sigdnName, [MarshalAs(UnmanagedType.LPWStr)] out string pszName);
            void GetAttributes();
            void Compare();
        }

        [ComImport]
        [Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IFileOpenDialog
        {
            [PreserveSig]
            uint Show([In] IntPtr parent);
            void SetFileTyles();
            void SetFileTypeIndex([In] uint iFileType);
            void GEtFileTypeIndex(out uint piFileType);
            void Advise();
            void Unadvise();
            void SetOptions([In] _FILEOPENDIALOGOPTIONS fos);
            void GetOptions(out _FILEOPENDIALOGOPTIONS pfos);
            void SetDefaultFolder(IShellItem psi);
            void SetFolder(IShellItem psi);
            void GetFolder(out IShellItem ppsi);
            void GetCurrentSelection(out IShellItem ppsi);
            void SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);
            void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);
            void SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);
            void SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);
            void GetResult(out IShellItem ppis);
            void AddPlace(IShellItem psi, int alignment);
            void SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);
            void Close(int hr);
            void SetClientGuid();
            void CleawrClientData();
            void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);
            void GetResults([MarshalAs(UnmanagedType.Interface)] out IntPtr ppenum);
            void GetSelectedItems([MarshalAs(UnmanagedType.Interface)] out IntPtr ppsai);
        }

        private const uint ERROR_CANCELLED = 0x800704C7;

        private enum SIGDN : uint
        {
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,
            SIGDN_FILESYSPATH = 0x80058000,
            SIGDN_NORMALDISPLAY = 0,
            SIGDN_PARENTRELATIVE = 0x80080001,
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,
            SIGDN_URL = 0x80068000
        }

        private enum _FILEOPENDIALOGOPTIONS : uint
        {
            FOS_OVERWRITEPROMPT = 0x00000002,
            FOS_STRICTFILETYPES = 0x00000004,
            FOS_NOCHANGEDIR = 0x00000008,
            FOS_PICKFOLDERS = 0x00000020,
            FOS_FORCEFILESYSTEM = 0x00000040,
            FOS_ALLNONSTORAGEITEMS = 0x00000080,
            FOS_NOVALIDATE = 0x00000100,
            FOS_ALLOWMULTISELECT = 0x00000200,
            FOS_PATHMUSTEXIST = 0x00000800,
            FOS_FILEMUSTEXIST = 0x00001000,
            FOS_CREATEPROMPT = 0x00002000,
            FOS_SHAREAWARE = 0x00004000,
            FOS_NOREADONLYRETURN = 0x00008000,
            FOS_NOTESTFILECREATE = 0x00010000,
            FOS_HIDEMRUPLACES = 0x00020000,
            FOS_HIDEPINNEDPLACES = 0x00040000,
            FOS_NODEREFERENCELINKS = 0x00100000,
            FOS_DONTADDTORECENT = 0x02000000,
            FOS_FORCESHOWHIDDEN = 0x10000000,
            FOS_DEFAULTNOMINIMODE = 0x20000000,
            FOS_FORCEPREVIEWPANEON = 0x40000000,
            FOS_SUPPORTSTREAMABLEITEMS = 0x80000000
        }
        #endregion

        private static class NativeMethods
        {

            [DllImport("shell32.dll")]
            public static extern int SHICreateFromPath(
                [MarshalAs(UnmanagedType.LPWStr)] string pszPath, out IntPtr ppIdl, ref uint rgfInOut);

            [DllImport("shell32.dll")]
            public static extern int SHCreateShellItem(
                IntPtr pidParent, IntPtr psfParent, IntPtr pidl, out IShellItem ppsi);


        }
    }
}
