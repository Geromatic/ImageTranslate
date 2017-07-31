// Modified 2017 Scott Bishel
// License: Code Project Open License
// http://www.codeproject.com/info/cpol10.aspx

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ImageToText
{
    public class clsScreenCapture
    {

        static public Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow(), Rectangle.Empty);
        }

        static public Image captureActiveWindow()
        {
            return CaptureWindow(User32.GetForegroundWindow(), Rectangle.Empty);
        }

        static public Image CaptureDeskTopRectangle(Rectangle r)
        {
            return CaptureWindow(IntPtr.Zero, r);
        }

        static public Image CaptureWindow(IntPtr handle, Rectangle r)
        {
            // get the size
            User32.RECT windowRect = new User32.RECT();

            int width = 0;
            int height = 0;

            if (r == null)
            {
                User32.GetWindowRect(handle, ref windowRect);
                windowRect.left -= 5;
                windowRect.top -= 5;
                width = windowRect.right - windowRect.left + 5;
                height = windowRect.bottom - windowRect.top + 5;
            }
            else
            {
                windowRect.left = r.Left + 1;
                windowRect.top = r.Top + 1;
                width = r.Width - 1;
                height = r.Height - 1;
                windowRect.right = windowRect.left + width;
                windowRect.bottom = windowRect.top + height;
            }

            Bitmap img = new Bitmap(width, height);
            Graphics gr = Graphics.FromImage(img);

            #region Quality Tweaks TODO
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            #endregion

            gr.CopyFromScreen(windowRect.left, windowRect.top, 0, 0, new Size(width, height));

            return img;

        }


        /// Helper class containing User32 API functions
        public class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll", SetLastError = false)]
            public static extern IntPtr GetDesktopWindow();

            [DllImport("user32.dll")]
            public static extern Int32 GetWindowRect(IntPtr hWnd, ref RECT lpRect);

            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();

        }
        //User32
    }

}
