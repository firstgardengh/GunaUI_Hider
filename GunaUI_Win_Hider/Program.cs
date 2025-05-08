using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        const int SW_HIDE = 0;
        IntPtr window_handle = find_guna_window();

        if (window_handle == IntPtr.Zero)
        {
            Console.WriteLine("Failed to find Guna.UI2 window!");
            return;
        }

        if (!ShowWindow(window_handle, SW_HIDE))
        {
            Console.WriteLine("Failed to set window attributes!");
            return;
        }

        Console.WriteLine("Done! Press enter to exit.");
        Console.ReadLine();
        return;

    }

    public static IntPtr find_guna_window()
    {
        foreach (Process process in Process.GetProcesses())
        {
            if (process.MainWindowTitle.StartsWith("Guna.UI2"))
            {
                return process.MainWindowHandle;
            }
        }

        return IntPtr.Zero;
    }


    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
}
