#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace TubePlayer
{
    public partial class App : Application
    {
        const int WindowsHeight = 896;
        const int WindowsWidth = 414;

        public App()
        {
            InitializeComponent();
            // Enable Version Tracking
            VersionTracking.Track();

            // Set App Size On MS Windows
#if WINDOWS
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
                var mauiWindow = handler.VirtualView;
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                appWindow.Resize(new SizeInt32(WindowsWidth, WindowsHeight));
            });
#endif

            MainPage = new AppShell();
        }
    }
}
