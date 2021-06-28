using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    public partial class OXMessageBox : Form {
        //Btnメソッドのreturn用の変数
        bool flag = true;

        //引数が1つの場合、左右の〇✕ボタンは非表示にする
        public OXMessageBox ( string title, string message, bool OX ) {
            InitializeComponent ();
            lblTitle.Text = title;
            lblMessage.Text = message;
            if ( OX ) {
                pBoxOnly.Visible = false;
            } else {
                pBoxBatu.Visible = false;
                pBoxMaru.Visible = false;
            }
        }

        public bool Btn {
            get {
                return flag;
            }
        }

        public OXMessageBox () {
            InitializeComponent ();

            //using ( OXMessageBox dlg = new OXMessageBox ( "test", "testtest", false ) ) {
            //    if ( dlg.ShowDialog () == DialogResult.OK ) {
            //        //OKがクリックされた場合
            //        MessageBox.Show ( "ok" );
            //    } else {
            //        //キャンセルがクリックされた場合
            //        MessageBox.Show ( "キャンセルされました。" );
            //    }
            //}
        }


        /// <summary>
        /// マウスホバー：瞬時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_MouseEnter ( object sender, EventArgs e ) {
            pBoxMaru.Image = Properties.Resources.Maru;
        }

        private void CancelButton_Enter ( object sender, EventArgs e ) {
            pBoxBatu.Image = Properties.Resources.Batu;
            pBoxOnly.Image = Properties.Resources.Batu; ;
        }
        /// <summary>
        /// マウスが離れた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_MouseLeave ( object sender, EventArgs e ) {
            // defaultに
            pBoxMaru.Image = Properties.Resources.MaruGray;
        }
        private void CancelButton_Leave ( object sender, EventArgs e ) {
            pBoxBatu.Image = Properties.Resources.BatuGray;
            pBoxOnly.Image = Properties.Resources.BatuGray;
        }
        /// <summary>
        /// マウスが押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_MouseDown ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left ) {
                // 左クリック時
                pBoxMaru.Image = Properties.Resources.MaruLightBlue;
            }
        }
        private void CancelButton_Down ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left ) {
                // 左クリック時
                pBoxBatu.Image = Properties.Resources.BatuLightRed;
                pBoxOnly.Image = Properties.Resources.BatuLightRed;
            }
        }
        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click ( object sender, EventArgs e ) {
            pBoxMaru.Image = Properties.Resources.Maru;
            this.Close ();
        }

        private void CancelButton_Click ( object sender, EventArgs e ) {
            pBoxBatu.Image = Properties.Resources.Batu;
            pBoxOnly.Image = Properties.Resources.Batu;
            flag = false;
            this.Close ();
        }


        private Point mousePoint;
        private void MessageDialog_MouseDown ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left ) {
                // 左クリック時
                pBoxBatu.Image = Properties.Resources.BatuLightRed;
                pBoxOnly.Image = Properties.Resources.BatuLightRed;
                // マウスの座標を取得
                mousePoint = e.Location;
            }
        }

        private void MessageDialog_MouseMove ( object sender, MouseEventArgs e ) {
            // マウスの座標を足す
            if ( ( e.Button & MouseButtons.Left ) == MouseButtons.Left ) {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

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
                Animate ( 25, duration / interval, callback );
            }
        }
        /// <summary>
        /// フェードインする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load ( object sender, EventArgs e ) {
            timer1.Tick += Timer1_Tick;


            this.Height = 1;
            timer1.Interval = 10;
            timer1.Start ();
        }

        private void Timer1_Tick ( object sender, EventArgs e ) {
            if ( this.Height >= 341 ) {
                timer1.Stop ();
            }
            this.Height += 35;
        }
    }
}
