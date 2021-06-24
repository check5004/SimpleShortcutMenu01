using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SimpleShortcutMenu01 {
    public class Layered {
        public static void UpdateLayer ( Form form, Bitmap png ) {
            UpdateLayer ( form, png, 255 );
        }

        /// <summary>
        /// 透過画像表示
        /// </summary>
        /// <param name="form">ウインドウ</param>
        /// <param name="png">画像</param>
        /// <param name="opacity">アルファ</param>
        public static void UpdateLayer ( Form form, Bitmap png, byte opacity ) {
            if ( png.PixelFormat != PixelFormat.Format32bppArgb ) {
                throw new ApplicationException ( "The bitmap must be 32ppp with alpha-channel." );
            }

            // size setting
            png = new Bitmap ( png, 90, 90 );

            // The ideia of this is very simple,
            // 1. Create a compatible DC with screen;
            // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
            // 3. Call the UpdateLayeredWindow.
            // これのIDEIAはとても簡単です。
            // 1.画面で互換性のあるDCを作成します。
            // 2.互換性DCのアルファチャンネルを使用して32BPPでビットマップを選択します。
            // 3.更新階層化ウィンドウを呼び出します。

            IntPtr screenDc = GetDC ( IntPtr.Zero );
            IntPtr memDc = CreateCompatibleDC ( screenDc );
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try {
                hBitmap = png.GetHbitmap ( Color.FromArgb ( 0 ) );  // grab a GDI handle from this GDI+ bitmap  このGDI +ビットマップからGDIハンドルをつかみます
                oldBitmap = SelectObject ( memDc, hBitmap );

                //Size size = new Size ( png.Width, png.Height );  // 画像サイズ指定 : Def
                Size size = new Size ( png.Width, png.Height );  // 画像サイズ指定

                Point pointSource = new Point ( 0, 0 );
                Point topPos = new Point ( form.Left, form.Top );
                BLENDFUNCTION blend = new BLENDFUNCTION ();
                blend.BlendOp = AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = AC_SRC_ALPHA;

                SetWindowLong ( form.Handle, GWL_EXSTYLE, GetWindowLong ( form.Handle, GWL_EXSTYLE ) | WS_EX_LAYERED );

                UpdateLayeredWindow ( form.Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, ULW_ALPHA );
            } finally {
                ReleaseDC ( IntPtr.Zero, screenDc );
                if ( hBitmap != IntPtr.Zero ) {
                    SelectObject ( memDc, oldBitmap );
                    //Windows.DeleteObject(hBitmap);
                    // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from ULWUtility GDI and it's working fine without any resource leak.
                    // windows.Deleteオブジェクト（Hビットマップ）;
                    //ドキュメントはWindows.Deleteオブジェクトを使用する必要があると言っていますが、そのようなメソッドがないため、UlWatility GDIから通常の削除オブジェクトを使用しています。リソースリークなしでは正常に機能します。
                    DeleteObject ( hBitmap );
                }
                DeleteDC ( memDc );
            }
        }

        #region Unmanaged API
        private enum Bool {
            False = 0,
            True
        };

        [StructLayout ( LayoutKind.Sequential )]
        private struct Point {
            public Int32 x;
            public Int32 y;
            public Point ( Int32 x, Int32 y ) { this.x = x; this.y = y; }
        }

        [StructLayout ( LayoutKind.Sequential )]
        private struct Size {
            public Int32 cx;
            public Int32 cy;
            public Size ( Int32 cx, Int32 cy ) { this.cx = cx; this.cy = cy; }
        }

        [StructLayout ( LayoutKind.Sequential, Pack = 1 )]
        private struct ARGB {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }

        [StructLayout ( LayoutKind.Sequential, Pack = 1 )]
        private struct BLENDFUNCTION {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        private const Int32 ULW_COLORKEY = 0x00000001;
        private const Int32 ULW_ALPHA = 0x00000002;
        private const Int32 ULW_OPAQUE = 0x00000004;

        private const byte AC_SRC_OVER = 0x00;
        private const byte AC_SRC_ALPHA = 0x01;

        private static int GWL_EXSTYLE = -20;
        private static int WS_EX_LAYERED = 0x80000;
        private static int LWA_ALPHA = 0x2;


        [DllImport ( "user32.dll", ExactSpelling = true, SetLastError = true )]
        private static extern Bool UpdateLayeredWindow ( IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags );

        [DllImport ( "user32.dll", ExactSpelling = true, SetLastError = true )]
        private static extern IntPtr GetDC ( IntPtr hWnd );

        [DllImport ( "user32.dll", ExactSpelling = true )]
        private static extern int ReleaseDC ( IntPtr hWnd, IntPtr hDC );

        [DllImport ( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
        private static extern IntPtr CreateCompatibleDC ( IntPtr hDC );

        [DllImport ( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
        private static extern Bool DeleteDC ( IntPtr hdc );

        [DllImport ( "gdi32.dll", ExactSpelling = true )]
        private static extern IntPtr SelectObject ( IntPtr hDC, IntPtr hObject );

        [DllImport ( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
        private static extern Bool DeleteObject ( IntPtr hObject );

        [DllImport ( "user32" )]
        private static extern int SetWindowLong ( IntPtr hWnd, int nIndex, int dwNewLong );
        [DllImport ( "user32" )]
        private static extern int GetWindowLong ( IntPtr hWnd, int nIndex );
        #endregion

    }
}

