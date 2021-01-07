using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using WinRT;

namespace WinUI3Preview3Sample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
        internal interface IWindowNative
        {
            IntPtr WindowHandle { get; }
        }

        // Random generator
        private Random _random = new Random();

        // Handle for internal IWindowNative
        private IWindowNative _windowNative;

        public MainWindow()
        {
            this.InitializeComponent();

            _windowNative = this.As<IWindowNative>();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            // Randomizes x and y position
            int x = _random.Next(1000);
            int y = _random.Next(1000);

            int HWND_TOP = 0;
            int SWP_NOSIZE = 0x0001;
            // Moves the window
            SetWindowPos(_windowNative.WindowHandle, (IntPtr)HWND_TOP, x, y, 0, 0, SWP_NOSIZE);
        }
    }
}
