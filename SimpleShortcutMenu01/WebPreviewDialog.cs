using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    public partial class WebPreviewDialog : Form {
        public int maxHeight { get; set; }
        private DataRow secondMenuItemData;

        internal void RefreshWebPage ( DataRow secondMenuItemData ) {
            this.secondMenuItemData = secondMenuItemData;
            textBox1.Text = secondMenuItemData?["url"]?.ToString ();
        }
        public WebPreviewDialog ( ) {
            InitializeComponent ();
            maxHeight = 380;  // 高さ上限
        }

        private void Form1_Load ( object sender, EventArgs e ) {
            // textBoxがnullなら
            if ( textBox1.Text == "" ) {
                webBrowser1.Visible = false;
            } else {
                webBrowser1.Navigate ( new Uri ( textBox1.Text ) );
            }

            label5.Text = this.secondMenuItemData["title"].ToString ();
            label6.Text = this.secondMenuItemData["url"].ToString ();
            label7.Text = this.secondMenuItemData["comment"].ToString ();

            // アニメーション
            Form1_Animation_Load ( sender, e );
        }

        /// <summary>
        /// webBrowser が正常に読み込まれたイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted ( object sender, WebBrowserDocumentCompletedEventArgs e ) {
            if ( webBrowser1.Document != null ) {
                if ( webBrowser1.Document.Body.Style == null ) {
                    webBrowser1.Document.Body.Style = "Zoom:60%";
                    //webBrowser1.Document.Body.Style += $";Width:{webBrowser1.Width *4};Height:{webBrowser1.Height * 4}";
                } else {
                    webBrowser1.Document.Body.Style += ";Zoom:60%";
                    //webBrowser1.Document.Body.Style += $";Width:{webBrowser1.Width * 4};Height:{webBrowser1.Height * 4}";
                }
            }

            webBrowser1.AllowNavigation = false;
        }
        /// <summary>
        /// アニメーションクラスの作成
        /// </summary>
        public static class Animator {
            public static void Animate ( int interval, int frequency, Func<int, int, bool> callback ) {
                var timer = new System.Windows.Forms.Timer ();
                timer.Interval = interval;
                int frame = 0;
                timer.Tick += ( sender, e ) => {
                    if ( callback ( frame, frequency ) == false || frame >= frequency ) {
                        timer.Stop ();
                    }
                    frame++;
                };
                timer.Start ();
            }
            public static void Animate ( int duration, Func<int, int, bool> callback ) {
                const int interval = 25;
                if ( duration < interval ) duration = interval;
                Animate ( interval, duration / interval, callback );
            }
        }
        /// <summary>
        /// フェードインする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Animation_Load ( object sender, EventArgs e ) {
            timer1.Tick += Timer1_Tick;
            this.Height = 1;
            timer1.Interval = 10;
            timer1.Start ();
        }
        private void Timer1_Tick ( object sender, EventArgs e ) {
            if ( this.Height >= maxHeight ) {
                this.Height = maxHeight;
                timer1.Stop ();
            }
            this.Height += 35;
        }

    }
}
